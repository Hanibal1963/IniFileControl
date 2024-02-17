' ****************************************************************************************************************
' IniFile.vb
' © 2024 by Andreas Sauer
' ****************************************************************************************************************
'

Imports System.Collections.Generic
Imports System.ComponentModel

<ProvideToolboxControl("SchlumpfSoft.Controls.IniFile", False)>
Public Class IniFile

    Inherits Component

    Private _sections As List(Of ISection)
    Private _Comment As String()

    Public Sub New()
        Me._Comment = {$"Beispieldatei", $"erstellt von IniFileManager"}
        Me._sections = New List(Of ISection) From {
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
    End Sub

    Public Property Comment As String()
        Get
            Return _Comment
        End Get
        Set
            _Comment = Value
        End Set
    End Property

    Public Property Sections As List(Of ISection)
        Get
            Return _sections
        End Get
        Set
            _sections = Value
        End Set
    End Property

End Class
