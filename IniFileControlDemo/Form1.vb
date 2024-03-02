' ****************************************************************************************************************
' Form1.vb
' © 2024 by Andreas Sauer
' ****************************************************************************************************************
'

Public Class Form1
    Public Sub New()

        ' Dieser Aufruf ist für den Designer erforderlich.
        Me.InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.FillTextBox(Me.TextBox_FileComment)
        Me.FillListBox(Me.ListBox_Sections)
    End Sub

    Private Sub ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _
        ToolStripMenuItem_Oeffnen.Click, ToolStripMenuItem_Speichern.Click,
        ToolStripMenuItem_SpeichernUnter.Click, ToolStripMenuItem_Beenden.Click

        'welcher Menüpunkt wurde geklickt?
        Select Case True
            Case sender Is Me.ToolStripMenuItem_Oeffnen
                'Datei öffnen
                Me.OpenFile()

            Case sender Is Me.ToolStripMenuItem_Speichern
                'Datei speichern
                Me.SaveFile()

            Case sender Is Me.ToolStripMenuItem_SpeichernUnter
                'Datei speichern unter ...
                Me.SaveFileAs()

            Case sender Is Me.ToolStripMenuItem_Beenden
                'Programm beenden
                Me.Close()

        End Select
    End Sub

    Private Sub Button_Click(sender As Object, e As EventArgs) Handles _
            Button_FileCommentChange.Click, Button_AddSection.Click,
            Button_RenameSection.Click, Button_DeleteSection.Click,
            Button_SectionCommentChange.Click, Button_AddEntry.Click,
            Button_RenameEntry.Click, Button_DeleteEntry.Click

        'Welcher Button wurde geklickt?
        Select Case True
            Case sender Is Me.Button_FileCommentChange
                'geänderten Dateikommentar übernehmen
                Me.SetFileComment()

            Case sender Is Me.Button_AddSection
                'Abschnitt hinzufügen
                Me.AddSection()

            Case sender Is Me.Button_RenameSection
                'Abschnitt umbenennen
                Me.RenameSection()

            Case sender Is Me.Button_DeleteSection
                'Abschnitt löschen
                Me.DeleteSection()

            Case sender Is Me.Button_SectionCommentChange
                'geänderten Abschnittskommentar übernehmen
                Me.SetSectionComment()

            Case sender Is Me.Button_AddEntry
                'Eintrag hinzufügen
                Me.AddEnty()

            Case sender Is Me.Button_RenameEntry
                'Eintrag umbenennen
                Me.RenameEntry()

            Case sender Is Me.Button_DeleteEntry
                'Eintrag löschen
                Me.DeleteEnty()

        End Select

    End Sub

    Private Sub DeleteEnty()
        Select Case MessageBox.Show(
            $"Wollen Sie den Eintrag ""{Me.ListBox_Entrys.SelectedItem}"" wirklich löschen",
            $"Eintrag löschen",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question)
            Case DialogResult.Yes
                Me.IniFile1.DeleteEntry(Me.ListBox_Sections.SelectedItem.ToString, Me.ListBox_Entrys.SelectedItem)
            Case DialogResult.No

        End Select
    End Sub

    Private Sub RenameEntry()
        Dim newentry As String = InputBox(
        $"Geben Sie den neuen Eintragsname für ""{Me.ListBox_Entrys.SelectedItem}"" ein.",
        $"Eintrag umbenennen",
        $"neuer Eintrag")
        Me.IniFile1.RenameEntry(Me.ListBox_Sections.SelectedItem.ToString, newentry)
    End Sub

    Private Sub AddEnty()
        Dim newentry As String = InputBox(
            $"Geben Sie den neuen Eintragsname ein",
            $"Eintrag hinzufügen",
            $"neuer Eintrag")
        Me.IniFile1.AddEntry(Me.ListBox_Sections.SelectedItem.ToString, newentry)
    End Sub

    Private Sub SetSectionComment()

        'Den Text aus der Textbox in den in der Listbox ausgewählten Abschnitt übenehmen 
        Me.IniFile1.SetSectionComment(
            Me.ListBox_Sections.SelectedItem.ToString,
            Me.TextBox_SectionComment.Lines)

    End Sub

    Private Sub SetFileComment()

        'Den Text aus der Textbox übergeben
        Me.IniFile1.SetFileComment(Me.TextBox_FileComment.Lines)

    End Sub

    Private Sub FillTextBox(ByRef TextBox As TextBox)

        'Welche Textbox soll befüllt werden?
        Select Case True
            Case TextBox Is Me.TextBox_FileComment
                'Textbox für Dateikommentar befüllen
                Me.TextBox_FileComment.Lines = Me.IniFile1.GetFileComment
                Me.Button_FileCommentChange.Enabled = False

            Case TextBox Is Me.TextBox_SectionComment
                'Textbox für Abschnittskommentar befüllen
                Me.TextBox_SectionComment.Lines = Me.IniFile1.GetSectionComment(Me.ListBox_Sections.SelectedItem.ToString)
                Me.Button_SectionCommentChange.Enabled = False

        End Select

    End Sub

    Private Sub FillListBox(ByRef Listbox As ListBox)

        'Einträge der Listbox löschen
        Listbox.Items.Clear()

        'Welche Listbox soll befüllt werden?
        Select Case True
            Case Listbox Is Me.ListBox_Sections
                'Listbox für Abschnittsnamen befüllen
                Listbox.Items.AddRange(
                    Me.IniFile1.GetSectionNames)
                'Button zum hinzufügen eines Abschnitts aktivieren
                Me.Button_AddSection.Enabled = True

            Case Listbox Is Me.ListBox_Entrys
                'Listbox für Einträge befüllen
                Listbox.Items.AddRange(
                    Me.IniFile1.GetEntryNames(
                    Me.ListBox_Sections.SelectedItem.ToString))
                'Button zum hinzufügen eines Eintrags aktivieren
                Me.Button_AddEntry.Enabled = True

        End Select

        'Markierung in der Listbox löschen
        Listbox.SelectedIndex = -1

    End Sub

    Private Sub TextBox_TextChanged(sender As Object, e As EventArgs) Handles _
        TextBox_FileComment.TextChanged, TextBox_SectionComment.TextChanged

        'In welcher Textbox hat sich der Inhalt geändert?
        Select Case True
            Case sender Is Me.TextBox_FileComment
                'Button zum übernehmen der Dateikommentaränderungen aktivieren
                Me.Button_FileCommentChange.Enabled = True

            Case sender Is Me.TextBox_SectionComment
                'Button zum übernehmen der Abschnittskommentaränderungen aktivieren
                Me.Button_SectionCommentChange.Enabled = True

        End Select

    End Sub

    Private Sub ListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles _
        ListBox_Sections.SelectedIndexChanged, ListBox_Entrys.SelectedIndexChanged

        'Index merken
        Dim index As Integer = CType(sender, ListBox).SelectedIndex

        'In welcher Listbox hat sich der Index geändert?
        Select Case True
            Case sender Is Me.ListBox_Sections
                'Index des ausgewähten Abschnitts 
                If index <> -1 Then
                    'Abschnitt ausgewählt ->
                    'Abschnittskommentar laden und Buttons aktivieren
                    Me.FillTextBox(Me.TextBox_SectionComment)
                    Me.Button_RenameSection.Enabled = True
                    Me.Button_DeleteSection.Enabled = True

                    'Eintragsliste laden und Buttons aktivieren
                    Me.FillListBox(Me.ListBox_Entrys)
                    Me.Button_RenameEntry.Enabled = True
                    Me.Button_DeleteEntry.Enabled = True

                Else
                    'kein Abschnitt ausgewählt ->
                    'Abschnittskommentar löschen und Buttons deaktivieren
                    Me.TextBox_SectionComment.Text = ""
                    Me.Button_SectionCommentChange.Enabled = False
                    Me.Button_RenameSection.Enabled = False
                    Me.Button_DeleteSection.Enabled = False

                    'Eintragsliste löschen und Buttons deaktivieren
                    Me.ListBox_Entrys.Items.Clear()
                    Me.Button_AddEntry.Enabled = False
                    Me.Button_RenameEntry.Enabled = False
                    Me.Button_DeleteEntry.Enabled = False

                End If

            Case sender Is Me.ListBox_Entrys
                'Index des ausgewähten Eintrags
                If index <> -1 Then
                    'Abschnitt ausgewählt

                Else
                    'kein Abschnitt ausgewählt

                End If

        End Select

    End Sub

    Private Sub IniFile1_FileContentChanged(sender As Object, e As EventArgs) Handles IniFile1.FileContentChanged
        Me.FillTextBox(Me.TextBox_FileComment)
        Me.FillListBox(Me.ListBox_Sections)
    End Sub

    Private Sub IniFile1_FileCommentChanged(sender As Object, e As EventArgs) Handles IniFile1.FileCommentChanged
        Me.FillTextBox(Me.TextBox_FileComment)
    End Sub

    Private Sub IniFile1_SectionsChanged(sender As Object, e As EventArgs) Handles IniFile1.SectionsChanged
        Me.FillListBox(Me.ListBox_Sections)
    End Sub

    Private Sub IniFile1_EntrysChanged(sender As Object, e As EventArgs) Handles IniFile1.EntrysChanged
        Me.FillListBox(Me.ListBox_Entrys)
    End Sub

    Private Sub IniFile1_SectionNameExist(sender As Object, e As EventArgs) Handles IniFile1.SectionNameExist
        Dim unused = MessageBox.Show(
            $"Der Abschnitt existiert bereits.",
            $"Ein Fehler ist aufgetreten",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error)
    End Sub

    Private Sub IniFile1_SectionCommentChanged(sender As Object, e As EventArgs) Handles IniFile1.SectionCommentChanged
        Me.FillTextBox(Me.TextBox_SectionComment)
    End Sub

    Private Sub IniFile1_EntrynameExist(sender As Object, e As EventArgs) Handles IniFile1.EntrynameExist
        Dim unused = MessageBox.Show(
            $"Der Eintrag existiert bereits.",
            $"Ein Fehler ist aufgetreten",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error)
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

End Class
