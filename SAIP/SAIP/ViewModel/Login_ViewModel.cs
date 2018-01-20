using SAIP.BusinessObject;
using SAIP.Helpers;
using SAIP.Model;
using SAIP.Service.DialogService;
using SAIP.View.Windows;
using SAIP.ViewModel.Base;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Threading;

namespace SAIP.ViewModel
{
    public class Login_ViewModel : ViewModelBase
    {
        #region SINGLETON
        private static Login_ViewModel Instance;
        public static Login_ViewModel GetInstance()
        {
            var x = Instance == null ? new Login_ViewModel() : Instance;
            return x;
        }
        #endregion

        #region CONSTRUCTOR
        public Login_ViewModel()
        {
            Login = new Login_BusinessObject();
            Login.UserChanged += new EventHandler(login_UserChanged);
            LoginCommand = new RelayCommand(Singin);
        }
        #endregion

        #region CAMPOS
        Login_BusinessObject Login;
        ObservableCollection<Login_Model> _UserLogueado;
        private string _v1;
        public static int IdUsuario;
        public static string Username = "";
        public static string Password="";
        #endregion

        #region MÉTODOS O PROPIEDADES
        public RelayCommand LoginCommand { get; set; }
        public ObservableCollection<Login_Model> UserLogueado
        {
            get
            {
                return _UserLogueado;
            }
        }
        public string V1
        {
            get { if (_v1 == null) _v1 = "Usuario"; return _v1; }
            set { _v1 = value; RaisePropertyChanged("V1"); }
        }
        #endregion

        #region Commands

        private void Singin(object obj)
        {
            PasswordBox Mypass = obj as PasswordBox;
            var parameter = Mypass.Password;

            if (parameter.Equals(""))
            {
                DialogService.Instance.MostrarMensaje("Los campos no se llenaron correctamente", "SAIP", "Ok", "Exclamation");
            }
            else
            {
                _UserLogueado = new ObservableCollection<Login_Model>(Login.GetUserLogin(V1, parameter));

                if (_UserLogueado.Count == 0)
                {
                    DialogService.Instance.MostrarMensaje("El Usuario o Contraseña ingresados no son correctos", "SAIP","Ok", "Exclamation");
                }
                else
                {
                    Username = V1;
                    Password = parameter;
                    IdUsuario = UserLogueado[0].IdUsuario;

                    DialogService.Instance.CerrarVentana("View_Login");
                    MainWindow.GetInstance.Show();
                }
            }

        }
        private void login_UserChanged(object sender, EventArgs e)
        {
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() => { RaisePropertyChanged("UserLogueado"); }));
        }

        #endregion
    }
}
