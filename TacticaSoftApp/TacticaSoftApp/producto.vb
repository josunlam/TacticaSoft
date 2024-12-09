Public Class Producto
    'Dim conexionBD = New Base()

    'Private _nombre As String
    'Private _precio As String
    'Private _categoria As String
    Private _baseConectada As Base
    Public Sub New(baseConectada As Base)
        _baseConectada = baseConectada
    End Sub

    'Public Function insertarProducto()
    'DataSet = conexionBD.ejecutarSQL("SELECT * from ventas")
    'Return DataSet
    'End Function

    Public Function listarProductos() As DataSet
        Return _baseConectada.ejecutarSQL("SELECT Nombre,Precio,Categoria from productos")
    End Function

    Public Function eliminarProducto(id As String) As DataSet
        Return _baseConectada.ejecutarSQL("DELETE FROM productos WHERE id =" + id)
    End Function
End Class
