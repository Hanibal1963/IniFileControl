' ****************************************************************************************************************
' VariableDefinitions.vb
' © 2024 by Andreas Sauer
' ****************************************************************************************************************
'

Imports System.Collections.Generic

''' <summary>
''' Modul mit Variablendefinitionen
''' </summary>
Module VariableDefinitions

    Friend _FilePath As String
    Friend _CommentPrefix As Char
    Friend _FileContent() As String
    Friend _FileComment As List(Of String)
    Friend _Sections As Dictionary(Of String, Dictionary(Of String, String))
    Friend _SectionsComments As Dictionary(Of String, List(Of String))
    Friend _CurrentSectionName As String
    Friend _AutoSave As Boolean

End Module
