using SAIP.Helpers;
using System;
using System.ComponentModel;

namespace SAIP.Model
{
    public class Sucursal_Model : INotifyPropertyChanged
    {
        #region IMPLEMENTACIÓN DE LA INTERFAZ INOTIFYPROPERTYCHANGED
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
        #endregion

        #region CAMPOS
        private int _IdSucursal;
        private string _RazonSocial;
        private string _Direccion;
        private string _Telefono;
        private string _Encargado;
        private int _Estado;
        private int _IdUsuario;
        private DateTime _FechaCreacion;
        private DateTime _FechaActualizacion;
        private string _FechaCreacionString;
        private string _FechaActualizacionString;
        #endregion

        #region MÉTODOS O PROPIEDADES
        public int IdSucursal
        {
            get { return _IdSucursal; }
            set { _IdSucursal = value; OnPropertyChanged("IdSucursal"); }
        }
        public string RazonSocial
        {
            get { return _RazonSocial; }
            set { _RazonSocial = value; OnPropertyChanged("RazonSocial"); }
        }
        public string Direccion
        {
            get { return _Direccion; }
            set { _Direccion = value; OnPropertyChanged("Direccion"); }
        }
        public string Telefono
        {
            get { return _Telefono; }
            set { _Telefono = value; OnPropertyChanged("Telefono"); }
        }
        public string Encargado
        {
            get { return _Encargado; }
            set { _Encargado = value; OnPropertyChanged("Encargado"); }
        }
        public int Estado
        {
            get { return _Estado; }
            set { _Estado = value; OnPropertyChanged("Estado"); }
        }
        public int IdUsuario
        {
            get { return _IdUsuario; }
            set { _IdUsuario = value; OnPropertyChanged("IdUsuario"); }
        }
        public DateTime FechaCreacion
        {
            get { return _FechaCreacion; }
            set { _FechaCreacion = value; OnPropertyChanged("FechaCreacion"); }
        }
        public DateTime FechaActualizacion
        {
            get { return _FechaActualizacion; }
            set { _FechaActualizacion = value; OnPropertyChanged("FechaActualizacion"); }
        }
        public string FechaCreacionString
        {
            get { return _FechaCreacionString = Accesoria.DateFormater(FechaCreacion); }
            set { _FechaCreacionString = value; OnPropertyChanged("FechaCreacionString"); }
        }
        public string FechaActualizacionString
        {
            get { return _FechaActualizacionString = Accesoria.DateFormater(FechaActualizacion); }
            set { _FechaActualizacionString = value; OnPropertyChanged("FechaActualizacionString"); }
        }
        #endregion
    }
}
