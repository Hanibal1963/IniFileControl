﻿' ****************************************************************************************************************
' Form1.vb
' © 2024 by Andreas Sauer
' ****************************************************************************************************************
'

Public Class Form1

    Private Sub ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _
        ÖffnenToolStripMenuItem.Click, SpeichernToolStripMenuItem.Click,
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
        Me.IniFile1.LoadFile(ofd.FileName)
    End Sub

    Private Sub SaveFile()
        Me.IniFile1.SaveFile()
    End Sub

    Private Sub SaveFileAs()
        Dim sfd As New SaveFileDialog With {
            .Title = $"INI - Datei speichern unter",
            .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments,
            .Filter = $"INI-Dateien (*.ini)|*.ini",
            .AddExtension = True,
            .CheckFileExists = False,
            .ShowHelp = False}
        Dim result As DialogResult = sfd.ShowDialog(Me)
        If Not result = DialogResult.OK Then Exit Sub
        Me.IniFile1.SaveFile(sfd.FileName)
    End Sub

    Private Sub TextBox_FileComment_TextChanged(sender As Object, e As EventArgs) Handles TextBox_FileComment.TextChanged
        'Button zum übernehmen der Kommentaränderungen aktivieren
        Me.Button_FileCommentChange.Enabled = True
    End Sub

    Private Sub Button_Click(sender As Object, e As EventArgs) Handles _
            Button_FileCommentChange.Click, Button_AddSection.Click,
            Button_RenameSection.Click, Button_DeleteSection.Click
        Select Case True
            Case sender Is Me.Button_FileCommentChange
                'geänderten Dateikommentar übernehmen
                Me.IniFile1.SetFileComment(Me.TextBox_FileComment.Lines)
            Case sender Is Me.Button_AddSection
                'Abschnitt hinzufügen
                Me.AddSection()
            Case sender Is Me.Button_RenameSection
                'Abschnitt umbenennen
                Me.RenameSection()
            Case sender Is Me.Button_DeleteSection
                'Abschnitt löschen
                Me.DeleteSection()
        End Select
    End Sub

    Private Sub DeleteSection()
        Select Case MessageBox.Show(
            $"Wollen Sie den Abschnitt ""{Me.ListBox_Sections.SelectedItem}"" wirklich löschen",
            $"Abschnitt löschen",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question)
            Case DialogResult.Yes
                Me.IniFile1.DeleteSection(Me.ListBox_Sections.SelectedItem.ToString)
            Case DialogResult.No

        End Select
    End Sub

    Private Sub RenameSection()
        Dim newsection As String = InputBox(
        $"Geben Sie den neuen Abschnittsname für ""{Me.ListBox_Sections.SelectedItem}"" ein.",
        $"Abschnitt umbenennen",
        $"neuer Abschnitt")
        Me.IniFile1.RenameSection(Me.ListBox_Sections.SelectedItem.ToString, newsection)
    End Sub

    Private Sub AddSection()
        Dim newsection As String = InputBox(
            $"Geben Sie den neuen Abschnittsname ein",
            $"Abschnitt hinzufügen",
            $"neuer Abschnitt")
        Me.IniFile1.AddSectionName(newsection)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.FillTextBoxFileComments()
        Me.FillListBoxSections()
    End Sub

    Private Sub IniFile1_FileContentChanged(sender As Object, e As EventArgs) Handles IniFile1.FileContentChanged
        Me.FillTextBoxFileComments()
        Me.FillListBoxSections()
    End Sub

    Private Sub IniFile1_FileCommentChanged(sender As Object, e As EventArgs) Handles IniFile1.FileCommentChanged
        Me.FillTextBoxFileComments()
    End Sub

    Private Sub IniFile1_SectionsChanged(sender As Object, e As EventArgs) Handles IniFile1.SectionsChanged
        Me.FillListBoxSections()
    End Sub

    Private Sub IniFile1_SectionNameExist(sender As Object, e As EventArgs) Handles IniFile1.SectionNameExist
        Dim unused = MessageBox.Show(
            $"Der Abschnitt existiert bereits.",
            $"Ein Fehler ist aufgetreten",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error)
    End Sub

    Private Sub FillTextBoxFileComments()
        Me.TextBox_FileComment.Lines = Me.IniFile1.GetFileComment
    End Sub

    Private Sub FillListBoxSections()
        Me.ListBox_Sections.Items.Clear()
        Me.ListBox_Sections.Items.AddRange(Me.IniFile1.GetSectionNames)
        Me.ListBox_Sections.SelectedIndex = -1
        Me.Button_AddSection.Enabled = True
    End Sub

    Private Sub ListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles _
        ListBox_Sections.SelectedIndexChanged
        If CType(sender, ListBox).SelectedIndex <> -1 Then
            Me.Button_RenameSection.Enabled = True
            Me.Button_DeleteSection.Enabled = True
            Me.FillTextBoxSectionComment()
            Me.Button_SectionCommentChange.Enabled = False
        Else
            Me.Button_RenameSection.Enabled = False
            Me.Button_DeleteSection.Enabled = False
            Me.ClearTextBoxSectionComment()
            Me.Button_SectionCommentChange.Enabled = False
        End If
    End Sub

    Private Sub ClearTextBoxSectionComment()
        Me.TextBox_SectionComment.Text = ""
    End Sub

    Private Sub FillTextBoxSectionComment()
        Me.TextBox_SectionComment.Lines = Me.IniFile1.GetSectionComment(Me.ListBox_Sections.SelectedItem.ToString)
    End Sub

End Class
