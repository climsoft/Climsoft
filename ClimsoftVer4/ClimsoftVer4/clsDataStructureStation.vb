Public Class DataStructureStation
    Inherits DataStructure

    ' Will be able to view/get station data as a single table

    ' Properties of station to get: all station properties and all features (all features relate to stations)


    ' Top level table: feature_type
    ' Linked tables:
    ' 1. feature (get list of stations)
    '    1a. feature_geometry (get list of latitude and longitude for all stations)
    ' 2. feature_type_property (get list of properties defined for stations)
    '    2a. feature_property_value (get list of property values for all properties for all stations)

    ' Everything that is fixed for this station class
    ' e.g. the top level table name and the list of sub DataStructures

    ' Define these here so they can be accessible in multiple functions
    Private clsFeature As New DataStructure("c5_feature")
    Private clsFeatureGeometry As New DataStructure("c5_feature_geometry")
    Private clsFeatureTypeProperty As New DataStructure("c5_feature_type_property")
    Private clsFeaturePropertyValue As New DataStructure("c5_feature_property_value")

    ' This is the ID of the station entry in the feature_type table
    ' This needs to be retrieved from the database
    ' This is needed to get linked data from all other feature tables
    Private iFeatureTypeID As Integer

    Private strFeatureTypeIdField As String = "feature_type_id"

    Public Sub New()
        SetTableName("c5_feature_type")
    End Sub

    ' Gets the ID of the station entry in the feature_type table and sets to iFeatureTypeID
    ' This only needs to be called once per session
    Private Sub SetFeatureTypeID()
        Dim iStationID As Integer

        ' TODO get this from the database and set to iFeatureTypeID
        ' How do we get this from the database? Do we assume that the name field will be "station"? What about in other languages?
        ' Or can we assume it is a fixed ID across databases?
        iFeatureTypeID = iStationID
    End Sub

    ' Linked tables:
    ' 1. feature (get list of stations)
    '    1a. feature_geometry (get list of latitude and longitude for all stations)
    ' 2. feature_type_property (get list of properties defined for stations)
    '    2a. feature_property_value (get list of property values for all properties for all stations)

    ' This should be called after calling SetFeatureTypeID()
    Private Sub SetStationLinkedDataStructures()
        clsFeature.SetFilter(strFeatureTypeIdField, "=", iFeatureTypeID)
        clsFeatureTypeProperty.SetFilter(strFeatureTypeIdField, "=", iFeatureTypeID)

        clsFeature.SetLinkedDataStructures(New List(Of DataStructure)(clsFeatureGeometry))
        clsFeatureTypeProperty.SetLinkedDataStructures(New List(Of DataStructure)(clsFeaturePropertyValue))
        SetLinkedDataStructures(New List(Of DataStructure)({clsFeature, clsFeatureTypeProperty}))
    End Sub

    ' strPropertyName is a string/enumerated value of known station properties
    ' Method knows how to get a know property in v4 or v5 database
    ' if strPropertyName is not recognised then have generic way to search database
    Public Function GetPropertyValue(strPropertyName As String) As Object

    End Function

    ' Returns all station related data in a single table
    Public Function GetStationDataTable() As DataTable
        Dim dtbStation As DataTable

        UpdateReadTable(True)

        ' Create a clone of the feature table as a base for a "station" table
        dtbStation = clsFeature.GetReadTable().Clone()
        ' Left join feature with feature_geometry table to get latitude and longitude columns
        ' Select a, b specifies what is returned in the query, a and b ensures all fields available
        Dim query = From a In clsFeature.GetReadTable().Copy().AsEnumerable()
                    Group Join b In clsFeatureGeometry.GetReadTable.Copy()
                         On a.Field(Of Integer)(strId) Equals b.Field(Of Integer)("feature_id")
                         Into Group
                    Let b = Group.FirstOrDefault
                    Select a, b

        ' TODO how do we deal with different versions when merging tables?
        ' TODO which fields do we keep from both tables?
        For Each item In query
            dtbStation.Rows.Add(item.a.ItemArray)
            dtbStation.Rows(dtbStation.Rows.Count - 1)("latitude") = item.b.Item("latitude")
            dtbStation.Rows(dtbStation.Rows.Count - 1)("longitude") = item.b.Item("longitude")
        Next

        ' Next:
        ' 1. Merge dtbFeaturePropertyValue with dtbFeatureTypeProperty 
        ' (right join if possible to only get properties for station, otherwise filter manually)
        ' 2. Unstack result (separate unstack for each type: integer, string etc.) to get properties wide
        ' 3. Merge unstacked results together
        ' 4. Merge result with dtbStation

    End Function

    ' Next:
    ' Add set of Do* functions to manage changes in the DataStructures
    ' e.g. DoCorrectPropertyValue(), DoAddPropertyValue(), DoAddStation()
    ' Forms can call these by only needing access to the output from GetStationDataTable()
    ' The Do* functions then call the appropriate Do* base DataStructure function for the right table
End Class