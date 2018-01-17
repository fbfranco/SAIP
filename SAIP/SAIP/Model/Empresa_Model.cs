using System;
using System.ComponentModel;
using System.Windows.Media;

namespace SAIP.Model
{
    public class Empresa_Model : INotifyPropertyChanged
    {
        #region IMPLEMENTACION DE LA INTERFAZ INOTIFYPROPERTYCHANGED

        public event PropertyChangedEventHandler PropertyChanged;
        private void INotifyOnPropertyChanged(string PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        #endregion

        #region CAMPOS
        private string _RazonSocial;
        private ImageSource _Logo;
        private DateTime _Aniversario;
        private string _Encargado;
        private string _Rubro;
        private string _AniversarioFormater; 
        #endregion

        #region MÉTODOS O PROPIEDADES
        public string RazonSocial
        {
            get => _RazonSocial;
            set { _RazonSocial = value; INotifyOnPropertyChanged("RazonSocial"); }
        }
        public ImageSource Logo
        {
            get => _Logo;
            set { _Logo = value; INotifyOnPropertyChanged("Logo"); }
        }
        public DateTime Aniversario
        {
            get => _Aniversario;
            set { _Aniversario = value; INotifyOnPropertyChanged("Aniversario"); }
        }
        public string Encargado
        {
            get => _Encargado;
            set { _Encargado = value; INotifyOnPropertyChanged("Encargado"); }
        }
        public string Rubro
        {
            get => _Rubro;
            set { _Rubro = value; INotifyOnPropertyChanged("Rubro"); }
        }
        public string AniversarioFormater
        {
            get
            {
                return Aniversario.ToString(@"dd \de MMMM \del yyyy");  
            }
            set { _AniversarioFormater = value; INotifyOnPropertyChanged("AniversarioFormater"); }
        }
        #endregion
    }
}
