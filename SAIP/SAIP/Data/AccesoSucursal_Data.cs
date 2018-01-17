using SAIP.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace SAIP.Data
{
    public class AccesoSucursal_Data
    {
        #region VARIABLES GENERALES
        public static SqlConnection SqlCon = new SqlConnection(Conexion_Data.Cn);
        public static DataTable DtResultados = new DataTable("Acceso_a_Sucursales");
        #endregion

        #region MÉTODOS 

        #region Mostrar Acceso a Sucursales
        public static List<AccesoSucursal_Model> Accesos()
        {
            var Acceso = new List<AccesoSucursal_Model>();

            try
            {
                //Abrir Conexión con la Base de Datos
                SqlCon.Open();
            
                //Establecer los comandos para la comunicación con la BD
                SqlCommand SqlCmd = new SqlCommand("Select * From viAccesosSucursales", SqlCon);
                SqlCmd.CommandType = CommandType.Text;
                
                //Ejecutar Consulta a la Base de Datos
                SqlDataAdapter SqlDta = new SqlDataAdapter(SqlCmd);
                SqlDta.Fill(DtResultados);

                //Volcar los datos de Acceso a la Lista
                foreach (DataRow item in DtResultados.Rows)
                {
                    var obj = new AccesoSucursal_Model()
                    {
                        IdUsuario = (int)item[0],
                        IdSucursal = (int)item[1],
                        Acceso = (int)item[2],
                        IdUsuarioA = (int)item[3],
                        FechaCreacion = (DateTime)item[4],
                        FechaActualizacion = (DateTime)item[5],
                        RazonSocial = (string)item[6]   
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

        #region Sucursales Activas para el Usuario Especificado
        public static List<DataRow[]> SucursalActivas(int IdUsuario)
        {
            //Crear variables para guardar los datos
            var _SucursalActiva = new List<DataRow[]>();
            
            //Filtrar el DataTable por el IdUsuario
            var SucursalFilter = DtResultados.Select("idUsuario='" + IdUsuario + "'");
            
            try
            {
                foreach (DataRow item in SucursalFilter)
                {
                    var i = 0;
                    var NewRow = new DataRow[1];
                    NewRow[i] = item;
                    i++;
                    _SucursalActiva.Add(NewRow);
                }
                return _SucursalActiva;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(),"SAIP",MessageBoxButton.OK,MessageBoxImage.Error);
                return _SucursalActiva = null;
            }
        }
        #endregion

        #endregion
    }
}
