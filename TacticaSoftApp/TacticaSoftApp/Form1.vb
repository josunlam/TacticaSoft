Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Public Class Form1
    Private dataSet As DataSet
    Private dataAdapter As SqlDataAdapter

    Protected configuracion As ConnectionStringSettings = ConfigurationManager.ConnectionStrings("connect")
    Dim connection As New SqlConnection(configuracion.ConnectionString)

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = "SELECT * from clientes where id=1"
        dataAdapter = New SqlDataAdapter()
        Dim sqli As New SqlCommand(TextBox1.Text, connection)
        dataAdapter.SelectCommand = sqli
        dataSet = New DataSet()
        dataSet.Clear()
        connection.Open()
        dataAdapter.Fill(dataSet, "clientes")
        connection.Close()
        Me.DataGridView1.DataSource = dataSet
        Me.DataGridView1.DataMember = "clientes"
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class
