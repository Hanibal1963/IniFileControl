' ****************************************************************************************************************
' ISection.vb
' © 2024 by Andreas Sauer
' ****************************************************************************************************************
'

Imports System
Imports System.Collections.Generic

''' <summary>
''' 
''' </summary>
<Serializable>
Public Class ISection

    Private _Entrys As List(Of IEntry)

    Public Sub New()
        Me._Entrys = New List(Of IEntry)
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    Public Property Name As String

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    Public Property Comment As String()

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    Public Property Entrys As List(Of IEntry)
        Get
            Return _Entrys
        End Get
        Set
            _Entrys = Value
        End Set
    End Property

End Class
