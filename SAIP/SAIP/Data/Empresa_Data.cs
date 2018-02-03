using SAIP.Helpers;
using SAIP.Model;
using SAIP.Service.DialogService;
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
    public class Empresa_Data
    {
        #region VARIABLES GENERALES
        private static SqlConnection SqlCon = new SqlConnection(Conexion_Data.Cn);
        #endregion

        #region MÉTODOS
        #region Mostrar Datos de la Empresa
        public static List<Empresa_Model> DatosEmpresa()
        {
            var Empresa = new List<Empresa_Model>();
            var dtEmpresa = new DataTable("Datos_Empresa");
            try
            {
                //Abrir Conexión con la Base de Datos
                SqlCon.Open();

                //Establecer los comandos para la comunicación con la BD
                SqlCommand SqlCmd = new SqlCommand("Select * From vEmpresa_Datos", SqlCon);
                SqlCmd.CommandType = CommandType.Text;
                
                //Ejecutar Consulta a la Base de Datos
                SqlDataAdapter SqlDta = new SqlDataAdapter(SqlCmd);
                SqlDta.Fill(dtEmpresa);

                foreach (DataRow item in dtEmpresa.Rows)
                {
                    var obj = new Empresa_Model()
                    {
                        RazonSocial = (string)item["razonSocial"],
                        Rubro = (string)item["rubro"],
                        Encargado = (string)item["encargado"],
                        Aniversario = (DateTime)item["aniversario"],
                        Logo = item["logo"] is DBNull ? null : Accesoria.ByteToImage((byte[])item["logo"])
                    };
                    Empresa.Add(obj);
                }
            }
            catch (Exception ex)
            {
                Empresa = null;
                MessageBox.Show(ex.ToString(), "SAIP", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                //Cerrar conexion con la base de datos
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Empresa;
        }
        #endregion

        #region Editar Datos de la Empresa
        public static Boolean Editar(Empresa_Model Emp)
        {
            var valor = false;
            try
            {
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand("spEmpresa_Editar", SqlCon);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlParameter[] SqlParams = new SqlParameter[5];
                SqlParams[0] = new SqlParameter("@razonsocial", Emp.RazonSocial);
                SqlParams[1] = new SqlParameter("@aniversario", Emp.Aniversario);
                SqlParams[2] = new SqlParameter("@rubro", Emp.Rubro);
                SqlParams[3] = new SqlParameter("@encargado", Emp.Encargado);
                SqlParams[4] = new SqlParameter("@logo", Accesoria.ImageToByte(Emp.Logo as BitmapImage));
                SqlCmd.Parameters.AddRange(SqlParams);

                valor = SqlCmd.ExecuteNonQuery() == 1 ? true : false;
            }
            catch (Exception ex)
            {
                valor = false;
                DialogService.Instance.MostrarMensaje(ex.ToString(), "Error Sql Server", "Ok", "Error");
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return valor;
        }
        #endregion
        #endregion
    }
}
