Public Class Producto
    'Dim conexionBD = New Base()

    'Private _nombre As String
    'Private _precio As String
    'Private _categoria As String
    Private _baseConectada As Base
    Public Sub New(baseConectada As Base)
        _baseConectada = baseConectada
    End Sub

    Public Function listarProductos() As DataSet
        Return _baseConectada.ejecutarSQL("SELECT id,Nombre,Precio,Categoria from productos")
    End Function

    Public Function eliminarProducto(id As String) As DataSet
        Return _baseConectada.ejecutarSQL("DELETE FROM productos WHERE id =" + id)
    End Function

    Public Function insertarProducto(nombre As String, precio As String, categoria As String) As DataSet
        Return _baseConectada.ejecutarSQL("INSERT INTO productos (Nombre,Precio,Categoria)" + "VALUES('" + nombre + "'," + precio + ",'" + categoria + "')")
    End Function

    Public Function modificarProducto(id As String, nombre As String, precio As String, categoria As String) As DataSet
        Return _baseConectada.ejecutarSQL("UPDATE productos SET Nombre = '" + nombre + "', Precio = " + precio + ", Categoria ='" + categoria + "' WHERE id=" + id)
    End Function
End Class
