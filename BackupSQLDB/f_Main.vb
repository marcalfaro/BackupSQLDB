Option Explicit On
Imports System.Threading

Public Class f_Main

#Region " Verbose functions "
    'Use the shortcuts "V_..."
    Private Sub V_Success(ByVal msg As String, Optional ByVal isNewLine As Boolean = True)
        EchoRTB(isNewLine, Color.Lime, msg)
    End Sub
    Private Sub V_Err(ByVal msg As String, Optional ByVal isNewLine As Boolean = True)
        EchoRTB(isNewLine, Color.Red, msg)
    End Sub
    Private Sub V_Info(ByVal msg As String, Optional ByVal isNewLine As Boolean = True)
        EchoRTB(isNewLine, Color.White, msg)
    End Sub
    Private Sub V_Warn(ByVal msg As String, Optional ByVal isNewLine As Boolean = True)
        EchoRTB(isNewLine, Color.Yellow, msg)
    End Sub

    Dim sLock As New Object
    Private Delegate Sub EchoRTB_(ByVal isNewLine As Boolean, ByVal kolor As Color, ByVal msg As String)
    Private Sub EchoRTB(ByVal isNewLine As Boolean, ByVal kolor As Color, ByVal msg As String)
        SyncLock sLock
            Try
                If InvokeRequired Then
                    BeginInvoke(New EchoRTB_(AddressOf EchoRTB), isNewLine, kolor, msg)
                Else
                    With rtb
                        .SelectionStart = .TextLength
                        If isNewLine Then
                            .AppendText(vbNewLine)
                            .SelectionColor = Color.Gray
                            .AppendText("[" & Now.ToString("yyyy.MM.dd HH:mm:ss.fff") & "]  ")
                        End If
                        .SelectionColor = kolor
                        .AppendText(msg)
                        .SelectionStart = .Text.Length
                        .ScrollToCaret()
                    End With
                End If
            Catch ex As Exception
                Debug.Print(ex.Message)
            End Try
        End SyncLock
    End Sub
#End Region

#Region " Hide To Tray "
    Private Sub HideToTray(ByVal hideApp As Boolean)
        ShowInTaskbar = Not hideApp
        With NotifyIcon1
            '.Icon = New Icon(My.Application.ic, 40, 40)
            .Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath)
            .Visible = hideApp
            If hideApp Then
                Dim _t As String = $"{Application.ProductName} ver. {Application.ProductVersion}"
                .Text = _t
                .ShowBalloonTip(2000, _t, "Running in System Tray", ToolTipIcon.Info)
                Hide()
            Else
                Show()
                WindowState = FormWindowState.Normal
            End If
        End With
    End Sub
    Private Sub NotifyIcon1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles NotifyIcon1.DoubleClick
        If ModifierKeys <> Keys.Shift Then
            AD()
            Exit Sub
        End If
        HideToTray(False)
    End Sub

    Public Sub AD()
        MsgBox("You don't have the rights to perform this action.", vbApplicationModal + vbExclamation, "Access Denied")
    End Sub
    Private Sub tsmiTray_Click(sender As Object, e As EventArgs) Handles tsmiTray.Click
        HideToTray(True)
    End Sub
#End Region

    Private Sub tsmiClose_Click(sender As Object, e As EventArgs) Handles tsmiClose.Click
        If ModifierKeys <> Keys.Shift Then
            MsgBox("You have no access to this function.", vbApplicationModal + vbExclamation, "Access Denied")
            Exit Sub
        End If

        Close()
    End Sub

    Private Sub tsmiSettings_Click(sender As Object, e As EventArgs) Handles tsmiSettings.Click
        If ModifierKeys <> Keys.Shift Then
            MsgBox("You have no access to this function.", vbApplicationModal + vbExclamation, "Access Denied")
            Exit Sub
        End If

        Using f As New f_Settings
            f.ShowDialog()
        End Using
    End Sub

    Private Sub f_Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Text = $"{Application.ProductName} {Application.ProductVersion}"
        Icon = System.Drawing.Icon.ExtractAssociatedIcon(Application.ExecutablePath)

        If ModifierKeys <> Keys.Shift Then
            End
        Else
            Text = $"{Application.ProductName} {Application.ProductVersion}"

            tsmiLoadDBs.PerformClick()
        End If
    End Sub

    Private cts_LoadDB As CancellationTokenSource = Nothing
    Private Async Sub tsmiLoadDBs_Click(sender As Object, e As EventArgs) Handles tsmiLoadDBs.Click
        If cts_LoadDB Is Nothing Then
            Try
                tsmiLoadDBs.Text = "Cancel Load"
                tv1.Nodes.Clear()
                cts_LoadDB = New CancellationTokenSource
                V_Info("LoadDBs(): Connecting to server... ")

                Dim DBs As List(Of String) = Await _LoadTheDatabases(cts_LoadDB.Token)
                If DBs IsNot Nothing AndAlso DBs.Count > 0 Then
                    V_Success("LoadDBs(): Fetching databases...")
                    With tv1.Nodes
                        For Each s As String In DBs
                            .Add(s, s)

                            If My.Settings.dbSelected IsNot Nothing Then
                                If My.Settings.dbSelected.Contains(s) Then tv1.Nodes(s).Checked = True
                            End If

                        Next
                    End With
                Else
                    V_Warn("LoadDBs(): No databases retrieved.")
                End If
            Catch ex As Exception
                V_Err($"LoadDBs(): {ex.Message}")
            Finally
                cts_LoadDB.Dispose()
                cts_LoadDB = Nothing
                V_Info("LoadDBs(): Operation done.")
                tsmiLoadDBs.Text = "Load Databases"
            End Try
        Else
            cts_LoadDB.Cancel()
        End If
    End Sub

    Private Sub btn__Click(sender As Object, e As EventArgs) Handles btnSelDir.Click, btnExploreDir.Click
        Try
            Select Case CType(sender, Button).Name
                Case btnSelDir.Name
                    Dim fldr As String = _SelectFolder()
                    If Not String.IsNullOrWhiteSpace(fldr) Then
                        My.Settings.buLocation = fldr
                    End If

                Case btnExploreDir.Name
                    _ExploreFolder(txtLocation.Text)
            End Select
        Catch ex As Exception
            MsgBox(ex.Message, vbApplicationModal + vbExclamation, "Error")
        End Try

    End Sub

    Private cts_Backup As CancellationTokenSource = Nothing
    Private Async Sub tsmiBackup_Click(sender As Object, e As EventArgs) Handles tsmiBackup.Click

        If ModifierKeys <> Keys.Shift Then
            MsgBox("You have no access to this function.", vbApplicationModal + vbExclamation, "Access Denied")
            Exit Sub
        End If

        If cts_Backup Is Nothing Then

            Dim checkedNodes As List(Of String) = _getCheckedNodes()
            If checkedNodes.Count > 0 Then

                Try
                    tsmiBackup.Text = "Cancel Backup"

                    cts_Backup = New CancellationTokenSource
                    V_Info("Backup(): Executing backup... ")

                    Dim rslts = Await _BackupDatabase(checkedNodes, My.Settings.buLocation, cts_Backup.Token)
                    For Each s As String In rslts
                        If s.StartsWith("Error: ") Then
                            V_Err($"Backup(): {s.Replace("Error: ", "")}")
                        Else
                            V_Success($"Backup(): {s}")
                        End If
                    Next

                    SaveSelectedDBs(checkedNodes)

                Catch ex As Exception
                    V_Err($"Backup(): {ex.Message}")
                Finally
                    cts_Backup.Dispose()
                    cts_Backup = Nothing
                    V_Info("Backup(): Operation done.")
                    tsmiBackup.Text = "Backup"
                End Try

            Else
                V_Warn("Please select the database(s) to backup!")
            End If
        Else
            cts_Backup.Cancel()
        End If
    End Sub

    Private Function _getCheckedNodes() As List(Of String)
        Dim ret As New List(Of String)
        Try
            If tv1.Nodes.Count > 0 Then
                Dim ttlN As Integer = tv1.Nodes.Count
                For i As Integer = 0 To ttlN - 1
                    If tv1.Nodes(i).Checked Then
                        ret.Add(tv1.Nodes(i).Name)
                    End If
                Next
            End If
        Catch ex As Exception
            V_Err($"_getCheckedNodes(): {ex.Message}")
        End Try
        Return ret
    End Function

    Private Sub SaveSelectedDBs(ByVal dbs As List(Of String))
        Try
            If dbs IsNot Nothing AndAlso dbs.Count > 0 Then

                If My.Settings.dbSelected IsNot Nothing Then My.Settings.dbSelected = Nothing
                My.Settings.dbSelected = New System.Collections.Specialized.StringCollection

                For Each s As String In dbs
                    My.Settings.dbSelected.Add(s)
                Next
                If My.Settings.dbSelected IsNot Nothing AndAlso My.Settings.dbSelected.Count > 0 Then
                    My.Settings.Save()
                End If

            End If
        Catch ex As Exception
            V_Err($"SaveSelectedDBs(): {ex.Message}")
        End Try
    End Sub

    Private Sub tsmiClearV_Click(sender As Object, e As EventArgs) Handles tsmiClearV.Click
        rtb.Clear()
    End Sub

    Private Sub f_Main_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Minimized Then
            HideToTray(True)
        End If
    End Sub
End Class
