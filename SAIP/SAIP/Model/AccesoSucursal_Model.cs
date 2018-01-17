using System;
using System.ComponentModel;

namespace SAIP.Model
{
    public class AccesoSucursal_Model : INotifyPropertyChanged
    {
        #region Implementación de la Interfáz INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void INotifyOnPropertyChanged(string PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
        #endregion

        #region Campos de la Clase 
        private int _IdUsuario;
        private int _IdSucursal;
        private int _Acceso;
        private int _IdUsuarioA;
        private DateTime _FechaCreacion;
        private DateTime _FechaActualizacion;
        private string _RazonSocial;

        #endregion

        #region Propiedades de la Clase

        public int IdUsuario
        {
            get => _IdUsuario;
            set { _IdUsuario = value; INotifyOnPropertyChanged("IdUsuario"); }
        }
        public int IdSucursal
        {
            get => _IdSucursal;
            set { _IdSucursal = value; INotifyOnPropertyChanged("IdSucursal"); }
        }
        public int Acceso
        {
            get => _Acceso;
            set { _Acceso = value; INotifyOnPropertyChanged("Acceso"); }
        }
        public int IdUsuarioA
        {
            get => _IdUsuarioA;
            set { _IdUsuarioA = value; INotifyOnPropertyChanged("IdUsuarioA"); }
        }
        public DateTime FechaCreacion
        {
            get => _FechaCreacion;
            set { _FechaCreacion = value; INotifyOnPropertyChanged("FechaCreacion"); }
        }
        public DateTime FechaActualizacion
        {
            get => _FechaActualizacion;
            set { _FechaActualizacion = value; INotifyOnPropertyChanged("FechaActualizacion"); }
        }
        public string RazonSocial
        {
            get { return _RazonSocial; }
            set { _RazonSocial = value; INotifyOnPropertyChanged("RazonSocial"); }
        }

        #endregion
    }
}
