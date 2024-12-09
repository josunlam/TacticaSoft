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
        conexionBD = New Base("ventasItem")
        ventas = New Venta(conexionBD)

        dataSet = ventas.listarVentasItem()

        Me.DataGridView1.DataSource = dataSet
        Me.DataGridView1.DataMember = "ventasItem"
    End Sub

    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged
        radioButtonFocus = 4
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

        Dim var0 As String = DataGridView1.Rows(index - 1).Cells(0).Value.ToString()
        Dim var1 As String = DataGridView1.Rows(index - 1).Cells(1).Value.ToString()
        Select Case radioButtonFocus
            Case 1
                conexionBD = New Base("clientes")
                clientes = New Cliente(conexionBD)
                dataSet = clientes.eliminarCliente(var0)
                RadioButton2.PerformClick() : RadioButton1.PerformClick()
            Case 2
                conexionBD = New Base("productos")
                productos = New Producto(conexionBD)
                dataSet = productos.eliminarProducto(var0)
                RadioButton1.PerformClick() : RadioButton2.PerformClick()
            Case 3
                conexionBD = New Base("ventasItem")
                ventas = New Venta(conexionBD)
                dataSet = ventas.eliminarVentaItem(var0)
                RadioButton1.PerformClick() : RadioButton3.PerformClick()

                'Esto obtiene por medio del group by la suma de todos los IDVenta
                'de la Tabla Ventas
                Dim sumaTotalIdVenta As String
                sumaTotalIdVenta = ventas.obtenerTotalIdVenta(var1)

                dataSet = ventas.modificarVentas(var1, sumaTotalIdVenta)

                RadioButton1.PerformClick() : RadioButton3.PerformClick()
            Case 4
                conexionBD = New Base("ventas")
                ventas = New Venta(conexionBD)
                dataSet = ventas.eliminarVenta(var0)
                RadioButton1.PerformClick() : RadioButton4.PerformClick()
        End Select

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim index As Integer
        index = DataGridView1.CurrentCell.RowIndex + 1


        Dim var1 As String = DataGridView1.Rows(index - 1).Cells(1).Value.ToString()
        Dim var2 As String = DataGridView1.Rows(index - 1).Cells(2).Value.ToString()
        Dim var3 As String = DataGridView1.Rows(index - 1).Cells(3).Value.ToString()
        Dim var4 As String = DataGridView1.Rows(index - 1).Cells(4).Value.ToString()

        Select Case radioButtonFocus
            Case 1
                conexionBD = New Base("clientes")
                clientes = New Cliente(conexionBD)
                dataSet = clientes.insertarCliente(var1, var2, var3)
                RadioButton2.PerformClick() : RadioButton1.PerformClick()
            Case 2
                conexionBD = New Base("productos")
                productos = New Producto(conexionBD)
                dataSet = productos.insertarProducto(var1, var2, var3)
                RadioButton1.PerformClick() : RadioButton2.PerformClick()
            Case 3
                conexionBD = New Base("ventasItem")
                ventas = New Venta(conexionBD)
                dataSet = ventas.insertarVentaItem(var1, var2, var3, var4, var3 * var4)

                'Esto obtiene por medio del group by la suma de todos los IDVenta
                'de la Tabla Ventas
                Dim sumaTotalIdVenta As String
                sumaTotalIdVenta = ventas.obtenerTotalIdVenta(var1)

                dataSet = ventas.modificarVentas(var1, sumaTotalIdVenta)

                RadioButton1.PerformClick() : RadioButton3.PerformClick()
        End Select
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim index As Integer
        index = DataGridView1.CurrentCell.RowIndex + 1

        Dim var0 As String = DataGridView1.Rows(index - 1).Cells(0).Value.ToString()
        Dim var1 As String = DataGridView1.Rows(index - 1).Cells(1).Value.ToString()
        Dim var2 As String = DataGridView1.Rows(index - 1).Cells(2).Value.ToString()
        Dim var3 As String = DataGridView1.Rows(index - 1).Cells(3).Value.ToString()
        Dim var4 As String = DataGridView1.Rows(index - 1).Cells(4).Value.ToString()
        Dim var5 As String = (DataGridView1.Rows(index - 1).Cells(3).Value * DataGridView1.Rows(index - 1).Cells(4).Value).ToString

        Select Case radioButtonFocus
            Case 1
                conexionBD = New Base("clientes")
                clientes = New Cliente(conexionBD)
                dataSet = clientes.modificarCliente(var0, var1, var2, var3)
                RadioButton2.PerformClick() : RadioButton1.PerformClick()
            Case 2
                conexionBD = New Base("productos")
                productos = New Producto(conexionBD)
                dataSet = productos.modificarProducto(var0, var1, var2, var3)
                RadioButton1.PerformClick() : RadioButton2.PerformClick()
            Case 3
                conexionBD = New Base("ventas")
                ventas = New Venta(conexionBD)
                dataSet = ventas.modificarVentasItem(var0, var1, var2, var3, var4, var5)

                'Esto obtiene por medio del group by la suma de todos los IDVenta
                'de la Tabla Ventas
                Dim sumaTotalIdVenta As String
                sumaTotalIdVenta = ventas.obtenerTotalIdVenta(var1)

                dataSet = ventas.modificarVentas(var1, sumaTotalIdVenta)
                RadioButton1.PerformClick() : RadioButton3.PerformClick()
        End Select
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim index As Integer
        index = DataGridView1.CurrentCell.RowIndex + 1

        Select Case radioButtonFocus
            Case 1
                conexionBD = New Base("clientes")
                clientes = New Cliente(conexionBD)

                dataSet = clientes.filtrarCliente(TextBox1.Text)

                'Dim dv As DataView = dataSet.Tables(0).DefaultView
                'dv.RowFilter = "cliente='Pepe'"
                'DataGridView1.DataSource = dv
                'DataGridView1.DataBindings()

                'dataSet.row = String.Format("NOMBRE like '%{0}%'", t_buscar.Text)
                'RadioButton2.PerformClick() : RadioButton1.PerformClick()
                'Case 2
                '    conexionBD = New Base("productos")
                '    productos = New Producto(conexionBD)
                '    dataSet = productos.modificarProducto(var0, var1, var2, var3)
                '    RadioButton1.PerformClick() : RadioButton2.PerformClick()
                'Case 3
                '    conexionBD = New Base("ventas")
                '    ventas = New Venta(conexionBD)
                '    dataSet = ventas.modificarVentasItem(var0, var1, var2, var3, var4, var5)

                '    'Esto obtiene por medio del group by la suma de todos los IDVenta
                '    'de la Tabla Ventas
                '    Dim sumaTotalIdVenta As String
                '    sumaTotalIdVenta = ventas.obtenerTotalIdVenta(var1)

                '    dataSet = ventas.modificarVentas(var1, sumaTotalIdVenta)
                '    RadioButton1.PerformClick() : RadioButton3.PerformClick()
        End Select
    End Sub
End Class
