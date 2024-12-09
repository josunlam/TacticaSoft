Imports System.Data.SqlClient
Imports System.Configuration

Public Class Base
    Private dataSet As DataSet
    Private dataAdapter As SqlDataAdapter

    Protected configuracion As ConnectionStringSettings = ConfigurationManager.ConnectionStrings("connect")
    Dim connection As New SqlConnection(configuracion.ConnectionString)

    Private _tabla As String

    Public Sub New(tabla As String)
        _tabla = tabla

    End Sub

    Public Function ejecutarSQL(codigoSQL As String) As DataSet
        dataAdapter = New SqlDataAdapter()
        Dim sqli As New SqlCommand(codigoSQL, connection)
        dataAdapter.SelectCommand = sqli
        dataSet = New DataSet()
        dataSet.Clear()
        connection.Open()
        dataAdapter.Fill(dataSet, _tabla)
        connection.Close()

        Return dataSet
    End Function

End Class
