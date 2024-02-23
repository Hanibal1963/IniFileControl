' ****************************************************************************************************************
' IniFile.vb
' © 2024 by Andreas Sauer
' ****************************************************************************************************************
'

Imports System
Imports System.ComponentModel

''' <summary>
''' Control zum Verwalten von INI - Dateien
''' </summary>
<ProvideToolboxControl("SchlumpfSoft.Controls.IniFile", False)>
Public Class IniFile

    Inherits Component

    Private _FilePath As String
    Private _CommentPrefix As Char
    Private _FileContent As String()

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

        'Dateiname und Speicherort sowie KommentarPrefix merken
        Me._FilePath = FilePath
        Me._CommentPrefix = CommentPrefix

        'anfänglichen Dateiinhalt erzeugen und speichern
        Me.CreateTemplate()
        Me.SaveFile()

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

        'Dateiinhalt von Datenträger lesen
        Me._FileContent = IO.File.ReadAllLines(Me._FilePath)

    End Sub

    ''' <summary>
    ''' Speicher die angegebene Datei.
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

        'Dateiinhalt auf Datenträger schreiben
        IO.File.WriteAllLines(Me._FilePath, Me._FileContent)

    End Sub

    Private Sub CreateTemplate()

        Me._FileContent = {
             Me._CommentPrefix & $" " & My.Resources.DefaultFileName,
             Me._CommentPrefix & $" erstellt von " & My.Application.Info.AssemblyName &
             $" V" & My.Application.Info.Version.ToString,
             Me._CommentPrefix & $" " & My.Application.Info.Copyright,
             $"",
             $"[Abschnitt 1]",
             Me._CommentPrefix & $"Beispielabschnitt",
             $"Computername = " & My.Computer.Name & Me._CommentPrefix & $" Name dieses PC's",
             $"Betriebssystem = " & My.Computer.Info.OSFullName,
             $"Version = " & My.Computer.Info.OSVersion
        }

    End Sub

End Class
