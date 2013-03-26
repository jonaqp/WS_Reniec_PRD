Imports System.Data.SqlClient
Imports System.Configuration.ConfigurationManager
Public Class ClaseConexion
    Private cn As New SqlConnection( _
           ConnectionStrings("cn").ConnectionString)

    Public ReadOnly Property getconexion() As SqlConnection
        Get
            Return cn
        End Get
    End Property

End Class