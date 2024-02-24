' ****************************************************************************************************************
' IniFile.vb
' © 2024 by Andreas Sauer
' ****************************************************************************************************************
'

Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Windows.Forms
Imports Microsoft.VisualBasic

''' <summary>
''' Control zum Verwalten von INI - Dateien
''' </summary>
<ProvideToolboxControl("SchlumpfSoft.Controls.IniFile", False)>
Public Class IniFile : Inherits Component

    Private _FilePath As String
    Private _CommentPrefix As Char
    Private _FileContent() As String
    Private _FileComment As List(Of String)
    Private _Sections As Dictionary(Of String, Dictionary(Of String, String))
    Private _SectionsComments As Dictionary(Of String, List(Of String))
    Private _CurrentSectionName As String
    Private _AutoSave As Boolean

    ''' <summary>
    ''' Wird ausgelöst wenn sich der Dateiinhalt geändert hat.
    ''' </summary>
    Public Event FileContentChanged(sender As Object, e As EventArgs)

    ''' <summary>
    ''' Wird ausgelöst wenn sich der Dateikommentar geändert hat.
    ''' </summary>
    Public Event FileCommentChanged(sender As Object, e As EventArgs)

    ''' <summary>
    ''' Wird ausgelöst wenn sich die Liste der Abschnitte geändert hat.
    ''' </summary>
    Public Event SectionsChanged(sender As Object, e As EventArgs)

    ''' <summary>
    ''' Wird ausgelöst wenn beim anlegen eines neuen Abschnitts der Name bereits vorhanden ist
    ''' </summary>
    Public Event SectionNameExist(sender As Object, e As EventArgs)

    ''' <summary>
    ''' Gibt das Prefixzeichen für Kommentare zurück oder legt dieses fest.
    ''' </summary>
    <Browsable(True)>
    <Category("Design")>
    <Description("Gibt das Prefixzeichen für Kommentare zurück oder legt dieses fest.")>
    Public Property CommentPrefix As Char
        Get
            Return Me._CommentPrefix
        End Get
        Set
            Me._CommentPrefix = Value
        End Set
    End Property

    ''' <summary>
    ''' Gibt den Pfad und den Name zur INI-Datei zurück oder legt diesen fest.    
    ''' </summary>
    <Browsable(True)>
    <Category("Design")>
    <Description("Gibt den Pfad und den Name zur INI-Datei zurück oder legt diesen fest.")>
    Public Property FilePath As String
        Get
            Return _FilePath
        End Get
        Set
            _FilePath = Value
        End Set
    End Property

    ''' <summary>
    ''' Legt das Speicherverhalten der Klasse fest.
    ''' </summary>
    ''' <remarks>
    ''' True legt fest das Änderungen automatisch gespeichert werden.
    ''' </remarks>
    <Browsable(True)>
    <Category("Design")>
    <Description("Legt das Speicherverhalten der Klasse fest.")>
    Public Property AutoSave As Boolean
        Get
            Return _AutoSave
        End Get
        Set
            _AutoSave = Value
        End Set
    End Property

    ''' <summary>
    ''' Erstellt eine neue Instanz dieser Klasse.
    ''' </summary>
    Public Sub New()

        'anfänglichen Speicherort und Name der Datei sowie Standardprefix für Kommentare festlegen
        Me.New(My.Computer.FileSystem.SpecialDirectories.MyDocuments &
                IO.Path.DirectorySeparatorChar &
                My.Resources.DefaultFileName, CChar(My.Resources.DefaultCommentPrefix))

    End Sub

    ''' <summary>
    ''' Erstellt eine neue Instanz dieser Klasse unter Angabe der Datei.
    ''' </summary>
    ''' <param name="FilePath">
    ''' Pfad und Name zur INI-Datei.
    ''' </param>
    ''' <param name="CommentPrefix">
    ''' Prefixzeichen für Kommentare.
    ''' </param>
    ''' <remarks>
    ''' Wenn kein Prefixzeichen angegeben wird, wird Standardmäßig das Semikolon verwendet.
    ''' </remarks>
    Public Sub New(FilePath As String, Optional CommentPrefix As Char = ";"c)
        MyBase.New

        'Standardwerte festlegen
        Me._FilePath = FilePath
        Me._CommentPrefix = CommentPrefix
        Me._AutoSave = False
        Me._FileComment = New List(Of String)

        'anfänglichen Dateiinhalt erzeugen und eventuell speichern
        Me.CreateTemplate()
        If Me._AutoSave Then Me.SaveFile()

        'Dateiinhalt analysieren
        Me.ParseFileContent()

    End Sub

    ''' <summary>
    ''' Lädt die angegebene Datei
    ''' </summary>
    ''' <param name="FilePath">
    ''' Name und Pfad der Datei die geladen werden soll.
    ''' </param>
    Public Sub LoadFile(FilePath As String)

        'Parameter überprüfen
        If String.IsNullOrWhiteSpace(FilePath) Then
            Throw New ArgumentException(
                $"Der Parameter""{NameOf(FilePath)}"" darf nicht NULL oder ein Leerraumzeichen sein.",
                NameOf(FilePath))
        End If

        'Pfad und Name der Datei merken
        Me._FilePath = FilePath
        Me.LoadFile()

    End Sub

    ''' <summary>
    ''' Lädt die Datei die in <see cref="FilePath"/> angegeben wurde.
    ''' </summary>
    Public Sub LoadFile()

        'Dateiinhalt von Datenträger lesen und analysieren
        Me._FileContent = IO.File.ReadAllLines(Me._FilePath)
        Me.ParseFileContent()
        RaiseEvent FileContentChanged(Me, EventArgs.Empty)

    End Sub

    ''' <summary>
    ''' Speichert die angegebene Datei.
    ''' </summary>
    ''' <param name="FilePath">
    ''' Name und Pfad der Datei die gespeichert werden soll.
    ''' </param>
    Public Sub SaveFile(FilePath As String)

        'Parameter überprüfen
        If String.IsNullOrWhiteSpace(FilePath) Then
            Throw New ArgumentException(
                $"Der Parameter""{NameOf(FilePath)}"" darf nicht NULL oder ein Leerraumzeichen sein.",
                NameOf(FilePath))
        End If

        'Pfad und Name der Datei merken
        Me._FilePath = FilePath
        Me.SaveFile()

    End Sub

    ''' <summary>
    ''' Speichert die in <see cref="FilePath"/> angegebene Datei.
    ''' </summary>
    Public Sub SaveFile()

        'Dateiinhalt erzeugen 
        Me.CreateFileContent()

        'Dateiinhalt auf Datenträger schreiben
        IO.File.WriteAllLines(Me._FilePath, Me._FileContent)

    End Sub

    ''' <summary>
    ''' Gibt den Dateikommentar zurück
    ''' </summary>
    ''' <returns></returns>
    Public Function GetFileComment() As String()
        Return Me._FileComment.ToArray
    End Function

    ''' <summary>
    ''' Setzt den Dateikommentar.
    ''' </summary>
    ''' <param name="Lines">
    ''' Die Zeilen des Dateikommentars.
    ''' </param>
    Public Sub SetFileComment(Lines() As String)

        'geänderten Dateikommentar übernehmen und eventuell speichern
        Me._FileComment.Clear()
        Me._FileComment.AddRange(Lines)
        If Me._AutoSave Then Me.SaveFile()
        RaiseEvent FileCommentChanged(Me, EventArgs.Empty)

    End Sub

    ''' <summary>
    ''' Ruft die Abschnittsnamen ab.
    ''' </summary>
    ''' <returns></returns>
    Public Function GetSectionNames() As String()

        Dim names As New List(Of String)
        For Each name As String In Me._Sections.Keys
            names.Add(name)
        Next
        Return names.ToArray

    End Function

    ''' <summary>
    ''' Fügt einen neuen Abschnitt hinzu.
    ''' </summary>
    ''' <param name="Name">
    ''' Name des neuen Abschnitts
    ''' </param>
    Public Sub AddSectionName(Name As String)

        'Prüfen ob der Name vorhanden ist
        If Me._Sections.ContainsKey(Name) Then
            RaiseEvent SectionNameExist(Me, EventArgs.Empty)
            Exit Sub
        End If

        'Abschnittsname hinzufügen und eventuell speichern
        Me._Sections.Add(Name, New Dictionary(Of String, String))
        Me._SectionsComments.Add(Name, New List(Of String))
        If Me._AutoSave Then Me.SaveFile()
        RaiseEvent SectionsChanged(Me, EventArgs.Empty)

    End Sub

    ''' <summary>
    ''' benennt einen Abschnitt um.
    ''' </summary>
    ''' <param name="OldName">alter Name des Abschnitts</param>
    ''' <param name="NewName">neuer name des Abschnitts</param>
    Public Sub RenameSection(OldName As String, NewName As String)

        'Prüfen ob der neue Name vorhanden ist
        If Me._Sections.ContainsKey(NewName) Then
            RaiseEvent SectionNameExist(Me, EventArgs.Empty)
            Exit Sub
        End If

        'alten Wert speichern, Abschnitt entfernen und
        'neuen Abschnitt mit altem Wert erstellen
        Dim oldvalue = Me._Sections.Item(OldName)
        Dim unused = Me._Sections.Remove(OldName)
        Me._Sections.Add(NewName, oldvalue)

        'alten Kommentar speichern, Abschnitt entfernen und
        'neuen Abschnitt mit altem Kommentar erstellen
        Dim oldcomment = Me._SectionsComments.Item(OldName)
        Dim unused1 = Me._SectionsComments.Remove(OldName)
        Me._SectionsComments.Add(NewName, oldcomment)

        'Änderungen eventuell speichern
        If Me._AutoSave Then Me.SaveFile()
        RaiseEvent SectionsChanged(Me, EventArgs.Empty)

    End Sub

    ''' <summary>
    ''' Löscht einen Abschnitt
    ''' </summary>
    ''' <param name="Name">
    ''' Name des Nbschnittes
    ''' </param>
    Public Sub DeleteSection(Name As String)

        'Abschnitt aus den Listen entfernen
        Dim unused = Me._Sections.Remove(Name)
        Dim unused1 = Me._SectionsComments.Remove(Name)

        'Änderungen eventuell speichern
        If Me._AutoSave Then Me.SaveFile()
        RaiseEvent SectionsChanged(Me, EventArgs.Empty)

    End Sub

    ''' <summary>
    ''' Gibt die Kommentarzeilen für einen Abschnitt zurück
    ''' </summary>
    ''' <param name="Name">
    ''' Name des Abschnitts
    ''' </param>
    Public Function GetSectionComment(Name As String) As String()
        Return Me._SectionsComments.Item(Name).ToArray
    End Function

    ''' <summary>
    ''' Erzeugt den Dateiinhalt
    ''' </summary>
    Private Sub CreateFileContent()

        'Zeilenliste
        Dim filecontent As New List(Of String)

        'Dateikommentarzeilen anfügen
        For Each line As String In Me._FileComment
            filecontent.Add(Me._CommentPrefix & $" " & line)
        Next

        'Leerzeile anfügen
        filecontent.Add($"")

        'alle Abschnitte durchlaufen
        For Each sectionname As String In Me._Sections.Keys

            'Abschnittsname hinzufügen
            filecontent.Add($"[" & sectionname & $"]")

            'Zeilen des Abschnittskommentars durchlaufen
            For Each commentline As String In Me._SectionsComments.Item(sectionname)
                'Kommentarzeile einfügen
                filecontent.Add(Me._CommentPrefix & $" " & commentline)
            Next

            'alle Eintragszeilen durchlaufen
            Dim entryline As String
            For Each entryname As String In Me._Sections.Item(sectionname).Keys
                'Eintragszeile erzeugen und einfügen
                entryline = entryname & $" = " &
                    Me._Sections.Item(sectionname).Item(entryname)
                filecontent.Add(entryline)
            Next

        Next

        'Leerzeile anfügen
        filecontent.Add($"")

        'Dateiinhalt erzeugen
        Me._FileContent = filecontent.ToArray

    End Sub

    ''' <summary>
    ''' Erzeugt den Beispielinhalt der Datei
    ''' </summary>
    Private Sub CreateTemplate()

        Me._FileContent = {
             Me._CommentPrefix & $" " & My.Resources.DefaultFileName,
             Me._CommentPrefix & $" erstellt von " & My.Application.Info.AssemblyName &
             $" V" & My.Application.Info.Version.ToString,
             Me._CommentPrefix & $" " & My.Application.Info.Copyright,
             $"",
             $"[Abschnitt 1]",
             Me._CommentPrefix & $"Beispielabschnitt",
             Me._CommentPrefix & $"Computername - Name des PC's",
             Me._CommentPrefix & $"Betriebssystem - welches Betriebssystem",
             Me._CommentPrefix & $"Version - Versionsnummer des Betriebssystems",
             $"Computername = " & My.Computer.Name,
             $"Betriebssystem = " & My.Computer.Info.OSFullName,
             $"Version = " & My.Computer.Info.OSVersion
        }

    End Sub

    ''' <summary>
    ''' analysiert den Dateiinhalt
    ''' </summary>
    Private Sub ParseFileContent()

        'Variablen initialisieren
        Me.InitParseVariables()

        'aktueller Abschnittsname
        Me._CurrentSectionName = $""

        'alle Zeilen des Dateiinhaltes durchlaufen
        For Each line As String In Me._FileContent

            'Leerzeichen am Anfang und Ende der Zeile entfernen
            line = line.Trim

            'aktuelle Zeile analysieren
            Me.LineAnalyse(line)

        Next

    End Sub

    ''' <summary>
    ''' Analysiert eine Zeile.
    ''' </summary>
    ''' <param name="CurrentSectionName">
    ''' Name des aktuellen Abschnitts
    ''' </param>
    ''' <param name="LineContent">
    ''' Zeileninhalt
    ''' </param>
    Private Sub LineAnalyse(LineContent As String)

        If Me._CurrentSectionName Is $"" And LineContent.StartsWith(Me._CommentPrefix) Then
            'noch kein Abschnitt gefunden und Zeile startet mit Prefix
            'Dateikommentar hinzufügen
            Me.AddFileCommentLine(LineContent)

        ElseIf LineContent.StartsWith($"[") And LineContent.EndsWith($"]") Then
            'Zeile enthält eckige Klammern
            'Abschnittsname hinzufügen
            Me.AddSectionNameLine(LineContent)

        ElseIf Me._CurrentSectionName IsNot $"" And LineContent.StartsWith(Me._CommentPrefix) Then
            'aktueller Abschnitt und Zeile startet mit Prefix
            'Abschnittskommentar hinzufügen
            Me.AddSectionCommentLine(LineContent)

        ElseIf Me._CurrentSectionName IsNot $"" And LineContent.Contains($"=") Then
            'aktueller Abschnitt und Zeile enthält Gleichheitszeichen
            'Eintrag hinzufügen
            Me.AddEntryLine(LineContent)

        End If

    End Sub

    ''' <summary>
    ''' fügt einen Eintrag hinzu
    ''' </summary>
    ''' <param name="LineContent">
    ''' Zeileninhalt
    ''' </param>
    Private Sub AddEntryLine(LineContent As String)

        'Eintagszeile in Name und Wert trennen
        Dim name As String = LineContent.Split("="c)(0).Trim
        Dim value As String = LineContent.Split("="c)(1).Trim

        'Eintrag hinzufügen
        Me._Sections.Item(Me._CurrentSectionName).Add(name, value)

    End Sub

    ''' <summary>
    ''' fügt eine Abschnittskommentarzeile hinzu
    ''' </summary>
    ''' <param name="LineContent">
    ''' Zeileninhalt
    ''' </param>
    Private Sub AddSectionCommentLine(LineContent As String)

        'Prefix und eventuelle Leerzeichen am Anfang und Ende entfernen
        Dim line As String = LineContent.Substring(1, LineContent.Length - 1).Trim

        'Kommentarzeile hinzufügen
        Me._SectionsComments.Item(Me._CurrentSectionName).Add(line)

    End Sub

    ''' <summary>
    ''' fügt einen Abschnittsname hinzu
    ''' </summary>
    ''' <param name="LineContent">
    ''' Zeileninhalt
    ''' </param>
    Private Sub AddSectionNameLine(LineContent As String)

        'Klammern und eventuelle Leerzeichen am Anfang und Ende entfernen
        Dim line = LineContent.Substring(1, LineContent.Length - 2).Trim

        'Abschnittsname merken
        Me._CurrentSectionName = line

        'neuen Abschnitt erstellen
        Me._Sections.Add(Me._CurrentSectionName, New Dictionary(Of String, String))
        Me._SectionsComments.Add(Me._CurrentSectionName, New List(Of String))

    End Sub

    ''' <summary>
    ''' fügt eine Dateikommentarzeile hinzu
    ''' </summary>
    ''' <param name="LineContent">Zeileninhalt</param>
    Private Sub AddFileCommentLine(LineContent As String)

        'Prefix und eventuelle Leerzeichen am Anfang und Ende entfernen
        Dim line = LineContent.Substring(1, LineContent.Length - 1).Trim

        'Zeile in den Dateikommentar übernehmen
        Me._FileComment.Add(line)

    End Sub

    ''' <summary>
    ''' Initialisiert die Variablen für den Parser
    ''' </summary>
    Private Sub InitParseVariables()

        Me._FileComment = New List(Of String)
        Me._Sections = New Dictionary(Of String, Dictionary(Of String, String))
        Me._SectionsComments = New Dictionary(Of String, List(Of String))

    End Sub

End Class
