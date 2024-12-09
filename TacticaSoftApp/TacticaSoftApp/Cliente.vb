Public Class Cliente
    'Private _cliente As String
    'Private _telefono As String
    'Private _correo As String

    Private _baseConectada As Base

    'Public Sub New(cliente As String, telefono As String, correo As String)
    '    _cliente = cliente
    '    _telefono = telefono
    '    _correo = correo
    'End Sub
    Public Sub New(baseConectada As Base)
        _baseConectada = baseConectada
    End Sub
    '    _cliente = cliente
    '    _telefono = telefono
    '    _correo = correo
    'End Sub

    Public Function listarClientes() As DataSet
        Return _baseConectada.ejecutarSQL("SELECT Cliente,Telefono,Correo from clientes")
    End Function

    Public Function eliminarCliente(id As String) As DataSet
        Return _baseConectada.ejecutarSQL("DELETE FROM clientes WHERE id =" + id)
    End Function
End Class
