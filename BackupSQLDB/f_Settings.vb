Public Class f_Settings

    Private Sub tsmi__Click(sender As Object, e As EventArgs) Handles tsmiSave.Click, tsmiRefresh.Click, tsmiReset.Click, tsmiClose.Click
        Try
            Select Case CType(sender, ToolStripMenuItem).Name
                Case tsmiSave.Name
                    My.Settings.Save()
                    MsgBox("Settings successfully updated.", vbApplicationModal + vbInformation, "Save")

                Case tsmiRefresh.Name
                    My.Settings.Reload()

                Case tsmiReset.Name
                    If MsgBox("Are you sure you want to reset to default settings?", vbApplicationModal + vbQuestion + vbYesNo, "Defaults") = vbYes Then
                        My.Settings.Reset()
                    End If

                Case tsmiClose.Name
                    Close()
            End Select
        Catch ex As Exception
            MsgBox(ex.Message, vbApplicationModal + vbExclamation, "Error")
        End Try
    End Sub

End Class