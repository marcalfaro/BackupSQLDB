Option Explicit On
Imports System.Data.SqlClient
Imports System.Threading

Module m_MSSQL

    Private Function _GetConnString(ByVal dataSrc As String) As String
        Dim rslt As String = String.Empty

        rslt = $"Data Source={dataSrc};Integrated Security=True"
        Debug.Print($"rslt: {rslt}")

        Return rslt
    End Function

    Private Function _GetConnString(ByVal dataSrc As String,
                                    ByVal userId As String,
                                    ByVal pwd As String) As String
        Dim rslt As String = String.Empty

        rslt = $"Data Source={dataSrc};User ID={userId};Password={pwd};Max Pool Size=10000"
        Debug.Print($"rslt: {rslt}")

        Return rslt
    End Function
    Private Function _GetConnString(ByVal dataSrc As String,
                                    ByVal initCatalog As String,
                                    ByVal userId As String,
                                    ByVal pwd As String) As String
        Dim rslt As String = String.Empty

        rslt = $"Data Source={dataSrc};Initial Catalog={initCatalog};User ID={userId};Password={pwd};Max Pool Size=10000;MultipleActiveResultSets=True"
        Debug.Print($"rslt: {rslt}")

        Return rslt
    End Function

    Public Async Function DB_CheckConnection(ByVal dataSrc As String,
                                            ByVal userId As String,
                                            ByVal pwd As String) As Task(Of Boolean)
        Dim ok As Boolean = False

        Dim connString As String = $"Data Source={dataSrc};User ID={userId};Password={pwd};Max Pool Size=10000"
        Try
            Using _conn As New SqlConnection(connString)
                Await _conn.OpenAsync()
                '_conn.Open()
                ok = True
                _conn.Close()
            End Using
        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try
        Return ok
    End Function


    Public Async Function _LoadTheDatabases(ByVal ct As CancellationToken) As Task(Of List(Of String))
        Dim rslt As New List(Of String)

        Try
            Dim connString As String = _GetConnString(My.Settings.dbSrc, My.Settings.dbUsr, My.Settings.dbPwd)
            Using _conn As New SqlConnection(connString)
                Await _conn.OpenAsync()

                Using cmd As SqlCommand = New SqlCommand("sp_databases", _conn)

                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandTimeout = 0

                    Dim rdr As SqlDataReader = Await cmd.ExecuteReaderAsync(ct)
                    If rdr.HasRows Then
                        While Await rdr.ReadAsync(ct)
                            rslt.Add(rdr("DATABASE_NAME"))
                        End While
                    End If
                End Using

                _conn.Close()
            End Using
        Catch ex As Exception
            Debug.Print(ex.Message)
        End Try

        Return rslt
    End Function


    Public Async Function _BackupDatabase(ByVal databases As List(Of String), ByVal loc As String, ByVal ct As CancellationToken) As Task(Of List(Of String))
        Dim results As New List(Of String)

        If String.IsNullOrWhiteSpace(loc) Then
            results.Add("Error: Destination folder not defined")
        Else
            If databases Is Nothing OrElse databases.Count = 0 Then
                results.Add("Error: Did not specify database to backup")
            Else

                Try
                    Dim connString As String = _GetConnString(My.Settings.dbSrc, My.Settings.dbUsr, My.Settings.dbPwd)
                    Using _conn As New SqlConnection(connString)
                        Await _conn.OpenAsync()

                        Dim ttl As Integer = databases.Count
                        For i As Integer = 0 To ttl - 1

                            Dim db As String = databases(i)
                            Dim bakfile As String = IO.Path.Combine(loc, $"{db}-{Now.ToString("yyyy-MM-dd_HHmmssfff")}.fbak")
                            Dim sqlQ As String = $"BACKUP DATABASE {db} TO DISK='{bakfile}'"

                            Try
                                Using cmd As New SqlCommand(sqlQ, _conn)
                                    cmd.CommandTimeout = 0

                                    Dim r As Integer = Await cmd.ExecuteNonQueryAsync(ct)
                                    If CBool(r) Then
                                        results.Add($"'{db}' full backup successfully created: '{bakfile}'")
                                    Else
                                        results.Add($"Error: Failed to backup '{db}'")
                                    End If

                                End Using
                            Catch ex As Exception
                                results.Add($"Error: '{db}' - {ex.Message}")
                            End Try

                        Next

                        _conn.Close()
                    End Using

                Catch ex As Exception
                    results.Add($"Error: {ex.Message}")
                End Try

            End If
        End If

        Return results
    End Function
End Module
