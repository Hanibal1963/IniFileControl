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

        'DateiKommentar in Textbox übernehmen
        Me.TextBox_FileComment.Lines = IniFile1.Comment

        'Button zum übernehmen der Kommentaränderungen deaktivieren
        Me.Button_FileCommentChange.Enabled = False

    End Sub

    Private Sub IniFile1_FileSaved(sender As Object, e As EventArgs) Handles IniFile1.FileSaved

    End Sub

    Private Sub TextBox_FileComment_TextChanged(sender As Object, e As EventArgs) Handles TextBox_FileComment.TextChanged

        'Button zum übernehmen der Kommentaränderungen aktivieren
        Me.Button_FileCommentChange.Enabled = True

    End Sub

End Class
