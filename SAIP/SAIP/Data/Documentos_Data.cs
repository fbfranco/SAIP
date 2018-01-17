using SAIP.Model;
using SAIP.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace SAIP.Data
{
    public class Documentos_Data
    {
        #region VARIABLES GENERALES
        public static SqlConnection SqlCon = new SqlConnection(Conexion_Data.Cn);
        #endregion

        #region MÉTODOS O FUNCIONES
        #region Listar Documentos
        public static List<Documentos_Model> ListarDocumentos()
        {
            var Documentos = new List<Documentos_Model>();
            var DtResultados = new DataTable("Lista_Documentos");

            try
            {
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand("spDocumentos_Listar", SqlCon);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter SqlDta = new SqlDataAdapter(SqlCmd);
                SqlDta.Fill(DtResultados);

                foreach (DataRow item in DtResultados.Rows)
                {
                    var obj = new Documentos_Model()
                    {
                        IdDocumento = (int)item[0],
                        Nombre = (string)item[1],
                        Tipo = (string)item[2],
                        Estado = (int)item[3],
                        IdUsuario = (int)item[4],
                        FechaCreacion = (DateTime)item[5],
                        FechaActualizacion = (DateTime)item[6]
                    };
                    Documentos.Add(obj);
                }
            }
            catch (Exception ex)
            {
                Documentos = null;
                MessageBox.Show(ex.ToString(), "SAIP", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Documentos;
        }
        #endregion

        #region Guardar Documento
        public static Boolean Guardar(Documentos_Model Dcto)
        {
            Boolean Valor = false;
            try
            {
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand("spDocumentos_Insertar", SqlCon);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlParameter[] SqlParam = new SqlParameter[3];
                SqlParam[0] = new SqlParameter("@nombre", Dcto.Nombre);
                SqlParam[1] = new SqlParameter("@tipo", Dcto.Tipo);
                SqlParam[2] = new SqlParameter("@idusuario", Login_ViewModel.IdUsuario);
                SqlCmd.Parameters.AddRange(SqlParam);
                Valor = SqlCmd.ExecuteNonQuery() == 1 ? true : false;
            }
            catch (Exception ex)
            {
                Valor = false;
                MessageBox.Show(ex.ToString(), "SAIP", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Valor;
        }
        #endregion

        #region Editar Documento
        public static Boolean Editar(Documentos_Model Dcto)
        {
            Boolean Valor = false;
            try
            {
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand("spDocumentos_Editar", SqlCon);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlParameter[] SqlParam = new SqlParameter[3];
                SqlParam[0] = new SqlParameter("@iddocumento", Dcto.IdDocumento);
                SqlParam[1] = new SqlParameter("@nombre", Dcto.Nombre);
                SqlParam[2] = new SqlParameter("@tipo", Dcto.Tipo);
                SqlCmd.Parameters.AddRange(SqlParam);
                Valor = SqlCmd.ExecuteNonQuery() == 1 ? true : false;
            }
            catch (Exception ex)
            {
                Valor = false;
                MessageBox.Show(ex.ToString(), "SAIP", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Valor;
        }
        #endregion

        #region Eliminar Documento
        public static Boolean Eliminar(Documentos_Model Dcto)
        {
            Boolean Valor = false;
            try
            {
                SqlCon.Open();
                SqlCommand SqlCmd = new SqlCommand("spDocumentos_Eliminar", SqlCon);
                SqlCmd.CommandType = CommandType.StoredProcedure;
                SqlParameter[] SqlParam = new SqlParameter[1];
                SqlParam[0] = new SqlParameter("@iddocumento", Dcto.IdDocumento);
                SqlCmd.Parameters.AddRange(SqlParam);
                Valor = SqlCmd.ExecuteNonQuery() == 1 ? true : false;
            }
            catch (Exception ex)
            {
                Valor = false;
                MessageBox.Show(ex.ToString(), "SAIP", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Valor;
        }
        #endregion
        #endregion
    }
}
