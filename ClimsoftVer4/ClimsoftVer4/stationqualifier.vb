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

Partial Public Class stationqualifier
    Public Property id As Long
    Public Property qualifier As String
    Public Property qualifierBeginDate As String
    Public Property qualifierEndDate As String
    Public Property stationTimeZone As Nullable(Of Integer)
    Public Property stationNetworkType As String
    Public Property belongsTo As String

    Public Overridable Property station As station

End Class