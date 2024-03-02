# IniFile Control

Eine Komponente zum Verwalten von INI - Dateien.

## Einführung

Diese Komponente ist von mir ursprünglich als Hilfsklasse für ein 
anderes Projekt von mir entwickelt worden.

Es entstand die Idee eine Windows-Forms-Komponente aus 
dieser Hilfsklasse zu machen und diese anderen zur Verfügung zu stellen.

## Eigenschaften

- AutoSave
- CommentPrefix
- FilePath

## Funktionen

- AddEntry
- AddSection
- DeleteEntry
- DeleteSection
- GetEntrynames
- GetEntryValue
- GetFileComment
- GetFileContent
- GetSectionComment
- GetSectionNames
- LoadFile
- RenameEntry
- RenameSection
- SaveFile
- SetEntryValue 
- SetFileComment
- SetSectionComment

## Ereignisse

- EntryNameExist
- EntrysChanged
- EntryValueChanged
- FileCommentChanged
- FileContentChanged
- SectionCommentChanged
- SectionNameExist
- SectionsChanged

## geplante Änderungen und Funktionen

Im Moment keine

## Weitere Literatur

- [ToolboxBitmapAttribute Konstruktoren](https://learn.microsoft.com/de-de/dotnet/api/system.drawing.toolboxbitmapattribute.-ctor?view=dotnet-plat-ext-7.0#system-drawing-toolboxbitmapattribute-ctor(system-type-system-string))
- [Entwickeln benutzerdefinierter Windows Forms-Steuerelemente mit .NET Framework](https://learn.microsoft.com/de-de/dotnet/desktop/winforms/controls/developing-custom-windows-forms-controls?view=netframeworkdesktop-4.8)
- [Initialisierungsdatei](https://de.wikipedia.org/wiki/Initialisierungsdatei#:~:text=Initialisierungsdateien%20werden%20typischerweise%20von%20Microsoft,durch%20die%20WinAPI%20unterst%C3%BCtzt%20wurde.)
- [Übersicht über Attribute (Visual Basic)](https://learn.microsoft.com/de-de/dotnet/visual-basic/programming-guide/concepts/attributes/)

