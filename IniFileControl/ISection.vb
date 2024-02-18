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
    Private _Name As String = ""
    Private _Comment As String() = {""}

    Public Sub New()
        Me._Entrys = New List(Of IEntry)
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    Public Property Name As String
        Get
            Return _Name
        End Get
        Set
            _Name = Value
        End Set
    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    Public Property Comment As String()
        Get
            Return _Comment
        End Get
        Set
            _Comment = Value
        End Set
    End Property

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
