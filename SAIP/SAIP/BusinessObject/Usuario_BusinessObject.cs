using SAIP.Data.ListasData;
using SAIP.Model.ListaModel;
using System;
using System.Collections.Generic;

namespace SAIP.BusinessObject
{
    public class Usuario_BusinessObject
    {
        #region CONSTRUCTOR
        public Usuario_BusinessObject()
        {
            ListaUsuarios = new List<ListaUsuario_Model>();
        }
        #endregion

        #region CAMPOS
        public event EventHandler UsuarioChanged;
        List<ListaUsuario_Model> ListaUsuarios { get; set; }
        #endregion

        #region PROPIEDADES O MÉTODOS
        //
        //Lista los Usuarios en General
        //
        public List<ListaUsuario_Model> GetListaUsuarios(string v1, string v2)
        {
            return ListaUsuarios = ListaUsuario_Data.ListarUsuarios(v1, v2);
        }
        //
        //Eventos para notificar cambios en el modelo
        //
        public void OnUsuarioChanged()
        {
            UsuarioChanged?.Invoke(this, null);
        }
        #endregion
    }
}
