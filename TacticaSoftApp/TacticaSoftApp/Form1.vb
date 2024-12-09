Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration

Public Class Form1
    Private dataSet As DataSet
    Dim conexionBD
    Dim clientes
    Dim productos
    Dim ventas
    Dim radioButtonFocus As Integer

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RadioButton1.PerformClick()
        DataGridView1.MultiSelect = False
        DataGridView1.ReadOnly = 1
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        radioButtonFocus = 1
        conexionBD = New Base("clientes")
        clientes = New Cliente(conexionBD)

        dataSet = clientes.listarClientes()

        Me.DataGridView1.DataSource = dataSet
        Me.DataGridView1.DataMember = "clientes"

    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        radioButtonFocus = 2
        conexionBD = New Base("productos")
        productos = New Producto(conexionBD)

        dataSet = productos.listarProductos()

        Me.DataGridView1.DataSource = dataSet
        Me.DataGridView1.DataMember = "productos"
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        radioButtonFocus = 3
        conexionBD = New Base("ventas")
        ventas = New Venta(conexionBD)

        dataSet = ventas.listarVentas()

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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim index As Integer
        index = DataGridView1.CurrentCell.RowIndex + 1

        Select Case radioButtonFocus
            Case 1
                conexionBD = New Base("clientes")
                clientes = New Cliente(conexionBD)
                dataSet = clientes.eliminarCliente(index)
                RadioButton2.PerformClick() : RadioButton1.PerformClick()
            Case 2
                conexionBD = New Base("productos")
                productos = New Producto(conexionBD)
                dataSet = productos.eliminarProducto(index)
                RadioButton1.PerformClick() : RadioButton2.PerformClick()
            Case 3
                conexionBD = New Base("ventas")
                ventas = New Venta(conexionBD)
                dataSet = ventas.eliminarVenta(index)
                RadioButton1.PerformClick() : RadioButton3.PerformClick()
        End Select

        'Me.DataGridView1.DataSource = dataSet
        'Me.DataGridView1.DataMember = "clientes"
    End Sub

    'Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
    '    Dim numero As Integer
    '    Dim nRowIndex = DataGridView1.Rows.Count - 2

    '    If RadioButton1.Checked Then numero = 0 'Tratara la tabla clientes
    '    If RadioButton2.Checked Then numero = 1 'Tratará la tabla productos
    '    If RadioButton3.Checked Then numero = 2 'Tratar{a la tabla ventas

    '    Dim var1 As String = DataGridView1.Rows(nRowIndex).Cells(0).Value.ToString()
    '    Dim var2 As String = DataGridView1.Rows(nRowIndex).Cells(1).Value.ToString()
    '    Dim var3 As String = DataGridView1.Rows(nRowIndex).Cells(2).Value.ToString()

    'dataSet = conexionBD.ejecutarSQL("SELECT Cliente,Telefono,Correo from clientes")

    'Me.DataGridView1.DataSource = dataSet
    'Me.DataGridView1.DataMember = "clientes"

    '    Select Case numero
    '        Case 0
    '            Dim producto = New Producto(var1, var2, var3)
    '            producto.insertarProducto()

    '    End Select

    '    darAlta()

    '    'If RadioButton Then
    'End Sub

    'Private Sub darAlta()
    '    Dim numero As Integer
    '    Dim nRowIndex = DataGridView1.Rows.Count - 2
    '    'Dim nCol = DataGridView1.Columns.Count

    '    If RadioButton1.Checked Then numero = 0
    '    If RadioButton2.Checked Then numero = 1
    '    If RadioButton3.Checked Then numero = 2



    '    Select Case numero
    '        Case 0
    '            TextBox1.Text = "INSERT INTO clientes (Cliente,Telefono,Correo)" +
    '                            "VALUES('" + var1 + "'," + var2 + ",'" + var3 + "')"
    '            dataAdapter = New SqlDataAdapter()
    '            Dim sqli As New SqlCommand(TextBox1.Text, connection)
    '            dataAdapter.SelectCommand = sqli
    '            dataSet = New DataSet()
    '            dataSet.Clear()
    '            connection.Open()
    '            dataAdapter.Fill(dataSet, "clientes")
    '            connection.Close()

    '            RadioButton2.PerformClick() : RadioButton1.PerformClick()
    '        Case 1
    '            TextBox1.Text = "INSERT INTO productos (Nombre,Precio,Categoria)" +
    '                            "VALUES('" + var1 + "'," + var2 + ",'" + var3 + "')"
    '            dataAdapter = New SqlDataAdapter()
    '            Dim sqli As New SqlCommand(TextBox1.Text, connection)
    '            dataAdapter.SelectCommand = sqli
    '            dataSet = New DataSet()
    '            dataSet.Clear()
    '            connection.Open()
    '            dataAdapter.Fill(dataSet, "productos")
    '            connection.Close()

    '            RadioButton1.PerformClick() : RadioButton2.PerformClick()
    '        Case 2
    '            TextBox1.Text = "INSERT INTO ventas (Fecha,Total)" +
    '                            "VALUES('" + var1 + "'," + var2 + ")"
    '            dataAdapter = New SqlDataAdapter()
    '            Dim sqli As New SqlCommand(TextBox1.Text, connection)
    '            dataAdapter.SelectCommand = sqli
    '            dataSet = New DataSet()
    '            dataSet.Clear()
    '            connection.Open()
    '            dataAdapter.Fill(dataSet, "ventas")
    '            connection.Close()

    '            RadioButton1.PerformClick() : RadioButton3.PerformClick()
    '    End Select

    'End Sub
End Class
