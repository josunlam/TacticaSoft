Public Class Venta


    Private _baseConectada As Base
    Public Sub New(baseConectada As Base)
        _baseConectada = baseConectada
    End Sub

    Public Function listarVentasItem() As DataSet
        Return _baseConectada.ejecutarSQL("SELECT id,idVenta,idProducto,PrecioUnitario,Cantidad,PrecioTotal from ventasitems")
    End Function

    Public Function listarVentas() As DataSet
        Return _baseConectada.ejecutarSQL("SELECT id,idCliente,Fecha,Total from ventas")
    End Function

    'ToDo
    'Public Function insertarVenta(cliente As String, telefono As String, correo As String) As DataSet
    '    Return _baseConectada.ejecutarSQL("INSERT INTO clientes (idCliente,Telefono,Correo)" + "VALUES('" + cliente + "'," + telefono + ",'" + correo + "')")
    'End Function

    Public Function insertarVentaItem(idVenta As String, iDProducto As String, precioUnitario As String, cantidad As String, precioTotal As String) As DataSet
        Return _baseConectada.ejecutarSQL("INSERT INTO ventasItems (IDVenta, IDProducto,PrecioUnitario,Cantidad,PrecioTotal)" + "VALUES(" + idVenta + "," + iDProducto + "," + precioUnitario + "," + cantidad + "," + precioTotal + ")")
    End Function

    Public Function eliminarVentaItem(id As String) As DataSet
        Return _baseConectada.ejecutarSQL("DELETE FROM ventasitems WHERE id =" + id)
    End Function

    Public Function eliminarVenta(id As String) As DataSet
        Return _baseConectada.ejecutarSQL("DELETE FROM ventas WHERE id =" + id)
    End Function

    Public Function modificarVentasItem(id As String, idVenta As String, idProducto As String, precioUniario As String, cantidad As String, operacion As String) As DataSet

        Return _baseConectada.ejecutarSQL("UPDATE ventasitems SET IDVenta = " + idVenta + ", IDProducto = " + idProducto + ", PrecioUnitario =" + precioUniario + ", Cantidad =" + cantidad + ", PrecioTotal =" + operacion + " WHERE id=" + id)
    End Function

    Public Function obtenerTotalIdVenta(idVenta As String) As String
        Dim dataSetAux As DataSet
        Dim dataSetValue As String = "2000"

        dataSetAux = _baseConectada.ejecutarSQL("select SUM(PrecioTotal) from ventasitems where IDVenta=" + idVenta + " group by IDVenta")
        'foreach(DataRow dr In tuDataset.Table[0].Rows)
        For Each dr As DataRow In dataSetAux.Tables(0).Rows
            dataSetValue = dr(0).ToString()
        Next
        Return dataSetValue
    End Function

    Public Function modificarVentas(idVenta As String, sumaTotal As String) As DataSet
        Return _baseConectada.ejecutarSQL("UPDATE ventas SET Total = " + sumaTotal + "WHERE id=" + idVenta)
    End Function

End Class
