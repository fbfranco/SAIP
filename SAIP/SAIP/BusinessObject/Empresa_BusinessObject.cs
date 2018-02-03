using SAIP.Data;
using SAIP.Model;
using System;
using System.Collections.Generic;
using System.Windows.Media;

namespace SAIP.BusinessObject
{
    public class Empresa_BusinessObject
    {
        #region CONSTRUCTOR

        public Empresa_BusinessObject()
        {
            Empresas = new List<Empresa_Model>();
        }

        #endregion

        #region CAMPOS DE LA CLASE
        public event EventHandler EmpresaChanged;
        List<Empresa_Model> Empresas { get; set; }
        #endregion

        #region PROPIEDADES O MÉTODOS DE LA CLASE
        /******Mostrar Datos de la Empresa******/
        public List<Empresa_Model> GetEmpresas()
        {
            return Empresas = Empresa_Data.DatosEmpresa();
        }

        /******Editar Documento******/
        public Boolean Editar(Empresa_Model Emp)
        {
            var x = Empresa_Data.Editar(Emp);
            OnEmpresasChanged();
            return x;
        }

        /******Notificar cambios al Modelo******/
        public void OnEmpresasChanged()
        {
            EmpresaChanged?.Invoke(this, null);
        }
        #endregion
    }
}
