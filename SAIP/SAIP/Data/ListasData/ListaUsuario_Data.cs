using SAIP.Helpers;
using SAIP.Model.ListaModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace SAIP.Data.ListasData
{
    public class ListaUsuario_Data
    {
        #region VARIABLES GENERALES
        public static SqlConnection SqlCon = new SqlConnection(Conexion_Data.Cn);
        public static DataTable DtResultados = new DataTable("Usuarios");
        #endregion

        #region MÉTODOS O FUNCIONES PARA LA INTERACCIÓN CON LA BASE DE DATOS 
        #region Método para Mostrar o Listar los Usuarios 
        public static List<ListaUsuario_Model> ListarUsuarios(string Campo, string Buscar)
        {
            var Acceso = new List<ListaUsuario_Model>();

            try
            {
                //Abrir Conexión con la Base de Datos
                SqlCon.Open();

                //Establecer los comandos para la comunicación con la BD
                SqlCommand SqlCmd = new SqlCommand("spUsuarios_Listar", SqlCon);
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter CampoParameter = new SqlParameter("Campo", Campo);
                SqlCmd.Parameters.Add(CampoParameter);
                SqlParameter BusrcarParameter = new SqlParameter("Buscar", Buscar);
                SqlCmd.Parameters.Add(BusrcarParameter);

                //Ejecutar Consulta a la Base de Datos
                SqlDataAdapter SqlDta = new SqlDataAdapter(SqlCmd);
                DtResultados.Clear();
                SqlDta.Fill(DtResultados);

                //Volcar los datos de Acceso a la Lista
                Acceso.Clear();
                foreach (DataRow item in DtResultados.Rows)
                {
                    var obj = new ListaUsuario_Model()
                    {
                        IdUsuario = (int)item[0],
                        IdPersona = (int)item[1],
                        IdRol = (int)item[2],
                        RolTipo = (string)item[3],
                        Usuario = (string)item[4],
                        Password = (string)item[5],
                        NombreCompleto = (string)item[6],
                        Nombre = (string)item[7],
                        ApPaterno = (string)item[8],
                        ApMaterno = (string)item[9],
                        IdDocumento = (int)item[10],
                        NroDocumento = (string)item[11],
                        Imagen = Accesoria.ByteToImage((byte[])item[12])
                    };

                    Acceso.Add(obj);
                }
            }
            catch (Exception ex)
            {
                DtResultados = null;
                MessageBox.Show(ex.ToString(), "SAIP", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                //Cerrar conexion con la base de datos
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Acceso;
        }
        #endregion
        #endregion
    }
}
