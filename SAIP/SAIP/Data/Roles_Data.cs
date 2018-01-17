using SAIP.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace SAIP.Data
{
    public class Roles_Data
    {
        #region VARIABLES GENERALES
        public static SqlConnection SqlCon = new SqlConnection(Conexion_Data.Cn);
        #endregion

        #region MÉTODOS O FUNCIONES
        #region Listar Roles
        public static List<Roles_Model> ListarRoles()
        {
            var Roles = new List<Roles_Model>();
            var DtResultados = new DataTable("Lista_Roles");

            try
            {
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand("spRoles_Listar", SqlCon);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter SqlDta = new SqlDataAdapter(SqlCmd);
                SqlDta.Fill(DtResultados);

                foreach (DataRow item in DtResultados.Rows)
                {
                    var obj = new Roles_Model()
                    {
                        IdRol = (int)item[0],
                        Descripcion = (string)item[1],
                        Estado = (int)item[2],
                        IdUsuario = (int)item[3],
                        FechaCreacion = (DateTime)item[4],
                        FechaActualizacion = (DateTime)item[5]
                    };
                    Roles.Add(obj);
                }
            }
            catch (Exception ex)
            {
                Roles = null;
                MessageBox.Show(ex.ToString(), "SAIP", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Roles;
        }
        #endregion
        #endregion
    }
}
