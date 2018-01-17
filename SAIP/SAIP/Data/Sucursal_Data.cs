using SAIP.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace SAIP.Data
{
    public class Sucursal_Data
    {
        #region SINGLETON
        private static Sucursal_Data Instance;
        public static Sucursal_Data GetInstance()
        {
            Instance = Instance == null ? new Sucursal_Data() : Instance;
            return Instance;
        }
        #endregion

        #region VARIABLES GENERALES
        public static SqlConnection SqlCon = new SqlConnection(Conexion_Data.Cn);
        #endregion

        #region MÉTODOS O FUNCIONES
        #region ListarSucursales
        public static List<Sucursal_Model> ListarSucursales()
        {
            var Sucursales = new List<Sucursal_Model>();
            var DtResultados = new DataTable("Lista_Sucursales");
            try
            {
                SqlCon.Open();
                var SqlCmd = new SqlCommand("spSucursales_ListarActivas", SqlCon);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                var SqlDta = new SqlDataAdapter(SqlCmd);
                SqlDta.Fill(DtResultados);

                foreach (DataRow item in DtResultados.Rows)
                {
                    var obj = new Sucursal_Model()
                    {
                        IdSucursal = (int)item[0],
                        RazonSocial = (string)item[1],
                        Direccion = item[2].ToString() == "" ? "" : (string)item[2],
                        Telefono = item[3].ToString() == "" ? "" : (string)item[3],
                        Encargado = item[4].ToString() == "" ? "" : (string)item[4],
                        Estado = (int)item[5],
                        IdUsuario = (int)item[6],
                        FechaCreacion = (DateTime)item[7],
                        FechaActualizacion = (DateTime)item[8]
                    };
                    Sucursales.Add(obj);
                }
            }
            catch (Exception ex)
            {
                Sucursales = null;
                MessageBox.Show(ex.ToString(),"SAIP",MessageBoxButton.OK,MessageBoxImage.Error);
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Sucursales;
        }
        #endregion
        #endregion
    }
}
