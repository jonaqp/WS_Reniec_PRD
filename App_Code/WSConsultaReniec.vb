Imports System
Imports System.Data
Imports System.Data.Odbc
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports ClaseConexion
Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.IO

' Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente.
<System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://localhost/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class WSConsultaReniec
    Inherits System.Web.Services.WebService
    'El metodo de tipo Arraylist para que pueda tomar los datos de retorno
    <WebMethod()> _
    Public Function Datos_Persona(ByVal dni As String) As ArrayList
        Dim cmd As New SqlCommand
        Dim CN As New ClaseConexion
        Dim datos As New ArrayList
        Dim dts As New DataSet
        'Aqui aperturamos la conexión a la BD e invocamos el uso del Procedimiento Almacenado
        Dim da As New SqlDataAdapter("usp_DatosPersona", CN.getconexion)
        'Se indica que tipo de comando es y se asigna la variable que usara el Procedimiento Almacenado
        da.SelectCommand.CommandType = CommandType.StoredProcedure
        da.SelectCommand.Parameters.Add("@dni", SqlDbType.Char).Value = dni
        'Llenamos el dts
        da.Fill(dts, "persona")

        'Se retorna los valores de la consulta - retorna un DataSet
        'Return dts.Tables("persona")

        'Como sabemos un Dataset no es compatible con java asi que almacenamos el resultado en un Arraylist
        Try
            datos.Add(dts.Tables("persona").Rows(0)("dni_persona").ToString)
            datos.Add(dts.Tables("persona").Rows(0)("ape_pat").ToString)
            datos.Add(dts.Tables("persona").Rows(0)("ape_mat").ToString)
            datos.Add(dts.Tables("persona").Rows(0)("nombres").ToString)
            datos.Add(dts.Tables("persona").Rows(0)("fec_nacimiento").ToString)
        Catch ex As Exception
            'datos.Add("Desconocido")
            'Return datos
        End Try
        'Retornamos el Arreglo
        Return datos
    End Function

End Class