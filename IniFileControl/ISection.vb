' ****************************************************************************************************************
' ISection.vb
' © 2024 by Andreas Sauer
' ****************************************************************************************************************
'

Imports System
Imports System.Collections.Generic

<Serializable>
Public Class ISection

    Private _Entrys As List(Of IEntry)

    Public Sub New()
        Me._Entrys = New List(Of IEntry)
    End Sub

    Public Property Name As String

    Public Property Comment As String()

    Public Property Entrys As List(Of IEntry)
        Get
            Return _Entrys
        End Get
        Set
            _Entrys = Value
        End Set
    End Property

End Class
