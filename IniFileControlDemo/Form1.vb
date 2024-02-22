Public Class Form1

    Private Sub ToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        Handles ÖffnenToolStripMenuItem.Click, SpeichernToolStripMenuItem.Click,
                SpeichernUnterToolStripMenuItem.Click, BeendenToolStripMenuItem.Click

        Select Case True
            Case sender Is Me.ÖffnenToolStripMenuItem : Me.OpenFile()
            Case sender Is Me.SpeichernToolStripMenuItem : Me.SaveFile()
            Case sender Is Me.SpeichernUnterToolStripMenuItem : Me.SaveFileAs()
            Case sender Is Me.BeendenToolStripMenuItem : Me.Close()
        End Select

    End Sub

    Private Sub OpenFile()

        Dim ofd As New OpenFileDialog With {
            .Title = $"INI - Datei öffnen",
            .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments,
            .Filter = $"INI-Dateien (*.ini)|*.ini",
            .AddExtension = True,
            .CheckFileExists = True,
            .Multiselect = False,
            .ShowHelp = False}

        Dim result As DialogResult = ofd.ShowDialog(Me)

        If Not result = DialogResult.OK Then Exit Sub


    End Sub

    Private Sub SaveFile()

    End Sub

    Private Sub SaveFileAs()

    End Sub

    Private Sub TextBox_FileComment_TextChanged(sender As Object, e As EventArgs) Handles TextBox_FileComment.TextChanged

        'TODO: Button zum übernehmen der Kommentaränderungen aktivieren
        Me.Button_FileCommentChange.Enabled = True

    End Sub


    Private Sub Button_FileCommentChange_Click(sender As Object, e As EventArgs) Handles Button_FileCommentChange.Click

        'TODO: geänderten Dateikommentar übernehmen

    End Sub

End Class
