Option Explicit On
Module m_IO

    Public Function _SelectFolder(Optional ByVal StartFolder As String = "") As String
        Dim DirName As String = ""

        If String.IsNullOrWhiteSpace(StartFolder) Then StartFolder = Application.StartupPath

        Using objDir As New FolderBrowserDialog
            With objDir
                .Description = "Please select the folder"
                If Not String.IsNullOrWhiteSpace(StartFolder) Then
                    If IO.Directory.Exists(StartFolder) Then
                        .SelectedPath = StartFolder
                    Else
                        .RootFolder = Environment.SpecialFolder.MyComputer
                    End If
                End If
                .ShowNewFolderButton = True
                If .ShowDialog = Windows.Forms.DialogResult.OK Then DirName = .SelectedPath
            End With
        End Using

        Return DirName
    End Function

    Public Sub _ExploreFolder(ByVal TargetFolder As String)
        Try
            If IO.Directory.Exists(TargetFolder) Then
                Shell("explorer /e," & TargetFolder, AppWinStyle.NormalFocus)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, vbApplicationModal + vbExclamation, "Error")
        End Try
    End Sub

End Module
