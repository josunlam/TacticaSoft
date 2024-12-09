Public Class Venta


    Private _baseConectada As Base
    Public Sub New(baseConectada As Base)
        _baseConectada = baseConectada
    End Sub

    Public Function listarVentas() As DataSet
        Return _baseConectada.ejecutarSQL("SELECT * from ventas")
    End Function

    Public Function eliminarVenta(id As String) As DataSet
        Return _baseConectada.ejecutarSQL("DELETE FROM ventas WHERE id =" + id)
    End Function
End Class
