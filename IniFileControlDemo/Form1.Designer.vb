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
        Me.MenuStrip_HauptMenu = New System.Windows.Forms.MenuStrip()
        Me.DateiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ÖffnenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.SpeichernToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SpeichernUnterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.BeendenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox_FileComment = New System.Windows.Forms.GroupBox()
        Me.Button_FileCommentChange = New System.Windows.Forms.Button()
        Me.TextBox_FileComment = New System.Windows.Forms.TextBox()
        Me.GroupBox_Sections = New System.Windows.Forms.GroupBox()
        Me.Button_DeleteSection = New System.Windows.Forms.Button()
        Me.Button_RenameSection = New System.Windows.Forms.Button()
        Me.Button_AddSection = New System.Windows.Forms.Button()
        Me.ListBox_Sections = New System.Windows.Forms.ListBox()
        Me.IniFile1 = New SchlumpfSoft.Controls.IniFileControl.IniFile()
        Me.MenuStrip_HauptMenu.SuspendLayout()
        Me.GroupBox_FileComment.SuspendLayout()
        Me.GroupBox_Sections.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip_HauptMenu
        '
        Me.MenuStrip_HauptMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DateiToolStripMenuItem})
        Me.MenuStrip_HauptMenu.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip_HauptMenu.Name = "MenuStrip_HauptMenu"
        Me.MenuStrip_HauptMenu.Size = New System.Drawing.Size(612, 24)
        Me.MenuStrip_HauptMenu.TabIndex = 0
        '
        'DateiToolStripMenuItem
        '
        Me.DateiToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ÖffnenToolStripMenuItem, Me.ToolStripSeparator1, Me.SpeichernToolStripMenuItem, Me.SpeichernUnterToolStripMenuItem, Me.ToolStripSeparator2, Me.BeendenToolStripMenuItem})
        Me.DateiToolStripMenuItem.Name = "DateiToolStripMenuItem"
        Me.DateiToolStripMenuItem.Size = New System.Drawing.Size(46, 20)
        Me.DateiToolStripMenuItem.Text = "Datei"
        '
        'ÖffnenToolStripMenuItem
        '
        Me.ÖffnenToolStripMenuItem.Name = "ÖffnenToolStripMenuItem"
        Me.ÖffnenToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.ÖffnenToolStripMenuItem.Text = "Öffnen ..."
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(166, 6)
        '
        'SpeichernToolStripMenuItem
        '
        Me.SpeichernToolStripMenuItem.Name = "SpeichernToolStripMenuItem"
        Me.SpeichernToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.SpeichernToolStripMenuItem.Text = "Speichern"
        '
        'SpeichernUnterToolStripMenuItem
        '
        Me.SpeichernUnterToolStripMenuItem.Name = "SpeichernUnterToolStripMenuItem"
        Me.SpeichernUnterToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.SpeichernUnterToolStripMenuItem.Text = "Speichern unter ..."
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(166, 6)
        '
        'BeendenToolStripMenuItem
        '
        Me.BeendenToolStripMenuItem.Name = "BeendenToolStripMenuItem"
        Me.BeendenToolStripMenuItem.Size = New System.Drawing.Size(169, 22)
        Me.BeendenToolStripMenuItem.Text = "Beenden"
        '
        'GroupBox_FileComment
        '
        Me.GroupBox_FileComment.Controls.Add(Me.Button_FileCommentChange)
        Me.GroupBox_FileComment.Controls.Add(Me.TextBox_FileComment)
        Me.GroupBox_FileComment.Location = New System.Drawing.Point(8, 32)
        Me.GroupBox_FileComment.Name = "GroupBox_FileComment"
        Me.GroupBox_FileComment.Size = New System.Drawing.Size(312, 164)
        Me.GroupBox_FileComment.TabIndex = 1
        Me.GroupBox_FileComment.TabStop = False
        Me.GroupBox_FileComment.Text = "Dateikommentar"
        '
        'Button_FileCommentChange
        '
        Me.Button_FileCommentChange.Enabled = False
        Me.Button_FileCommentChange.Location = New System.Drawing.Point(220, 136)
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
        Me.TextBox_FileComment.Size = New System.Drawing.Size(296, 112)
        Me.TextBox_FileComment.TabIndex = 0
        Me.TextBox_FileComment.WordWrap = False
        '
        'GroupBox_Sections
        '
        Me.GroupBox_Sections.Controls.Add(Me.Button_DeleteSection)
        Me.GroupBox_Sections.Controls.Add(Me.Button_RenameSection)
        Me.GroupBox_Sections.Controls.Add(Me.Button_AddSection)
        Me.GroupBox_Sections.Controls.Add(Me.ListBox_Sections)
        Me.GroupBox_Sections.Location = New System.Drawing.Point(12, 204)
        Me.GroupBox_Sections.Name = "GroupBox_Sections"
        Me.GroupBox_Sections.Size = New System.Drawing.Size(308, 196)
        Me.GroupBox_Sections.TabIndex = 2
        Me.GroupBox_Sections.TabStop = False
        Me.GroupBox_Sections.Text = "Abschnittsliste"
        '
        'Button_DeleteSection
        '
        Me.Button_DeleteSection.Enabled = False
        Me.Button_DeleteSection.Location = New System.Drawing.Point(208, 164)
        Me.Button_DeleteSection.Name = "Button_DeleteSection"
        Me.Button_DeleteSection.Size = New System.Drawing.Size(96, 24)
        Me.Button_DeleteSection.TabIndex = 3
        Me.Button_DeleteSection.Text = "löschen"
        Me.Button_DeleteSection.UseVisualStyleBackColor = True
        '
        'Button_RenameSection
        '
        Me.Button_RenameSection.Enabled = False
        Me.Button_RenameSection.Location = New System.Drawing.Point(108, 164)
        Me.Button_RenameSection.Name = "Button_RenameSection"
        Me.Button_RenameSection.Size = New System.Drawing.Size(96, 24)
        Me.Button_RenameSection.TabIndex = 2
        Me.Button_RenameSection.Text = "umbenennen"
        Me.Button_RenameSection.UseVisualStyleBackColor = True
        '
        'Button_AddSection
        '
        Me.Button_AddSection.Enabled = False
        Me.Button_AddSection.Location = New System.Drawing.Point(8, 164)
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
        Me.ListBox_Sections.Size = New System.Drawing.Size(296, 134)
        Me.ListBox_Sections.TabIndex = 0
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
        Me.ClientSize = New System.Drawing.Size(612, 408)
        Me.Controls.Add(Me.GroupBox_Sections)
        Me.Controls.Add(Me.GroupBox_FileComment)
        Me.Controls.Add(Me.MenuStrip_HauptMenu)
        Me.MainMenuStrip = Me.MenuStrip_HauptMenu
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.MenuStrip_HauptMenu.ResumeLayout(False)
        Me.MenuStrip_HauptMenu.PerformLayout()
        Me.GroupBox_FileComment.ResumeLayout(False)
        Me.GroupBox_FileComment.PerformLayout()
        Me.GroupBox_Sections.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents MenuStrip_HauptMenu As MenuStrip
    Friend WithEvents DateiToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ÖffnenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BeendenToolStripMenuItem As ToolStripMenuItem
    Private WithEvents GroupBox_FileComment As GroupBox
    Private WithEvents Button_FileCommentChange As Button
    Private WithEvents TextBox_FileComment As TextBox
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents SpeichernToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SpeichernUnterToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Private WithEvents IniFile1 As SchlumpfSoft.Controls.IniFileControl.IniFile
    Private WithEvents GroupBox_Sections As GroupBox
    Private WithEvents ListBox_Sections As ListBox
    Private WithEvents Button_DeleteSection As Button
    Private WithEvents Button_RenameSection As Button
    Private WithEvents Button_AddSection As Button
End Class
