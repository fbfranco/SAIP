using SAIP.Helpers;
using SAIP.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SAIP.Data
{
    public class Login_Data
    {
        public static List<Login_Model> Login(string v1, string v2)
        {
            var Usuario = new List<Login_Model>();
            SqlConnection SqlCon = new SqlConnection(Conexion_Data.Cn);
            try
            {
                //Conectando co la DB y volcando los datos en el DataTable
                var UsuariosRegistrados = new DataTable("Usuario_Logueado");
                SqlCon.Open();

                //Estableciendo el Comando para la comunicación con la BD
                var SqlCmd = new SqlCommand("spUsuario_Login", SqlCon);
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Estableciendo y pasando los parámetros del Procedimiento Almacenado
                SqlParameter SqlParUsername = new SqlParameter("@username",v1);
                SqlCmd.Parameters.Add(SqlParUsername);

                SqlParameter ParPassword = new SqlParameter("@password", v2);
                SqlCmd.Parameters.Add(ParPassword);
                
                //Volcando los datos de la BD en la tabla
                var SqlDa = new SqlDataAdapter(SqlCmd);
                SqlDa.Fill(UsuariosRegistrados);

                //Volcar los datos del DataTabe a los campos del Modelo
                foreach (DataRow row in UsuariosRegistrados.Rows)
                {
                    var obj = new Login_Model()
                    {
                        IdUsuario = (int)row["id"],
                        UserName = (string)row["username"],
                        TipoUsuario = (string)row["tipousuario"],
                        Imagen = Accesoria.ByteToImage((byte[])row["img"])
                    };
                    Usuario.Add(obj);
                }
                return Usuario;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "SAIP", MessageBoxButton.OK, MessageBoxImage.Error);
                return Usuario = null;
            }
            finally
            {
                //Cerrar la conexion con la Base de Datos
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
        }
    }
}
