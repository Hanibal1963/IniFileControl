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
        Me.IniFile1 = New SchlumpfSoft.Controls.IniFileControl.IniFile()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TextBox_FileComment = New System.Windows.Forms.TextBox()
        Me.Button_FileCommentChange = New System.Windows.Forms.Button()
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DateiToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(622, 24)
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
        'IniFile1
        '
        Me.IniFile1.CommentPrefix = Global.Microsoft.VisualBasic.ChrW(59)
        Me.IniFile1.FilePath = Nothing
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button_FileCommentChange)
        Me.GroupBox1.Controls.Add(Me.TextBox_FileComment)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 32)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(256, 164)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Dateikommentar"
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
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(622, 422)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents DateiToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ÖffnenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BeendenToolStripMenuItem As ToolStripMenuItem
    Private WithEvents IniFile1 As SchlumpfSoft.Controls.IniFileControl.IniFile
    Private WithEvents GroupBox1 As GroupBox
    Private WithEvents Button_FileCommentChange As Button
    Private WithEvents TextBox_FileComment As TextBox
End Class
