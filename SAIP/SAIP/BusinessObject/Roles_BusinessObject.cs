using SAIP.Data;
using System;
using System.Collections.Generic;

namespace SAIP.Model.BusinessObject
{
    public class Roles_BusinessObject
    {
        #region CONSTRUCTOR
        public Roles_BusinessObject()
        {
            _GetRoles = new List<Roles_Model>();
        }
        #endregion

        #region CAMPOS
        public event EventHandler RolesChanged;
        List<Roles_Model> _GetRoles { get; set; }
        #endregion

        #region MÉTODOS O PROPIEDADES
        /******Listar Roles******/
        public List<Roles_Model> GetRoles()
        {
            return _GetRoles = Roles_Data.ListarRoles();
        }

        /******Notificar los Cambios al Modelo******/
        public void OnRolesChanged()
        {
            RolesChanged?.Invoke(this, null);
        }
        #endregion
    }
}
