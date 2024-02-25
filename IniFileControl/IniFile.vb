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
    ''' Wird ausgelöst wenn sich der Abschnittskommentar geändert hat
    ''' </summary>
    Public Event SectionCommentChanged(sender As Object, e As EventArgs)


    ''' <summary>
    ''' Gibt das Prefixzeichen für Kommentare zurück oder legt dieses fest.
    ''' </summary>
    <Browsable(True)>
    <Category("Design")>
    <Description("Gibt das Prefixzeichen für Kommentare zurück oder legt dieses fest.")>
    Public Property CommentPrefix As Char
        Get
            Return _CommentPrefix
        End Get
        Set
            _CommentPrefix = Value
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
    ''' <param name="FilePath">Pfad und Name zur INI-Datei.</param>
    ''' <param name="CommentPrefix">Prefixzeichen für Kommentare.</param>
    ''' <remarks>
    ''' Wenn kein Prefixzeichen angegeben wird, wird Standardmäßig das Semikolon verwendet.
    ''' </remarks>
    Public Sub New(FilePath As String, Optional CommentPrefix As Char = ";"c)

        MyBase.New

        'Standardwerte festlegen
        _FilePath = FilePath
        _CommentPrefix = CommentPrefix
        _AutoSave = False
        _FileComment = New List(Of String)

        'anfänglichen Dateiinhalt erzeugen und eventuell speichern
        CreateTemplate()
        If _AutoSave Then Me.SaveFile()

        'Dateiinhalt analysieren
        ParseFileContent()

    End Sub

    ''' <summary>
    ''' Lädt die angegebene Datei
    ''' </summary>
    ''' <param name="FilePath">Name und Pfad der Datei die geladen werden soll.</param>
    Public Sub LoadFile(FilePath As String)

        'Parameter überprüfen
        If String.IsNullOrWhiteSpace(FilePath) Then
            Throw New ArgumentException(
                $"Der Parameter""{NameOf(FilePath)}"" darf nicht NULL oder ein Leerraumzeichen sein.",
                NameOf(FilePath))
        End If

        'Pfad und Name der Datei merken
        _FilePath = FilePath
        Me.LoadFile()

    End Sub

    ''' <summary>
    ''' Lädt die Datei die in <see cref="FilePath"/> angegeben wurde.
    ''' </summary>
    Public Sub LoadFile()

        'Dateiinhalt von Datenträger lesen und analysieren
        _FileContent = IO.File.ReadAllLines(_FilePath)
        ParseFileContent()
        RaiseEvent FileContentChanged(Me, EventArgs.Empty)

    End Sub

    ''' <summary>
    ''' Speichert die angegebene Datei.
    ''' </summary>
    ''' <param name="FilePath">Name und Pfad der Datei die gespeichert werden soll.</param>
    Public Sub SaveFile(FilePath As String)

        'Parameter überprüfen
        If String.IsNullOrWhiteSpace(FilePath) Then
            Throw New ArgumentException(
                $"Der Parameter""{NameOf(FilePath)}"" darf nicht NULL oder ein Leerraumzeichen sein.",
                NameOf(FilePath))
        End If

        'Pfad und Name der Datei merken
        _FilePath = FilePath
        Me.SaveFile()

    End Sub

    ''' <summary>
    ''' Speichert die in <see cref="FilePath"/> angegebene Datei.
    ''' </summary>
    Public Sub SaveFile()

        'Dateiinhalt erzeugen 
        CreateFileContent()

        'Dateiinhalt auf Datenträger schreiben
        IO.File.WriteAllLines(_FilePath, _FileContent)

    End Sub

    ''' <summary>
    ''' Gibt den Dateikommentar zurück
    ''' </summary>
    Public Function GetFileComment() As String()
        Return _FileComment.ToArray
    End Function

    ''' <summary>
    ''' Setzt den Dateikommentar.
    ''' </summary>
    ''' <param name="CommentLines">Die Zeilen des Dateikommentars.</param>
    Public Sub SetFileComment(CommentLines() As String)

        'geänderten Dateikommentar übernehmen und eventuell speichern
        _FileComment.Clear()
        _FileComment.AddRange(CommentLines)
        If _AutoSave Then Me.SaveFile()
        RaiseEvent FileCommentChanged(Me, EventArgs.Empty)

    End Sub

    ''' <summary>
    ''' Ruft die Abschnittsnamen ab.
    ''' </summary>
    Public Function GetSectionNames() As String()

        Dim names As New List(Of String)
        For Each name As String In _Sections.Keys
            names.Add(name)
        Next
        Return names.ToArray

    End Function

    ''' <summary>
    ''' Gibt die Namen der Einträge eines Abschnitts zurück
    ''' </summary>
    ''' <param name="SectionName">Abschnittsname</param>
    Public Function GetEntryNames(SectionName As String) As String()

        Dim names As New List(Of String)
        For Each name As String In _Sections.Item(SectionName).Keys
            names.Add(name)
        Next
        Return names.ToArray

    End Function

    ''' <summary>
    ''' Fügt einen neuen Abschnitt hinzu.
    ''' </summary>
    ''' <param name="Name">Name des neuen Abschnitts</param>
    Public Sub AddSectionName(Name As String)

        'Prüfen ob der Name vorhanden ist
        If _Sections.ContainsKey(Name) Then
            RaiseEvent SectionNameExist(Me, EventArgs.Empty)
            Exit Sub
        End If

        'Abschnittsname hinzufügen und eventuell speichern
        _Sections.Add(Name, New Dictionary(Of String, String))
        _SectionsComments.Add(Name, New List(Of String))
        If _AutoSave Then Me.SaveFile()
        RaiseEvent SectionsChanged(Me, EventArgs.Empty)

    End Sub

    ''' <summary>
    ''' benennt einen Abschnitt um.
    ''' </summary>
    ''' <param name="OldName">alter Name des Abschnitts</param>
    ''' <param name="NewName">neuer name des Abschnitts</param>
    Public Sub RenameSection(OldName As String, NewName As String)

        'Ist der neueName bereits vorhanden?
        If Not _Sections.ContainsKey(NewName) Then
            'Nein ->
            RenameSectionValue(OldName, NewName)  'Name-Wert-Paar des Abschnitts umbenennen
            RenameSectionComment(OldName, NewName)  'Name-Kommentar-Paar umbenennen
            If _AutoSave Then Me.SaveFile() 'Änderungen eventuell speichern
            RaiseEvent SectionsChanged(Me, EventArgs.Empty) 'Ereignis auslösen
        Else
            'Ja ->
            RaiseEvent SectionNameExist(Me, EventArgs.Empty) 'Ereignis auslösen
            Exit Sub
        End If

    End Sub

    ''' <summary>
    ''' Löscht einen Abschnitt
    ''' </summary>
    ''' <param name="Name">Name des Nbschnittes</param>
    Public Sub DeleteSection(Name As String)

        'Abschnitt aus den Listen entfernen
        Dim unused = _Sections.Remove(Name)
        Dim unused1 = _SectionsComments.Remove(Name)

        'Änderungen eventuell speichern
        If _AutoSave Then Me.SaveFile()
        RaiseEvent SectionsChanged(Me, EventArgs.Empty)

    End Sub

    ''' <summary>
    ''' Gibt die Kommentarzeilen für einen Abschnitt zurück
    ''' </summary>
    ''' <param name="Name">Name des Abschnitts</param>
    Public Function GetSectionComment(Name As String) As String()
        Return _SectionsComments.Item(Name).ToArray
    End Function

    ''' <summary>
    ''' Setzt den Kommentar für einen Abschnitt.
    ''' </summary>
    ''' <param name="Name">Name des Abschnitts.</param>
    ''' <param name="CommentLines">Kommentarzeilen</param>
    Public Sub SetSectionComment(Name As String, CommentLines() As String)

        'geänderten Abschnittskommentar übernehmen und eventuell speichern
        _SectionsComments.Item(Name).Clear()
        _SectionsComments.Item(Name).AddRange(CommentLines)
        If _AutoSave Then Me.SaveFile()
        RaiseEvent SectionCommentChanged(Me, EventArgs.Empty)

    End Sub

End Class
