'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated from a template.
'
'     Manual changes to this file may cause unexpected behavior in your application.
'     Manual changes to this file will be overwritten if the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Collections.Generic

Partial Public Class paperarchive
    Public Property id As Long
    Public Property belongsTo As String
    Public Property formDatetime As Nullable(Of Date)
    Public Property image As String
    Public Property classifiedInto As String

    Public Overridable Property station As station
    Public Overridable Property paperarchivedefinition As paperarchivedefinition

End Class