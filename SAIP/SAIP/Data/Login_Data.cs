using SAIP.Helpers;
using SAIP.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Media.Imaging;

namespace SAIP.Data
{
    public class Login_Data
    {
        /******Método para Login de los Usuarios******/
        public static List<Login_Model> Login(string v1, string v2)
        {
            var Usuario = new List<Login_Model>();
            SqlConnection SqlCon = new SqlConnection(Conexion_Data.Cn);
            try
            {
                DataTable UsuariosRegistrados = new DataTable("Usuario_Logueado");
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand("spUsuario_Login", SqlCon);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlParameter SqlParUsername = new SqlParameter("@username",v1);
                SqlCmd.Parameters.Add(SqlParUsername);
                SqlParameter ParPassword = new SqlParameter("@password", v2);
                SqlCmd.Parameters.Add(ParPassword);
                SqlDataAdapter SqlDa = new SqlDataAdapter(SqlCmd);
                SqlDa.Fill(UsuariosRegistrados);

                foreach (DataRow row in UsuariosRegistrados.Rows)
                {
                    var obj = new Login_Model()
                    {
                        IdUsuario = (int)row["id"],
                        UserName = (string)row["username"],
                        TipoUsuario = (string)row["tipousuario"],
                        Imagen = row["img"].Equals("") ? Accesoria.ByteToImage((byte[])row["img"]) : new BitmapImage(new Uri("pack://application:,,,/Resource/Images/Background/userDefault.png", UriKind.Absolute))
                    };
                    Usuario.Add(obj);
                }
                return Usuario;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "SAIP Bismarck franco Hoyos", MessageBoxButton.OK, MessageBoxImage.Error);
                return Usuario = null;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
        }
    }
}
