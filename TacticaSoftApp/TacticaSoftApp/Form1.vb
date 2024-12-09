Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Public Class Form1
    Private dataSet As DataSet
    Private dataAdapter As SqlDataAdapter

    Protected configuracion As ConnectionStringSettings = ConfigurationManager.ConnectionStrings("connect")
    Dim connection As New SqlConnection(configuracion.ConnectionString)

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        RadioButton1.PerformClick()
        DataGridView1.MultiSelect = False
        DataGridView1.ReadOnly = 1
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect

    End Sub



    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged


        TextBox1.Text = "SELECT Cliente,Telefono,Correo from clientes"
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

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        TextBox1.Text = "SELECT Nombre,Precio,Categoria from productos"
        dataAdapter = New SqlDataAdapter()
        Dim sqli As New SqlCommand(TextBox1.Text, connection)
        dataAdapter.SelectCommand = sqli
        dataSet = New DataSet()
        dataSet.Clear()
        connection.Open()
        dataAdapter.Fill(dataSet, "productos")
        connection.Close()
        Me.DataGridView1.DataSource = dataSet
        Me.DataGridView1.DataMember = "productos"
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        TextBox1.Text = "SELECT * from ventas"
        dataAdapter = New SqlDataAdapter()
        Dim sqli As New SqlCommand(TextBox1.Text, connection)
        dataAdapter.SelectCommand = sqli
        dataSet = New DataSet()
        dataSet.Clear()
        connection.Open()
        dataAdapter.Fill(dataSet, "ventas")
        connection.Close()
        Me.DataGridView1.DataSource = dataSet
        Me.DataGridView1.DataMember = "ventas"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim nRowIndex = DataGridView1.Rows.Count - 1
        DataGridView1.ReadOnly = False

        DataGridView1.CurrentCell = DataGridView1.Rows(nRowIndex).Cells(0)
        DataGridView1.BeginEdit(True)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        DataGridView1.ReadOnly = False
        DataGridView1.BeginEdit(True)

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        darAlta()
    End Sub

    Private Sub darAlta()
        Dim numero As Integer
        Dim nRowIndex = DataGridView1.Rows.Count - 2
        'Dim nCol = DataGridView1.Columns.Count

        If RadioButton1.Checked Then numero = 0
        If RadioButton2.Checked Then numero = 1
        If RadioButton3.Checked Then numero = 2

        Dim var1 As String = DataGridView1.Rows(nRowIndex).Cells(0).Value.ToString()
        Dim var2 As String = DataGridView1.Rows(nRowIndex).Cells(1).Value.ToString()
        Dim var3 As String = DataGridView1.Rows(nRowIndex).Cells(2).Value.ToString()

        Select Case numero
            Case 0
                TextBox1.Text = "INSERT INTO clientes (Cliente,Telefono,Correo)" +
                                "VALUES('" + var1 + "'," + var2 + ",'" + var3 + "')"
                dataAdapter = New SqlDataAdapter()
                Dim sqli As New SqlCommand(TextBox1.Text, connection)
                dataAdapter.SelectCommand = sqli
                dataSet = New DataSet()
                dataSet.Clear()
                connection.Open()
                dataAdapter.Fill(dataSet, "clientes")
                connection.Close()

                RadioButton2.PerformClick() : RadioButton1.PerformClick()
            Case 1
                TextBox1.Text = "INSERT INTO productos (Nombre,Precio,Categoria)" +
                                "VALUES('" + var1 + "'," + var2 + ",'" + var3 + "')"
                dataAdapter = New SqlDataAdapter()
                Dim sqli As New SqlCommand(TextBox1.Text, connection)
                dataAdapter.SelectCommand = sqli
                dataSet = New DataSet()
                dataSet.Clear()
                connection.Open()
                dataAdapter.Fill(dataSet, "productos")
                connection.Close()

                RadioButton1.PerformClick() : RadioButton2.PerformClick()
            Case 2
                TextBox1.Text = "INSERT INTO ventas (Fecha,Total)" +
                                "VALUES('" + var1 + "'," + var2 + ")"
                dataAdapter = New SqlDataAdapter()
                Dim sqli As New SqlCommand(TextBox1.Text, connection)
                dataAdapter.SelectCommand = sqli
                dataSet = New DataSet()
                dataSet.Clear()
                connection.Open()
                dataAdapter.Fill(dataSet, "ventas")
                connection.Close()

                RadioButton1.PerformClick() : RadioButton3.PerformClick()
        End Select

    End Sub
End Class
