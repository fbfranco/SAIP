using SAIP.Data;
using System;
using System.Collections.Generic;

namespace SAIP.Model.BusinessObject
{
    public class Sucursal_BusinessObject
    {
        #region CONSTRUCTOR
        public Sucursal_BusinessObject()
        {
            _GetSucursales = new List<Sucursal_Model>();
        }
        #endregion

        #region CAMPOS
        public event EventHandler SucursalChanged;
        List<Sucursal_Model> _GetSucursales { get; set; }
        #endregion

        #region MÉTODOS O PROPIEDADES
        /******Listar Sucursales******/
        public List<Sucursal_Model> GetSucursales()
        {
            return _GetSucursales = Sucursal_Data.ListarSucursales(); 
        }

        /******Notificar los cambios al modelo******/
        public void OnSucuralChanged()
        {
            SucursalChanged?.Invoke(this, null);
        }
        #endregion
    }
}
