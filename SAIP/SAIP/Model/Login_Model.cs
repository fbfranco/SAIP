using System.ComponentModel;
using System.Windows.Media;

namespace SAIP.Model
{
    public class Login_Model : INotifyPropertyChanged
    {
        #region Implemetación de la Interfáz INotifyPropertyChanged 
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyOfPropertyChange(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Campos del Modelo

        private int _IdUsuario;
        private string _UserName;
        private string _TipoUsuario;
        private ImageSource _Imagen;

        #endregion

        #region Propiedades del Modelo
        public int IdUsuario
        {
            get { return _IdUsuario; }
            set { _IdUsuario = value; NotifyOfPropertyChange("IdUsuario"); }
        }
        public string UserName
        {
            get{ return _UserName; }
            set { _UserName = value; NotifyOfPropertyChange("UserName"); }
        }
        public string TipoUsuario
        {
            get { return _TipoUsuario; }
            set { _TipoUsuario = value; NotifyOfPropertyChange("TipoUsuario"); }
        }
        public ImageSource Imagen
        {
            get { return _Imagen; }
            set { _Imagen = value; NotifyOfPropertyChange("Imagen"); }
        }
        #endregion
    }
}
