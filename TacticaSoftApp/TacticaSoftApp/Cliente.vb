Public Class Cliente
    'Private _cliente As String
    'Private _telefono As String
    'Private _correo As String

    Private _baseConectada As Base

    Public Sub New(baseConectada As Base)
        _baseConectada = baseConectada
    End Sub

    Public Function listarClientes() As DataSet
        Return _baseConectada.ejecutarSQL("SELECT id,Cliente,Telefono,Correo from clientes")
    End Function

    Public Function eliminarCliente(id As String) As DataSet
        Return _baseConectada.ejecutarSQL("DELETE FROM clientes WHERE id =" + id)
    End Function

    Public Function modificarCliente(id As String, cliente As String, telefono As String, correo As String) As DataSet
        Return _baseConectada.ejecutarSQL("UPDATE clientes SET Cliente = '" + cliente + "', Telefono = " + telefono + ", Correo ='" + correo + "' WHERE id=" + id)
    End Function

    Public Function insertarCliente(cliente As String, telefono As String, correo As String) As DataSet
        Return _baseConectada.ejecutarSQL("INSERT INTO clientes (Cliente,Telefono,Correo)" + "VALUES('" + cliente + "'," + telefono + ",'" + correo + "')")
    End Function

    Public Function filtrarCliente(cliente As String)
        Return _baseConectada.ejecutarSQL("SELECT id,Cliente,Telefono,Correo from clientes where cliente LIKE '" + cliente + "'")
    End Function
End Class
