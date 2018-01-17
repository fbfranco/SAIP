using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SAIP.Datos
{
    public class dtsUsuarios
    {
        //Declaracion de Variables
        private int _IdUsuario;
        private int _IdPersona;
        private int _IdRol;
        private string _Usuario;
        private string _Password;
        private byte[] _Imagen;
        private int _Estado;
        private DateTime _FechaCreacion;
        private DateTime _FechaActualizacion;
        private string _Campo;
        private string _Buscar;

        //Métodos Seter and Geter
        public int IdUsuario { get => _IdUsuario; set => _IdUsuario = value; }
        public int IdPersona { get => _IdPersona; set => _IdPersona = value; }
        public int IdRol { get => _IdRol; set => _IdRol = value; }
        public string Usuario { get => _Usuario; set => _Usuario = value; }
        public string Password { get => _Password; set => _Password = value; }
        public byte[] Imagen { get => _Imagen; set => _Imagen = value; }
        public int Estado { get => _Estado; set => _Estado = value; }
        public DateTime FechaCreacion { get => _FechaCreacion; set => _FechaCreacion = value; }
        public DateTime FechaActualizacion { get => _FechaActualizacion; set => _FechaActualizacion = value; }
        public string Campo { get => _Campo; set => _Campo = value; }
        public string Buscar { get => _Buscar; set => _Buscar = value; }

        //Constructor Vacío
        public dtsUsuarios() { }

        //Constructor Parametrizado
        public dtsUsuarios(int idusuario,
                         int idpersona,
                         int idrol,
                         string usuario,
                         string password,
                         byte[] imagen,
                         int estado,
                         DateTime fechacreacion,
                         DateTime fechaactualizacion,
                         string campo,
                         string buscar)
        {
            this.IdUsuario = idusuario;
            this.IdPersona = idpersona;
            this.IdRol = idrol;
            this.Usuario = usuario;
            this.Password = password;
            this.Imagen = imagen;
            this.Estado = estado;
            this.FechaCreacion = fechacreacion;
            this.FechaActualizacion = fechaactualizacion;
            this.Campo = campo;
            this.Buscar = buscar;
        }

        //Declaración de Variables Globales
        Boolean rpta;
        SqlConnection SqlCon = new SqlConnection(dtsConexion.Cn);

        //Método Generar IDPERSONA
        //public int GenerarIdPersona()
        //{
        //    int x;
        //    try
        //    {
        //        //Abriendo Conexion con la BD
        //        SqlCon.Open();

        //        //Estableciendo Comando para comunicación con la BD
        //        SqlCommand SqlCmd = new SqlCommand();
        //        SqlCmd.Connection = SqlCon;
        //        SqlCmd.CommandText = "select isnull(max(idPersona)+1,1) as Codigo from Personas";
        //        SqlCmd.CommandType = CommandType.Text;

        //        //Ejecutando Comando
        //        x = Convert.ToInt32(SqlCmd.ExecuteScalar());
        //    }
        //    catch (Exception ex)
        //    {
        //        x = 0;
        //        MessageBox.Show(ex.ToString(), "Error: SQL Server", MessageBoxButton.OK,MessageBoxImage.Error);
        //    }
        //    finally
        //    {
        //        //Cerrando conexion a la BD
        //        if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
        //    }
        //    return x;
        //}

        ////Método Insertar Registro
        //public Boolean InsertarUsuario(dtsUsuarios Usuarios, List<dtsPersonas> Personas)
        //{
        //    try
        //    {
        //        //Abriendo conexion a BD
        //        SqlCon.Open();

        //        //Establecer Transacción
        //        SqlTransaction SqlTra = SqlCon.BeginTransaction();

        //        //Estableciendo Comandos para comunicación con BD
        //        SqlCommand SqlCmd = new SqlCommand("spUsuarios_Insertar", SqlCon, SqlTra);
        //        SqlCmd.CommandType = CommandType.StoredProcedure;

        //        //Generando parámetros
        //        SqlParameter ParIdUsuario = new SqlParameter();
        //        ParIdUsuario.ParameterName = "@idusuario";
        //        ParIdUsuario.Direction = ParameterDirection.Output;
        //        ParIdUsuario.SqlDbType = SqlDbType.Int;
        //        SqlCmd.Parameters.Add(ParIdUsuario);

        //        SqlParameter ParIdPersona = new SqlParameter("@idpersona", Usuarios.IdPersona);
        //        SqlCmd.Parameters.Add(ParIdPersona);

        //        SqlParameter ParIdRol = new SqlParameter("@idrol", Usuarios.IdRol);
        //        SqlCmd.Parameters.Add(ParIdRol);

        //        SqlParameter ParUsuario = new SqlParameter("@usuario", Usuarios.Usuario);
        //        SqlCmd.Parameters.Add(ParUsuario);

        //        SqlParameter ParPassword = new SqlParameter("@password", Usuarios.Password);
        //        SqlCmd.Parameters.Add(ParPassword);

        //        SqlParameter ParImagen = new SqlParameter("@imagen", Usuarios.Imagen);
        //        SqlCmd.Parameters.Add(ParImagen);

        //        SqlParameter ParFechaCreacion = new SqlParameter("@fechacreacion", Usuarios.FechaCreacion);
        //        SqlCmd.Parameters.Add(ParFechaCreacion);

        //        SqlParameter ParFechaActualiacion = new SqlParameter("@fechaactualizacion", Usuarios.FechaActualizacion);
        //        SqlCmd.Parameters.Add(ParFechaActualiacion);

        //        //Ejecutando Comando para Transacciones con la BD
        //        rpta = SqlCmd.ExecuteNonQuery() == 1 ? true : false;

        //        if (rpta)
        //        {
        //            foreach (dtsPersonas per in Personas)
        //            {
        //                rpta = per.InsertarPersona(per, ref SqlCon, SqlTra);

        //                if (!rpta)
        //                {
        //                    break;
        //                }
        //            }
        //        }
        //        if (rpta)
        //        {
        //            SqlTra.Commit();
        //        }
        //        else
        //        {
        //            SqlTra.Rollback();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        rpta = false;
        //        MessageBox.Show(null, ex.ToString(), "Error: SQL Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        //Cerrando Conexion con la BD
        //        if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
        //    }
        //    return rpta;
        //}

        ////Método Editar Registro
        //public Boolean EditarUsuario(dtsUsuarios Usuarios, List<dtsPersonas> Personas)
        //{
        //    try
        //    {
        //        //Abriendo conexion a la BD
        //        SqlCon.Open();

        //        //Establecer Transacción
        //        SqlTransaction SqlTra = SqlCon.BeginTransaction();

        //        //Estableciendo Comando para la comunicacion con BD
        //        SqlCommand SqlCmd = new SqlCommand("spUsuarios_Editar", SqlCon, SqlTra);
        //        SqlCmd.CommandType = CommandType.StoredProcedure;
                            
        //        //Generando Parámetros
        //        SqlParameter ParIdUsuario = new SqlParameter("@idusuario", Usuarios.IdUsuario);
        //        SqlCmd.Parameters.Add(ParIdUsuario);

        //        SqlParameter ParIdrol = new SqlParameter("@idrol", Usuarios.IdRol);
        //        SqlCmd.Parameters.Add(ParIdrol);

        //        SqlParameter ParUsuario = new SqlParameter("@usuario", Usuarios.Usuario);
        //        SqlCmd.Parameters.Add(ParUsuario);

        //        SqlParameter ParaPassword = new SqlParameter("@password", Usuarios.Password);
        //        SqlCmd.Parameters.Add(ParaPassword);

        //        SqlParameter ParImagen = new SqlParameter("@imagen", Usuarios.Imagen);
        //        SqlCmd.Parameters.Add(ParImagen);

        //        SqlParameter ParFechaActualiacion = new SqlParameter("@fechaactualizacion", Usuarios.FechaActualizacion);
        //        SqlCmd.Parameters.Add(ParFechaActualiacion);

        //        //Ejecutando Comando para Transacciones con la BD
        //        rpta = SqlCmd.ExecuteNonQuery() == 1 ? true : false;

        //        if (rpta)
        //        {
        //            foreach (dtsPersonas per in Personas)
        //            {
        //                rpta = per.EditarPersona(per, ref SqlCon, ref SqlTra);

        //                if (!rpta)
        //                {
        //                    break;
        //                }
        //            }
        //        }
        //        if (rpta)
        //        {
        //            SqlTra.Commit();
        //        }
        //        else
        //        {
        //            SqlTra.Rollback();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        rpta = false;
        //        MessageBox.Show(null, ex.ToString(), "Error: SQL Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        //Cerrando Conexion con la BD
        //        if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
        //    }
        //    return rpta;
        //}

        ////Método Eliminar Registro
        //public Boolean EliminarUsuario(dtsUsuarios Usuarios)
        //{
        //    try
        //    {
        //        //Abriendo conexion a la BD
        //        SqlCon.Open();

        //        //Estableciendo Comando para la comunicación con la BD
        //        SqlCommand SqlCmd = new SqlCommand("spUsuarios_Eliminar", SqlCon);
        //        SqlCmd.CommandType = CommandType.StoredProcedure;

        //        //Generando Parámetros
        //        SqlParameter ParIdUsuario = new SqlParameter("@idusuario", Usuarios.IdUsuario);
        //        SqlCmd.Parameters.Add(ParIdUsuario);

        //        SqlParameter ParEstado = new SqlParameter("@estado", Usuarios.Estado);
        //        SqlCmd.Parameters.Add(ParEstado);

        //        SqlParameter ParFechaActualizacion = new SqlParameter("@fechaactualizacion", Usuarios._FechaActualizacion);
        //        SqlCmd.Parameters.Add(ParFechaActualizacion);

        //        //Ejecutando comando para transacciones con la BD
        //        rpta = SqlCmd.ExecuteNonQuery() == 1 ? true : false;
        //    }
        //    catch (Exception ex)
        //    {
        //        rpta = false;
        //        MessageBox.Show(null, ex.ToString(), "Error: SQL Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    return rpta;
        //}

        //Método Listar Registros
        public DataTable ListarUsuarios(dtsUsuarios Usuarios)
        {
            //Crear una nueva tabla
            DataTable dtResultado = new DataTable("Listado_Usuarios");

            try
            {
                //Abriendo conexion con BD
                SqlCon.Open();

                //Estableciendo comandos para la comunicación con la BD
                SqlCommand SqlCmd = new SqlCommand("spUsuarios_Listar", SqlCon);
                SqlCmd.CommandType = CommandType.StoredProcedure;

                //Generando Parámetros
                SqlParameter ParCampo = new SqlParameter("@campo", Usuarios.Campo);
                SqlCmd.Parameters.Add(ParCampo);

                SqlParameter ParBuscar = new SqlParameter("@buscar", Usuarios.Buscar);
                SqlCmd.Parameters.Add(ParBuscar);

                //Ejecutando comando para transacciones con BD
                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(dtResultado);
            }
            catch (Exception ex)
            {
                dtResultado = null;
                MessageBox.Show(ex.ToString(), "Error: SQL Server", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                //Cerrando Conexion con la BD
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return dtResultado;
        }

        ////Método Listar personas
        //public DataTable ListarPersonas()
        //{
        //    DataTable dtResultado = new DataTable("listaPersonas");
        //    try
        //    {
        //        //Abriendo conexion con BD
        //        SqlCon.Open();

        //        //Estableciendo comandos para la comunicación con la BD
        //        SqlCommand SqlCmd = new SqlCommand("Select * From viTrabajadores_Usuarios", SqlCon);
        //        SqlCmd.CommandType = CommandType.Text;

        //        //Ejecutando comando para transacciones con BD
        //        SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
        //        SqlDat.Fill(dtResultado);
        //    }
        //    catch (Exception ex)
        //    {
        //        dtResultado = null;
        //        MessageBox.Show(null, ex.ToString(), "Error: SQL Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        //Cerrando Conexion con la BD
        //        if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
        //    }
        //    return dtResultado;
        //}
    }
}
