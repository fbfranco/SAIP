using SAIP.Helpers;
using System;
using System.ComponentModel;

namespace SAIP.Model
{
    public class Roles_Model : INotifyPropertyChanged
    {
        #region IMPLEMENTACIÓN DE LA INTERFAZ INOTIFYPROPERTYCHANGED
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
        #endregion

        #region CAMPOS
        private int _IdRol;
        private string _Descripcion;
        private int _Estado;
        private int _IdUsuario;
        private DateTime _FechaCreacion;
        private DateTime _FechaActualizacion;
        private string _FechaCreacionString;
        private string _FechaActualizacionString;
        #endregion

        #region MÉTODOS O PROPIEDADES
        public int IdRol
        {
            get { return _IdRol; }
            set { _IdRol = value; OnPropertyChanged("IdRol"); }
        }
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; OnPropertyChanged("Descripcion"); }
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
