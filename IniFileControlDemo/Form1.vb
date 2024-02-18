Public Class Form1

    Private Sub ÖffnenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ÖffnenToolStripMenuItem.Click

        Dim ofd As New OpenFileDialog With {
            .Title = $"INI - Datei öffnen",
            .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments,
            .Filter = $"INI-Dateien (*.ini)|*.ini",
            .AddExtension = True,
            .CheckFileExists = False,
            .Multiselect = False,
            .ShowHelp = False}

        Dim result As DialogResult = ofd.ShowDialog(Me)

        If Not result = DialogResult.OK Then Exit Sub

        Me.IniFile1.FilePath = ofd.FileName

    End Sub

    Private Sub BeendenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BeendenToolStripMenuItem.Click

        Me.Close()

    End Sub

    Private Sub IniFile1_FileCommentChanged(sender As Object, e As EventArgs) Handles IniFile1.FileCommentChanged

        'Dateikommentar in die Textbox übernehmen
        Me.TextBox_FileComment.Lines = Me.IniFile1.Comment

        'Button zum übernehmen des geänderten Kommentars deaktivieren
        Me.Button_FileCommentChange.Enabled = False

    End Sub

    Private Sub IniFile1_FileSaved(sender As Object, e As EventArgs) Handles IniFile1.FileSaved

    End Sub

    Private Sub TextBox_FileComment_TextChanged(sender As Object, e As EventArgs) Handles TextBox_FileComment.TextChanged

        'Button zum übernehmen der Kommentaränderungen aktivieren
        Me.Button_FileCommentChange.Enabled = True

    End Sub

    Private Sub IniFile1_FileContentChanged(sender As Object, e As EventArgs) Handles IniFile1.FileContentChanged

        'Dateiinhalt anzeigen
        Me.TextBox_FileContent.Lines = Me.IniFile1.FileContent

    End Sub

    Private Sub Button_FileCommentChange_Click(sender As Object, e As EventArgs) Handles Button_FileCommentChange.Click

        'geänderten Dateikommentar übernehmen
        Me.IniFile1.SetFileComment(Me.TextBox_FileComment.Lines)

    End Sub

End Class
