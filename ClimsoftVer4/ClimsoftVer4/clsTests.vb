Public Class clsTests

    Public Sub TestStationTable()
        Dim dtbFeature As New DataTable
        Dim dtbFeatureGeometry As New DataTable
        Dim dtbFeatureTypeProperty As New DataTable
        Dim dtbFeaturePropertyValue As New DataTable
        Dim dtbStation As New DataTable

        dtbFeature.Columns.Add("id", GetType(Integer))
        dtbFeature.Columns.Add("version_number", GetType(Integer))
        dtbFeature.Columns.Add("feature_type_id", GetType(Integer))
        dtbFeature.Columns.Add("name", GetType(String))
        dtbFeature.Columns.Add("current", GetType(Integer))

        dtbFeature.Rows.Add(1, 1, 1, "BINGA", 1)
        dtbFeature.Rows.Add(2, 1, 1, "KARIBA AIRPORT", 1)
        'dtbFeature.Rows.Add(3, 1, 2, "Kenya", 1)
        dtbFeature.Rows.Add(4, 1, 1, "Kisumu Airport", 1)

        dtbFeatureGeometry.Columns.Add("id", GetType(Integer))
        dtbFeatureGeometry.Columns.Add("version_number", GetType(Integer))
        dtbFeatureGeometry.Columns.Add("feature_id", GetType(Integer))
        dtbFeatureGeometry.Columns.Add("geometry_type", GetType(String))
        dtbFeatureGeometry.Columns.Add("shape", GetType(String))
        dtbFeatureGeometry.Columns.Add("latitude", GetType(Double))
        dtbFeatureGeometry.Columns.Add("longitude", GetType(Double))
        dtbFeatureGeometry.Columns.Add("current", GetType(Integer))

        dtbFeatureGeometry.Rows.Add(1, 1, 1, "point", "", -1.6, 37.3, 1)
        dtbFeatureGeometry.Rows.Add(2, 1, 2, "point", "", -16.5, 28.8, 1)
        'dtbFeatureGeometry.Rows.Add(3, 1, 3, "polygon", "", DBNull.Value, DBNull.Value, 1)
        dtbFeatureGeometry.Rows.Add(4, 1, 4, "point", "", -0.01, 34.7, 1)

        dtbStation.Columns.Add("id", GetType(Integer))
        dtbStation.Columns.Add("version_number", GetType(Integer))
        dtbStation.Columns.Add("feature_type_id", GetType(Integer))
        dtbStation.Columns.Add("name", GetType(String))
        dtbStation.Columns.Add("current", GetType(Integer))
        dtbStation.Columns.Add("latitude", GetType(Double))
        dtbStation.Columns.Add("longitude", GetType(Double))

        Dim query = From a In dtbFeature.AsEnumerable
                    Group Join b In dtbFeatureGeometry
                         On a.Field(Of Integer)("id") Equals b.Field(Of Integer)("feature_id")
                         Into Group
                    Let b = Group.FirstOrDefault
                    Select a, b
        For Each item In query
            dtbStation.Rows.Add(item.a.ItemArray)
            dtbStation.Rows(dtbStation.Rows.Count - 1)("latitude") = item.b.Item("latitude")
            dtbStation.Rows(dtbStation.Rows.Count - 1)("longitude") = item.b.Item("longitude")
        Next

    End Sub
End Class
