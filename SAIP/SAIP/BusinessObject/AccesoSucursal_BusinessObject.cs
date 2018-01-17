using SAIP.Data;
using SAIP.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace SAIP.BusinessObject
{
    public class AccesoSucursal_BusinessObject
    {
        #region CONSTRUCTOR
        public AccesoSucursal_BusinessObject()
        {
            Accesos = new List<AccesoSucursal_Model>();
            AccesoUsuarioActivo = new List<DataRow[]>();
        }
        #endregion

        #region CAMPOS DE LA CLASE
        public event EventHandler AccesoSucursalChanged;
        #endregion

        #region PROPIEDADES O MÉTODOS DE LA CLASE
        //
        //Lista los Accesos en General
        //
        List<AccesoSucursal_Model> Accesos { get; set; }
        public List<AccesoSucursal_Model> GetAccesos()
        {
            return Accesos = AccesoSucursal_Data.Accesos();
        }
        //
        //Lista los  Accesos a Sucursales que tiene el Usuario en específico
        //
        List<DataRow[]> AccesoUsuarioActivo { get; set; } 
        public List<DataRow[]> GetAccesoUsuarioActivo(int IdUsuario)
        {
            return AccesoUsuarioActivo = AccesoSucursal_Data.SucursalActivas(IdUsuario);
        }
        //
        //Evento OnAccessosChanged para notificar los cambios en el modelo
        //
        public void OnAccesosChanged()
        {
            AccesoSucursalChanged?.Invoke(this, null);
        }

        #endregion
    }
}
