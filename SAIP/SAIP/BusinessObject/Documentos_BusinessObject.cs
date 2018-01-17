using SAIP.Data;
using System;
using System.Collections.Generic;

namespace SAIP.Model.BusinessObject
{
    public class Documentos_BusinessObject
    {
        #region CONSTRUCTOR
        public Documentos_BusinessObject()
        {
            _GetDocumentos = new List<Documentos_Model>();
        }
        #endregion

        #region CAMPOS
        public event EventHandler DocumentosChanged;
        List<Documentos_Model> _GetDocumentos { get; set; }
        #endregion

        #region MÉTODOS O PROPIEDADES
        /******Listar Documentos******/
        public List<Documentos_Model> GetDocumentos()
        {
            return _GetDocumentos = Documentos_Data.ListarDocumentos();
        }

        /******Guardar Documento******/
        public Boolean Guardar(Documentos_Model Dcto)
        {
            var x = Documentos_Data.Guardar(Dcto);
            OnDocumentosChanged();
            return x;
        }

        /******Editar Documento******/
        public Boolean Editar(Documentos_Model Dcto)
        {
            var x = Documentos_Data.Editar(Dcto);
            OnDocumentosChanged();
            return x;
        }

        /******Eliminar Documento******/
        public Boolean Eliminar(Documentos_Model Dcto)
        {
            var x = Documentos_Data.Eliminar(Dcto);
            OnDocumentosChanged();
            return x;
        }

        /******Notificar los Cambios al Modelo******/
        public void OnDocumentosChanged()
        {
            DocumentosChanged?.Invoke(this, null);
        }
        #endregion
    }
}
