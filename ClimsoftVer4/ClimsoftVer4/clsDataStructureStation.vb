Public Class DataStructureStation
    Inherits DataStructure

    ' Will be able to view/get station data as a single table

    ' Properties of station to get: all station properties and all features (all features relate to stations)


    ' Top level table: feature_type
    ' Second level: feature (get list of stations), feature_type_property (get ID to link to station)

    ' strPropertyName is a string/enumerated value of known properties
    ' Method knows how to get a know property in v4 or v5 database
    ' if strPropertyName is not recognised then have generic way to search database
    Public Function GetPropertyValue(strPropertyName As String) As Object

    End Function
End Class
