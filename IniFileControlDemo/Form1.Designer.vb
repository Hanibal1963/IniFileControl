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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.DateiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ÖffnenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BeendenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox_FileComment = New System.Windows.Forms.GroupBox()
        Me.Button_FileCommentChange = New System.Windows.Forms.Button()
        Me.TextBox_FileComment = New System.Windows.Forms.TextBox()
        Me.GroupBox_FileContent = New System.Windows.Forms.GroupBox()
        Me.TextBox_FileContent = New System.Windows.Forms.TextBox()
        Me.IniFile1 = New SchlumpfSoft.Controls.IniFileControl.IniFile()
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox_FileComment.SuspendLayout()
        Me.GroupBox_FileContent.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DateiToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(612, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'DateiToolStripMenuItem
        '
        Me.DateiToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ÖffnenToolStripMenuItem, Me.BeendenToolStripMenuItem})
        Me.DateiToolStripMenuItem.Name = "DateiToolStripMenuItem"
        Me.DateiToolStripMenuItem.Size = New System.Drawing.Size(46, 20)
        Me.DateiToolStripMenuItem.Text = "Datei"
        '
        'ÖffnenToolStripMenuItem
        '
        Me.ÖffnenToolStripMenuItem.Name = "ÖffnenToolStripMenuItem"
        Me.ÖffnenToolStripMenuItem.Size = New System.Drawing.Size(123, 22)
        Me.ÖffnenToolStripMenuItem.Text = "Öffnen ..."
        '
        'BeendenToolStripMenuItem
        '
        Me.BeendenToolStripMenuItem.Name = "BeendenToolStripMenuItem"
        Me.BeendenToolStripMenuItem.Size = New System.Drawing.Size(123, 22)
        Me.BeendenToolStripMenuItem.Text = "Beenden"
        '
        'GroupBox_FileComment
        '
        Me.GroupBox_FileComment.Controls.Add(Me.Button_FileCommentChange)
        Me.GroupBox_FileComment.Controls.Add(Me.TextBox_FileComment)
        Me.GroupBox_FileComment.Location = New System.Drawing.Point(8, 32)
        Me.GroupBox_FileComment.Name = "GroupBox_FileComment"
        Me.GroupBox_FileComment.Size = New System.Drawing.Size(256, 164)
        Me.GroupBox_FileComment.TabIndex = 1
        Me.GroupBox_FileComment.TabStop = False
        Me.GroupBox_FileComment.Text = "Dateikommentar"
        '
        'Button_FileCommentChange
        '
        Me.Button_FileCommentChange.Enabled = False
        Me.Button_FileCommentChange.Location = New System.Drawing.Point(152, 136)
        Me.Button_FileCommentChange.Name = "Button_FileCommentChange"
        Me.Button_FileCommentChange.Size = New System.Drawing.Size(96, 24)
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
        Me.TextBox_FileComment.Size = New System.Drawing.Size(240, 112)
        Me.TextBox_FileComment.TabIndex = 0
        Me.TextBox_FileComment.WordWrap = False
        '
        'GroupBox_FileContent
        '
        Me.GroupBox_FileContent.Controls.Add(Me.TextBox_FileContent)
        Me.GroupBox_FileContent.Location = New System.Drawing.Point(280, 32)
        Me.GroupBox_FileContent.Name = "GroupBox_FileContent"
        Me.GroupBox_FileContent.Size = New System.Drawing.Size(328, 168)
        Me.GroupBox_FileContent.TabIndex = 2
        Me.GroupBox_FileContent.TabStop = False
        Me.GroupBox_FileContent.Text = "Dateiinhalt"
        '
        'TextBox_FileContent
        '
        Me.TextBox_FileContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox_FileContent.Location = New System.Drawing.Point(12, 24)
        Me.TextBox_FileContent.Multiline = True
        Me.TextBox_FileContent.Name = "TextBox_FileContent"
        Me.TextBox_FileContent.ReadOnly = True
        Me.TextBox_FileContent.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBox_FileContent.Size = New System.Drawing.Size(308, 136)
        Me.TextBox_FileContent.TabIndex = 0
        Me.TextBox_FileContent.WordWrap = False
        '
        'IniFile1
        '
        Me.IniFile1.CommentPrefix = Global.Microsoft.VisualBasic.ChrW(59)
        Me.IniFile1.FilePath = Nothing
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(612, 422)
        Me.Controls.Add(Me.GroupBox_FileContent)
        Me.Controls.Add(Me.GroupBox_FileComment)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox_FileComment.ResumeLayout(False)
        Me.GroupBox_FileComment.PerformLayout()
        Me.GroupBox_FileContent.ResumeLayout(False)
        Me.GroupBox_FileContent.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents DateiToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ÖffnenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BeendenToolStripMenuItem As ToolStripMenuItem
    Private WithEvents IniFile1 As SchlumpfSoft.Controls.IniFileControl.IniFile
    Private WithEvents GroupBox_FileComment As GroupBox
    Private WithEvents Button_FileCommentChange As Button
    Private WithEvents TextBox_FileComment As TextBox
    Private WithEvents GroupBox_FileContent As GroupBox
    Private WithEvents TextBox_FileContent As TextBox
End Class
