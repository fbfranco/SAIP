using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace SAIP.Model
{
    public class Documentos_Model : INotifyPropertyChanged
    {
        #region IMPLEMENTACION DE LA INTERFAZ INOTIFYPROPERTYCHANGED
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
        #endregion

        #region CAMPOS
        private int _IdDocumento;
        private string _Nombre;
        private string _Tipo;
        private int _Estado;
        private int _IdUsuario;
        private DateTime _FechaCreacion;
        private DateTime _FechaActualizacion;
        #endregion

        #region MÉTODOS O PROPIEDADES
        public int IdDocumento
        {
            get { return _IdDocumento; }
            set { _IdDocumento = value; OnPropertyChanged("IdDocumento"); }
        }
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; OnPropertyChanged("Nombre"); }
        }
        public string Tipo
        {
            get { return _Tipo; }
            set { _Tipo = value; OnPropertyChanged("Tipo"); }
        }
        public int Estado
        {
            get { return _Estado; }
            set { _Estado = value; OnPropertyChanged("Estado"); }
        }
        public int IdUsuario
        {
            get { return _IdUsuario; }
            set { _IdUsuario = value;  OnPropertyChanged("IdUsuario"); }
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
        #endregion
    }
}
