' ****************************************************************************************************************
' HelperFunctions.vb
' © 2024 by Andreas Sauer
' ****************************************************************************************************************
'

Imports System.Collections.Generic

Module HelperFunctions

    ''' <summary>
    ''' fügt einen neuen Abschnitt hinzu
    ''' </summary>
    ''' <param name="Name">Name des neuen Abschnitts</param>
    Friend Sub AddNewSection(Name As String)
        _Sections.Add(Name, New Dictionary(Of String, String)) 'Name-Wert-Paar hinzufügen
        _SectionsComments.Add(Name, New List(Of String)) 'Name-Kommentar-Paar hinzufügen
    End Sub

    ''' <summary>
    ''' Legt die anfänglichen Standardwerte fest
    ''' </summary>
    ''' <param name="FilePath">Pfad und Name der Datei</param>
    ''' <param name="CommentPrefix">Prefixzeichen für Kommentare</param>
    Friend Sub CreateStandardValues(FilePath As String, CommentPrefix As Char)
        _FilePath = FilePath
        _CommentPrefix = CommentPrefix
        _AutoSave = False
        _FileComment = New List(Of String)
    End Sub

    ''' <summary>
    ''' Benennt das Key-Comment-Paar eines Abschnitts um. 
    ''' </summary>
    ''' <param name="oldName">alter Name</param>
    ''' <param name="newName">neuer Name</param>
    Friend Sub RenameSectionComment(oldName As String, newName As String)

        'alten Kommentar speichern, Abschnitt entfernen und
        'neuen Abschnitt mit altem Kommentar erstellen
        Dim oldcomment = _SectionsComments.Item(oldName)
        Dim unused1 = _SectionsComments.Remove(oldName)
        _SectionsComments.Add(newName, oldcomment)

    End Sub

    ''' <summary>
    ''' Benennt das Key-Value-Paar eines Abschnitts um.
    ''' </summary>
    ''' <param name="OldName">alter Name</param>
    ''' <param name="NewName">neuer Name</param>
    Friend Sub RenameSectionValue(OldName As String, NewName As String)

        'alten Wert speichern, Abschnitt entfernen und
        'neuen Abschnitt mit altem Wert erstellen
        Dim oldvalue = _Sections.Item(OldName)
        Dim unused = _Sections.Remove(OldName)
        _Sections.Add(NewName, oldvalue)

    End Sub

    ''' <summary>
    ''' Erzeugt den Dateiinhalt
    ''' </summary>
    Friend Sub CreateFileContent()

        Dim filecontent As New List(Of String) 'Zeilenliste

        'Dateikommentarzeilen anfügen
        For Each line As String In _FileComment
            filecontent.Add(_CommentPrefix & $" " & line)
        Next

        filecontent.Add($"") 'Leerzeile anfügen

        'alle Abschnitte durchlaufen
        For Each sectionname As String In _Sections.Keys

            filecontent.Add($"[" & sectionname & $"]") 'Abschnittsname hinzufügen

            'Zeilen des Abschnittskommentars durchlaufen
            For Each commentline As String In _SectionsComments.Item(sectionname)
                filecontent.Add(_CommentPrefix & $" " & commentline) 'Kommentarzeile einfügen
            Next

            'alle Eintragszeilen durchlaufen
            Dim entryline As String
            For Each entryname As String In _Sections.Item(sectionname).Keys
                'Eintragszeile erzeugen und einfügen
                entryline = entryname & $" = " & _Sections.Item(sectionname).Item(entryname)
                filecontent.Add(entryline)
            Next

            filecontent.Add($"") 'Leerzeile anfügen

        Next

        _FileContent = filecontent.ToArray 'Dateiinhalt erzeugen

    End Sub

    ''' <summary>
    ''' Erzeugt den Beispielinhalt der Datei
    ''' </summary>
    Friend Sub CreateTemplate()

        _FileContent = {
             _CommentPrefix & $" " & My.Resources.DefaultFileName,
             _CommentPrefix & $" erstellt von " & My.Application.Info.AssemblyName &
             $" V" & My.Application.Info.Version.ToString,
             _CommentPrefix & $" " & My.Application.Info.Copyright,
             $"",
             $"[Abschnitt 1]",
             _CommentPrefix & $"Beispielabschnitt",
             _CommentPrefix & $"Computername - Name des PC's",
             _CommentPrefix & $"Betriebssystem - welches Betriebssystem",
             _CommentPrefix & $"Version - Versionsnummer des Betriebssystems",
             $"Computername = " & My.Computer.Name,
             $"Betriebssystem = " & My.Computer.Info.OSFullName,
             $"Version = " & My.Computer.Info.OSVersion
        }

    End Sub

    ''' <summary>
    ''' analysiert den Dateiinhalt
    ''' </summary>
    Friend Sub ParseFileContent()

        InitParseVariables() 'Variablen initialisieren
        _CurrentSectionName = $"" 'aktueller Abschnittsname

        'alle Zeilen des Dateiinhaltes durchlaufen
        For Each line As String In _FileContent
            line = line.Trim 'Leerzeichen am Anfang und Ende der Zeile entfernen
            LineAnalyse(line) 'aktuelle Zeile analysieren
        Next

    End Sub

#Region "interne Methoden"

    ''' <summary>
    ''' Analysiert eine Zeile.
    ''' </summary>
    ''' <param name="CurrentSectionName">Name des aktuellen Abschnitts</param>
    ''' <param name="LineContent">Zeileninhalt</param>
    Private Sub LineAnalyse(LineContent As String)

        If _CurrentSectionName Is $"" And LineContent.StartsWith(_CommentPrefix) Then
            'noch kein Abschnitt gefunden und Zeile startet mit Prefix
            AddFileCommentLine(LineContent) 'Dateikommentar hinzufügen

        ElseIf LineContent.StartsWith($"[") And LineContent.EndsWith($"]") Then
            'Zeile enthält eckige Klammern
            AddSectionNameLine(LineContent) 'Abschnittsname hinzufügen

        ElseIf _CurrentSectionName IsNot $"" And LineContent.StartsWith(_CommentPrefix) Then
            'aktueller Abschnitt und Zeile startet mit Prefix
            AddSectionCommentLine(LineContent) 'Abschnittskommentar hinzufügen

        ElseIf _CurrentSectionName IsNot $"" And LineContent.Contains($"=") Then
            'aktueller Abschnitt und Zeile enthält Gleichheitszeichen
            AddEntryLine(LineContent) 'Eintrag hinzufügen

        End If

    End Sub

    ''' <summary>
    ''' fügt einen Eintrag hinzu
    ''' </summary>
    ''' <param name="LineContent">Zeileninhalt</param>
    Private Sub AddEntryLine(LineContent As String)

        'Eintagszeile in Name und Wert trennen
        Dim name As String = LineContent.Split("="c)(0).Trim
        Dim value As String = LineContent.Split("="c)(1).Trim

        _Sections.Item(_CurrentSectionName).Add(name, value) 'Eintrag hinzufügen

    End Sub

    ''' <summary>
    ''' fügt eine Abschnittskommentarzeile hinzu
    ''' </summary>
    ''' <param name="LineContent">Zeileninhalt</param>
    Private Sub AddSectionCommentLine(LineContent As String)

        'Prefix und eventuelle Leerzeichen am Anfang und Ende entfernen
        Dim line As String = LineContent.Substring(1, LineContent.Length - 1).Trim

        _SectionsComments.Item(_CurrentSectionName).Add(line) 'Kommentarzeile hinzufügen

    End Sub

    ''' <summary>
    ''' fügt einen Abschnittsname hinzu
    ''' </summary>
    ''' <param name="LineContent">Zeileninhalt</param>
    Private Sub AddSectionNameLine(LineContent As String)

        'Klammern und eventuelle Leerzeichen am Anfang und Ende entfernen
        Dim line = LineContent.Substring(1, LineContent.Length - 2).Trim

        _CurrentSectionName = line 'Abschnittsname merken

        'neuen Abschnitt erstellen
        _Sections.Add(_CurrentSectionName, New Dictionary(Of String, String))
        _SectionsComments.Add(_CurrentSectionName, New List(Of String))

    End Sub

    ''' <summary>
    ''' fügt eine Dateikommentarzeile hinzu
    ''' </summary>
    ''' <param name="LineContent">Zeileninhalt</param>
    Private Sub AddFileCommentLine(LineContent As String)

        'Prefix und eventuelle Leerzeichen am Anfang und Ende entfernen
        Dim line = LineContent.Substring(1, LineContent.Length - 1).Trim

        _FileComment.Add(line) 'Zeile in den Dateikommentar übernehmen

    End Sub

    ''' <summary>
    ''' Initialisiert die Variablen für den Parser
    ''' </summary>
    Private Sub InitParseVariables()
        _FileComment = New List(Of String)
        _Sections = New Dictionary(Of String, Dictionary(Of String, String))
        _SectionsComments = New Dictionary(Of String, List(Of String))
    End Sub

#End Region

End Module

