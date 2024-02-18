' ****************************************************************************************************************
' IniFile.vb
' © 2024 by Andreas Sauer
' ****************************************************************************************************************
'

Imports System
Imports System.Collections.Generic
Imports System.ComponentModel

''' <summary>
''' Controlzum Verwalten von INI - Dateien
''' </summary>
<ProvideToolboxControl("SchlumpfSoft.Controls.IniFile", False)>
Public Class IniFile

    Inherits Component

    Private _FilePath As String
    Private _FileContent As String()
    Private _CommentPrefix As Char = ";"c
    Private _Sections As List(Of ISection)
    Private _Comment As String()

    ''' <summary>
    ''' Wird ausgelöst wenn die Datei gespeichert wurde.
    ''' </summary>
    <Browsable(True)>
    <Description("Wird ausgelöst wenn die Datei gespeichert wurde.")>
    Public Event FileSaved(sender As Object, e As EventArgs)

    ''' <summary>
    ''' Wird ausgelöst wenn der Dateikommentar geändert wurde.
    ''' </summary>
    <Browsable(True)>
    <Description("Wird ausgelöst wenn der Dateikommentar geändert wurde.")>
    Public Event FileCommentChanged(sender As Object, e As EventArgs)





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
            Return Me._FilePath
        End Get
        Set(value As String)
            Me._FilePath = value

            'testen ob eine Angabe erfolgte
            If String.IsNullOrWhiteSpace(value) Then Exit Property

            'Wenn Datei nicht existiert -> Beispieldatei erstellen, ansonsten Datei laden
            If Not Me.ExistFile Then Me.CreateTemplateFileContent() Else Me.LoadFile()

        End Set
    End Property

    ''' <summary>
    ''' Gibt die Zeilen des Dateikommentars zurück.
    ''' </summary>
    <Browsable(False)>
    Public ReadOnly Property Comment As String()
        Get
            Return _Comment
        End Get
    End Property

    Public Sub New()
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
    ''' Wenn kein prefixzeichen angegeben wird, wird Standardmäßig das Semikolon verwendet.
    ''' </remarks>
    Public Sub New(FilePath As String, Optional CommentPrefix As Char = ";"c)
        MyBase.New

        'Dateiname und Speicherort merken
        Me.FilePath = FilePath

        'KommentarPrefix merken
        Me.CommentPrefix = CommentPrefix

    End Sub

    ''' <summary>
    ''' Setzt den Dateikommentar.
    ''' </summary>
    ''' <param name="Comment">
    ''' die Zielen des Kommentars.
    ''' </param>
    Public Sub SetFileComment(Comment As String())

        'neue Liste für Kommentarzeilen erstellen
        Dim lines As New List(Of String)

        'Kommentarzeile inclusive Prefixzeichen hinzufügen
        For Each line As String In Comment
            lines.Add(Me._CommentPrefix & line)
        Next

        'Kommentar setzen
        Me._Comment = lines.ToArray

        'Dateiinhalt erzeugen
        Me.CreateFile()

        'Datei auf Datenträger schreiben
        Me.SaveFile()

    End Sub









    Private Sub CreateTemplateFileContent()

        'Dateikommentar
        Me._Comment = {$"Beispieldatei", $"erstellt von IniFileControl"}

        'Abschnitt inclusive Kommentar und Einträge 
        Me._Sections = New List(Of ISection) From {
            New ISection With {
                .Name = $"Abschnitt 1",
                .Comment = {$"Kommentar", $"zum Abschnitt 1"},
                .Entrys = New List(Of IEntry) From {
                    New IEntry With {
                        .Name = $"Wert 1",
                        .Comment = $"Kommentar zum Wert 1",
                        .Value = $"ein Wert"},
                    New IEntry With {
                        .Name = $"Wert 2",
                        .Comment = $"Kommentar zum Wert 2",
                        .Value = $"ein anderer Wert"}}}}

        'Dateiinhalt erzeugen
        Me.CreateFile()

        'Datei auf Datenträger schreiben
        Me.SaveFile()

    End Sub

    Private Sub CreateFile()

        'neue Liste für die Zeilen der Datei
        Dim content As New List(Of String)

        'Kommentarzeilen hinzufügen
        For Each line As String In Me._Comment
            content.Add(Me._CommentPrefix & line)
        Next

        'Abschnitte hinzufügen
        For Each section As ISection In Me._Sections

            'Abschnittsname hinzufügen
            content.Add($"[" & section.Name & $"]")

            'Abschnittskommentar hinzufügen
            For Each commentline As String In section.Comment
                content.Add(Me._CommentPrefix & commentline)
            Next

            'Einträge des Abschnitts hinzufügen
            For Each entry As IEntry In section.Entrys
                content.Add(entry.Name & $"=" & entry.Value & $" " & Me._CommentPrefix & entry.Comment)
            Next
        Next

        'Zeilen der Datei zu Dateiinhalt konvertieren
        Me._FileContent = content.ToArray

    End Sub

    Private Sub SaveFile()

        'Dateiinhalt auf Datenträger schreiben
        IO.File.WriteAllLines(Me._FilePath, Me._FileContent)

    End Sub

    Private Sub LoadFile()

        'Dateiinhalt von Datenträger lesen
        Me._FileContent = IO.File.ReadAllLines(Me._FilePath)

    End Sub

    Private Function ExistFile() As Boolean

        'Vorhandensein einer Datei prüfen
        Return IO.File.Exists(Me._FilePath)

    End Function

End Class
