using SAIP.Helpers;
using System;
using System.ComponentModel;
using System.Windows.Media;

namespace SAIP.Model.ListaModel
{
    public class ListaUsuario_Model : INotifyPropertyChanged
    {
        #region CAMPOS
        private int _IdUsuario;
        private int _IdPersona;
        private int _IdRol;
        private string _RolTipo;
        private string _Usuario;
        private string _Password;
        private string _NombreCompleto;
        private string _Nombre;
        private string _ApPaterno;
        private string _ApMaterno;
        private int _IdDocumento;
        private string _NroDocumento;
        private ImageSource _Imagen;
        private int _Estado;
        private DateTime _FechaCreacion;
        private DateTime _FechaActualizacion;
        private string _FechaCreacionString;
        private string _FechaActualizacionString;
        #endregion

        #region PROPIEDADES DE CLASE
        public int IdUsuario
        {
            get { return _IdUsuario; }
            set
            {
                _IdUsuario = value;
                NotifyOfPropertyChange("IdUsuario");
            }
        }
        public int IdPersona {
            get => _IdPersona;
            set {
                _IdPersona = value;
                NotifyOfPropertyChange("IdPersona");
            }
        }
        public int IdRol
        {
            get => _IdRol;
            set
            {
                _IdRol = value;
                NotifyOfPropertyChange("IdRol");
            }
        }
        public string RolTipo
        {
            get { return _RolTipo; }
            set { _RolTipo = value; NotifyOfPropertyChange("RolTipo"); }
        }
        public string Usuario
        {
            get => _Usuario;
            set
            {
                _Usuario = value;
                NotifyOfPropertyChange("Usuario");
            }
        }
        public string Password
        {
            get => _Password;
            set
            {
                _Password = value;
                NotifyOfPropertyChange("Password");
            }
        }
        public string NombreCompleto
        {
            get { return _NombreCompleto; }
            set { _NombreCompleto = value; NotifyOfPropertyChange("NombreCompleto"); }
        }
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; NotifyOfPropertyChange("Nombre"); }
        }
        public string ApPaterno
        {
            get { return _ApPaterno; }
            set { _ApPaterno = value; NotifyOfPropertyChange("ApPaterno"); }
        }
        public string ApMaterno
        {
            get { return _ApMaterno; }
            set { _ApMaterno = value; NotifyOfPropertyChange("ApMaterno"); }
        }
        public int IdDocumento
        {
            get { return _IdDocumento; }
            set { _IdDocumento = value; NotifyOfPropertyChange("IdDocumento"); }
        }
        public string NroDocumento
        {
            get { return _NroDocumento; }
            set { _NroDocumento = value; NotifyOfPropertyChange("NroDocumento"); }
        }
        public ImageSource Imagen
        {
            get => _Imagen;
            set
            {
                _Imagen = value;
                NotifyOfPropertyChange("Imagen");
            }
        }
        public int Estado
        {
            get => _Estado;
            set
            {
                _Estado = value;
                NotifyOfPropertyChange("Estado");
            }
        }
        public DateTime FechaCreacion
        {
            get => _FechaCreacion;
            set
            {
                _FechaCreacion = value;
                NotifyOfPropertyChange("FechaCreacion");
            }
        }
        public DateTime FechaActualizacion
        {
            get => _FechaActualizacion;
            set
            {
                _FechaActualizacion = value;
                NotifyOfPropertyChange("FechaActualizacion");
            }
        }
        public string FechaCreacionString
        {
            get => _FechaCreacionString = Accesoria.DateFormater(FechaCreacion);
            set
            {
                _FechaCreacionString = value;
                NotifyOfPropertyChange("FechaCreacionString");
            }
        }
        public string FechaActualizacionString
        {
            get => _FechaActualizacionString = Accesoria.DateFormater(FechaActualizacion);
            set
            {
                _FechaActualizacionString = value;
                NotifyOfPropertyChange("FechaActualizacionString");
            }
        }
        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyOfPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
