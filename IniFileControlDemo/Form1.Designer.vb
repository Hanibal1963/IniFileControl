<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim MenuStrip_HauptMenu As System.Windows.Forms.MenuStrip
        Dim ToolStripMenuItem_Datei As System.Windows.Forms.ToolStripMenuItem
        Dim ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
        Dim ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
        Dim GroupBox_FileComment As System.Windows.Forms.GroupBox
        Dim GroupBox_Sections As System.Windows.Forms.GroupBox
        Dim GroupBox_SectionComment As System.Windows.Forms.GroupBox
        Dim GroupBox_Entrys As System.Windows.Forms.GroupBox
        Me.ToolStripMenuItem_Oeffnen = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem_Speichern = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem_SpeichernUnter = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem_Beenden = New System.Windows.Forms.ToolStripMenuItem()
        Me.Button_FileCommentChange = New System.Windows.Forms.Button()
        Me.TextBox_FileComment = New System.Windows.Forms.TextBox()
        Me.Button_DeleteSection = New System.Windows.Forms.Button()
        Me.Button_RenameSection = New System.Windows.Forms.Button()
        Me.Button_AddSection = New System.Windows.Forms.Button()
        Me.ListBox_Sections = New System.Windows.Forms.ListBox()
        Me.Button_SectionCommentChange = New System.Windows.Forms.Button()
        Me.TextBox_SectionComment = New System.Windows.Forms.TextBox()
        Me.Button_DeleteEntry = New System.Windows.Forms.Button()
        Me.Button_RenameEntry = New System.Windows.Forms.Button()
        Me.Button_AddEntry = New System.Windows.Forms.Button()
        Me.ListBox_Entrys = New System.Windows.Forms.ListBox()
        Me.IniFile1 = New SchlumpfSoft.Controls.IniFileControl.IniFile()
        MenuStrip_HauptMenu = New System.Windows.Forms.MenuStrip()
        ToolStripMenuItem_Datei = New System.Windows.Forms.ToolStripMenuItem()
        ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        GroupBox_FileComment = New System.Windows.Forms.GroupBox()
        GroupBox_Sections = New System.Windows.Forms.GroupBox()
        GroupBox_SectionComment = New System.Windows.Forms.GroupBox()
        GroupBox_Entrys = New System.Windows.Forms.GroupBox()
        MenuStrip_HauptMenu.SuspendLayout()
        GroupBox_FileComment.SuspendLayout()
        GroupBox_Sections.SuspendLayout()
        GroupBox_SectionComment.SuspendLayout()
        GroupBox_Entrys.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip_HauptMenu
        '
        MenuStrip_HauptMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {ToolStripMenuItem_Datei})
        MenuStrip_HauptMenu.Location = New System.Drawing.Point(0, 0)
        MenuStrip_HauptMenu.Name = "MenuStrip_HauptMenu"
        MenuStrip_HauptMenu.Size = New System.Drawing.Size(669, 24)
        MenuStrip_HauptMenu.TabIndex = 0
        '
        'ToolStripMenuItem_Datei
        '
        ToolStripMenuItem_Datei.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem_Oeffnen, ToolStripSeparator1, Me.ToolStripMenuItem_Speichern, Me.ToolStripMenuItem_SpeichernUnter, ToolStripSeparator2, Me.ToolStripMenuItem_Beenden})
        ToolStripMenuItem_Datei.Name = "ToolStripMenuItem_Datei"
        ToolStripMenuItem_Datei.Size = New System.Drawing.Size(46, 20)
        ToolStripMenuItem_Datei.Text = "Datei"
        '
        'ToolStripMenuItem_Oeffnen
        '
        Me.ToolStripMenuItem_Oeffnen.Name = "ToolStripMenuItem_Oeffnen"
        Me.ToolStripMenuItem_Oeffnen.Size = New System.Drawing.Size(169, 22)
        Me.ToolStripMenuItem_Oeffnen.Text = "Öffnen ..."
        '
        'ToolStripSeparator1
        '
        ToolStripSeparator1.Name = "ToolStripSeparator1"
        ToolStripSeparator1.Size = New System.Drawing.Size(166, 6)
        '
        'ToolStripMenuItem_Speichern
        '
        Me.ToolStripMenuItem_Speichern.Name = "ToolStripMenuItem_Speichern"
        Me.ToolStripMenuItem_Speichern.Size = New System.Drawing.Size(169, 22)
        Me.ToolStripMenuItem_Speichern.Text = "Speichern"
        '
        'ToolStripMenuItem_SpeichernUnter
        '
        Me.ToolStripMenuItem_SpeichernUnter.Name = "ToolStripMenuItem_SpeichernUnter"
        Me.ToolStripMenuItem_SpeichernUnter.Size = New System.Drawing.Size(169, 22)
        Me.ToolStripMenuItem_SpeichernUnter.Text = "Speichern unter ..."
        '
        'ToolStripSeparator2
        '
        ToolStripSeparator2.Name = "ToolStripSeparator2"
        ToolStripSeparator2.Size = New System.Drawing.Size(166, 6)
        '
        'ToolStripMenuItem_Beenden
        '
        Me.ToolStripMenuItem_Beenden.Name = "ToolStripMenuItem_Beenden"
        Me.ToolStripMenuItem_Beenden.Size = New System.Drawing.Size(169, 22)
        Me.ToolStripMenuItem_Beenden.Text = "Beenden"
        '
        'GroupBox_FileComment
        '
        GroupBox_FileComment.Controls.Add(Me.Button_FileCommentChange)
        GroupBox_FileComment.Controls.Add(Me.TextBox_FileComment)
        GroupBox_FileComment.Location = New System.Drawing.Point(8, 32)
        GroupBox_FileComment.Name = "GroupBox_FileComment"
        GroupBox_FileComment.Size = New System.Drawing.Size(325, 164)
        GroupBox_FileComment.TabIndex = 1
        GroupBox_FileComment.TabStop = False
        GroupBox_FileComment.Text = "Dateikommentar"
        '
        'Button_FileCommentChange
        '
        Me.Button_FileCommentChange.Enabled = False
        Me.Button_FileCommentChange.Location = New System.Drawing.Point(228, 134)
        Me.Button_FileCommentChange.Name = "Button_FileCommentChange"
        Me.Button_FileCommentChange.Size = New System.Drawing.Size(84, 24)
        Me.Button_FileCommentChange.TabIndex = 1
        Me.Button_FileCommentChange.Text = "übernehmen"
        Me.Button_FileCommentChange.UseVisualStyleBackColor = True
        '
        'TextBox_FileComment
        '
        Me.TextBox_FileComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox_FileComment.Location = New System.Drawing.Point(8, 20)
        Me.TextBox_FileComment.Multiline = True
        Me.TextBox_FileComment.Name = "TextBox_FileComment"
        Me.TextBox_FileComment.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBox_FileComment.Size = New System.Drawing.Size(304, 112)
        Me.TextBox_FileComment.TabIndex = 0
        Me.TextBox_FileComment.WordWrap = False
        '
        'GroupBox_Sections
        '
        GroupBox_Sections.Controls.Add(Me.Button_DeleteSection)
        GroupBox_Sections.Controls.Add(Me.Button_RenameSection)
        GroupBox_Sections.Controls.Add(Me.Button_AddSection)
        GroupBox_Sections.Controls.Add(Me.ListBox_Sections)
        GroupBox_Sections.Location = New System.Drawing.Point(12, 204)
        GroupBox_Sections.Name = "GroupBox_Sections"
        GroupBox_Sections.Size = New System.Drawing.Size(321, 208)
        GroupBox_Sections.TabIndex = 2
        GroupBox_Sections.TabStop = False
        GroupBox_Sections.Text = "Abschnittsliste"
        '
        'Button_DeleteSection
        '
        Me.Button_DeleteSection.Enabled = False
        Me.Button_DeleteSection.Location = New System.Drawing.Point(212, 176)
        Me.Button_DeleteSection.Name = "Button_DeleteSection"
        Me.Button_DeleteSection.Size = New System.Drawing.Size(96, 24)
        Me.Button_DeleteSection.TabIndex = 3
        Me.Button_DeleteSection.Text = "löschen"
        Me.Button_DeleteSection.UseVisualStyleBackColor = True
        '
        'Button_RenameSection
        '
        Me.Button_RenameSection.Enabled = False
        Me.Button_RenameSection.Location = New System.Drawing.Point(110, 176)
        Me.Button_RenameSection.Name = "Button_RenameSection"
        Me.Button_RenameSection.Size = New System.Drawing.Size(96, 24)
        Me.Button_RenameSection.TabIndex = 2
        Me.Button_RenameSection.Text = "umbenennen"
        Me.Button_RenameSection.UseVisualStyleBackColor = True
        '
        'Button_AddSection
        '
        Me.Button_AddSection.Enabled = False
        Me.Button_AddSection.Location = New System.Drawing.Point(8, 176)
        Me.Button_AddSection.Name = "Button_AddSection"
        Me.Button_AddSection.Size = New System.Drawing.Size(96, 24)
        Me.Button_AddSection.TabIndex = 1
        Me.Button_AddSection.Text = "hinzufügen"
        Me.Button_AddSection.UseVisualStyleBackColor = True
        '
        'ListBox_Sections
        '
        Me.ListBox_Sections.FormattingEnabled = True
        Me.ListBox_Sections.Location = New System.Drawing.Point(8, 20)
        Me.ListBox_Sections.Name = "ListBox_Sections"
        Me.ListBox_Sections.Size = New System.Drawing.Size(300, 147)
        Me.ListBox_Sections.TabIndex = 0
        '
        'GroupBox_SectionComment
        '
        GroupBox_SectionComment.Controls.Add(Me.Button_SectionCommentChange)
        GroupBox_SectionComment.Controls.Add(Me.TextBox_SectionComment)
        GroupBox_SectionComment.Location = New System.Drawing.Point(347, 32)
        GroupBox_SectionComment.Name = "GroupBox_SectionComment"
        GroupBox_SectionComment.Size = New System.Drawing.Size(308, 164)
        GroupBox_SectionComment.TabIndex = 3
        GroupBox_SectionComment.TabStop = False
        GroupBox_SectionComment.Text = "Abschnittskommentar"
        '
        'Button_SectionCommentChange
        '
        Me.Button_SectionCommentChange.Enabled = False
        Me.Button_SectionCommentChange.Location = New System.Drawing.Point(216, 134)
        Me.Button_SectionCommentChange.Name = "Button_SectionCommentChange"
        Me.Button_SectionCommentChange.Size = New System.Drawing.Size(84, 24)
        Me.Button_SectionCommentChange.TabIndex = 4
        Me.Button_SectionCommentChange.Text = "übernehmen"
        Me.Button_SectionCommentChange.UseVisualStyleBackColor = True
        '
        'TextBox_SectionComment
        '
        Me.TextBox_SectionComment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox_SectionComment.Location = New System.Drawing.Point(8, 20)
        Me.TextBox_SectionComment.Multiline = True
        Me.TextBox_SectionComment.Name = "TextBox_SectionComment"
        Me.TextBox_SectionComment.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBox_SectionComment.Size = New System.Drawing.Size(292, 112)
        Me.TextBox_SectionComment.TabIndex = 0
        Me.TextBox_SectionComment.WordWrap = False
        '
        'GroupBox_Entrys
        '
        GroupBox_Entrys.Controls.Add(Me.Button_DeleteEntry)
        GroupBox_Entrys.Controls.Add(Me.Button_RenameEntry)
        GroupBox_Entrys.Controls.Add(Me.Button_AddEntry)
        GroupBox_Entrys.Controls.Add(Me.ListBox_Entrys)
        GroupBox_Entrys.Location = New System.Drawing.Point(339, 204)
        GroupBox_Entrys.Name = "GroupBox_Entrys"
        GroupBox_Entrys.Size = New System.Drawing.Size(316, 208)
        GroupBox_Entrys.TabIndex = 4
        GroupBox_Entrys.TabStop = False
        GroupBox_Entrys.Text = "Eintragsliste"
        '
        'Button_DeleteEntry
        '
        Me.Button_DeleteEntry.Enabled = False
        Me.Button_DeleteEntry.Location = New System.Drawing.Point(212, 176)
        Me.Button_DeleteEntry.Name = "Button_DeleteEntry"
        Me.Button_DeleteEntry.Size = New System.Drawing.Size(96, 24)
        Me.Button_DeleteEntry.TabIndex = 3
        Me.Button_DeleteEntry.Text = "löschen"
        Me.Button_DeleteEntry.UseVisualStyleBackColor = True
        '
        'Button_RenameEntry
        '
        Me.Button_RenameEntry.Enabled = False
        Me.Button_RenameEntry.Location = New System.Drawing.Point(110, 176)
        Me.Button_RenameEntry.Name = "Button_RenameEntry"
        Me.Button_RenameEntry.Size = New System.Drawing.Size(96, 24)
        Me.Button_RenameEntry.TabIndex = 2
        Me.Button_RenameEntry.Text = "umbenennen"
        Me.Button_RenameEntry.UseVisualStyleBackColor = True
        '
        'Button_AddEntry
        '
        Me.Button_AddEntry.Enabled = False
        Me.Button_AddEntry.Location = New System.Drawing.Point(8, 176)
        Me.Button_AddEntry.Name = "Button_AddEntry"
        Me.Button_AddEntry.Size = New System.Drawing.Size(96, 24)
        Me.Button_AddEntry.TabIndex = 1
        Me.Button_AddEntry.Text = "hinzufügen"
        Me.Button_AddEntry.UseVisualStyleBackColor = True
        '
        'ListBox_Entrys
        '
        Me.ListBox_Entrys.FormattingEnabled = True
        Me.ListBox_Entrys.Location = New System.Drawing.Point(8, 19)
        Me.ListBox_Entrys.Name = "ListBox_Entrys"
        Me.ListBox_Entrys.Size = New System.Drawing.Size(300, 147)
        Me.ListBox_Entrys.TabIndex = 0
        '
        'IniFile1
        '
        Me.IniFile1.AutoSave = True
        Me.IniFile1.CommentPrefix = Global.Microsoft.VisualBasic.ChrW(59)
        Me.IniFile1.FilePath = "D:\Dokumente\NeueDatei.ini"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(669, 426)
        Me.Controls.Add(GroupBox_Entrys)
        Me.Controls.Add(GroupBox_SectionComment)
        Me.Controls.Add(GroupBox_Sections)
        Me.Controls.Add(GroupBox_FileComment)
        Me.Controls.Add(MenuStrip_HauptMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MainMenuStrip = MenuStrip_HauptMenu
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.Text = "Form1"
        MenuStrip_HauptMenu.ResumeLayout(False)
        MenuStrip_HauptMenu.PerformLayout()
        GroupBox_FileComment.ResumeLayout(False)
        GroupBox_FileComment.PerformLayout()
        GroupBox_Sections.ResumeLayout(False)
        GroupBox_SectionComment.ResumeLayout(False)
        GroupBox_SectionComment.PerformLayout()
        GroupBox_Entrys.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents Button_FileCommentChange As Button
    Private WithEvents TextBox_FileComment As TextBox
    Private WithEvents ListBox_Sections As ListBox
    Private WithEvents Button_DeleteSection As Button
    Private WithEvents Button_RenameSection As Button
    Private WithEvents Button_AddSection As Button
    Private WithEvents Button_SectionCommentChange As Button
    Private WithEvents TextBox_SectionComment As TextBox
    Private WithEvents IniFile1 As SchlumpfSoft.Controls.IniFileControl.IniFile
    Private WithEvents ListBox_Entrys As ListBox
    Private WithEvents ToolStripMenuItem_Oeffnen As ToolStripMenuItem
    Private WithEvents ToolStripMenuItem_Speichern As ToolStripMenuItem
    Private WithEvents ToolStripMenuItem_SpeichernUnter As ToolStripMenuItem
    Private WithEvents ToolStripMenuItem_Beenden As ToolStripMenuItem
    Private WithEvents Button_DeleteEntry As Button
    Private WithEvents Button_RenameEntry As Button
    Private WithEvents Button_AddEntry As Button
End Class
