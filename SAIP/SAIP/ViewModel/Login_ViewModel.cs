using SAIP.BusinessObject;
using SAIP.Helpers;
using SAIP.Model;
using SAIP.Service.DialogService;
using SAIP.ViewModel.Base;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
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
            btnCerrar_Click = new RelayCommand(_btnCerrar_Click);
            TextUsuario_GotFocus = new RelayCommand(_TextUsuario_GotFocus);
            TextUsuario_LostFocus = new RelayCommand(_TextUsuario_LostFocus);
            TextPasswordO_GotFocus = new RelayCommand(_TextPasswordO_GotFocus);
            TextPassword_LostFocus = new RelayCommand(_TextPassword_LostFocus);

            _v1 = "Usuario";
            _ColorText = Application.Current.FindResource("SC_FontTitlePanel");
            _PasswordBoxFocus = false;
            _TextPasswordFocus = false;
            _PasswordBoxVisibility = false;
        }
        #endregion

        #region CAMPOS
        Login_BusinessObject Login;
        ObservableCollection<Login_Model> _UserLogueado;
        private string _v1;
        public static int IdUsuario;
        public static string Username = "";
        public static string Password="";
        private object _ColorText;
        private Boolean _PasswordBoxFocus;
        private Boolean _TextPasswordFocus;
        private Boolean _PasswordBoxVisibility;
        private Boolean _TextPasswordVisibility;
        #endregion

        #region MÉTODOS O PROPIEDADES
        /*******Comandos******/
        public RelayCommand LoginCommand { get; set; }
        public RelayCommand btnCerrar_Click { get; set; }
        public RelayCommand TextUsuario_GotFocus { get; set; }
        public RelayCommand TextUsuario_LostFocus { get; set; }
        public RelayCommand TextPasswordO_GotFocus { get; set; }
        public RelayCommand TextPassword_LostFocus { get; set; }

        /*******ObservableColleccions******/
        public ObservableCollection<Login_Model> UserLogueado
        {
            get
            {
                return _UserLogueado;
            }
        }

        /*******Otros Campos******/
        public object ColorText
        {
            get { return _ColorText; }
            set { _ColorText = value; RaisePropertyChanged("ColorText"); }
        }
        public string V1
        {
            get
            {
                if (_v1.Equals("Usuario"))
                {
                    _ColorText = Application.Current.FindResource("SC_FontTitlePanel");
                    RaisePropertyChanged("ColorText");
                }
                return _v1;
            }
            set { _v1 = value; RaisePropertyChanged("V1"); }
        }
        public Boolean PasswordBoxFocus
        {
            get { return _PasswordBoxFocus; }
            set { _PasswordBoxFocus = value; RaisePropertyChanged("PasswordBoxFocus"); }
        }
        public Boolean TextPasswordFocus
        {
            get { return _TextPasswordFocus; }
            set { _TextPasswordFocus = value; RaisePropertyChanged("TextPasswordFocus"); }
        }
        public Boolean PasswordBoxVisibility
        {
            get { return _PasswordBoxVisibility; }
            set { _PasswordBoxVisibility = value; RaisePropertyChanged("PasswordBoxVisibility"); }
        }
        public Boolean TextPasswordVisibility
        {
            get { return _TextPasswordVisibility = _PasswordBoxVisibility == true ? false : true; }
            set { _TextPasswordVisibility = value; RaisePropertyChanged("TextPasswordVisibility"); }
        }
        #endregion

        #region COMMANDS
        /******Evento para Loguearse al Sistema******/
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

                    DialogService.Instance.OcultarVentana("View_Login");
                    ViewInstances.MainInstance.Show();
                }
            }

        }

        /******Evento Click sobre formulario de Login******/
        private void _btnCerrar_Click(object obj)
        {
            DialogService.Instance.CerrarVentana("View_Login");
        }

        /******Evento GotFocus del textUsuario******/
        private void _TextUsuario_GotFocus(object obj)
        {
            if (V1.Equals("Usuario"))
            {
                _v1 = "";
                _ColorText = Application.Current.FindResource("SC_FontLabel");
                RaisePropertyChanged("V1");
                RaisePropertyChanged("ColorText");
            }
        }

        /******Evento LostFocus del textUsuario******/
        private void _TextUsuario_LostFocus(object obj)
        {
            if (V1.Equals(""))
            {
                _v1 = "Usuario";
                _ColorText = Application.Current.FindResource("SC_FontTitlePanel");
                RaisePropertyChanged("V1");
                RaisePropertyChanged("ColorText");
            }
        }

        /******Evento GotFocus del textPassword******/
        private void _TextPasswordO_GotFocus(object obj)
        {
            _PasswordBoxVisibility = true;
            RaisePropertyChanged("PasswordBoxVisibility");
            RaisePropertyChanged("TextPasswordVisibility");

            _PasswordBoxFocus = true;
            _TextPasswordFocus = false;
            RaisePropertyChanged("TextPasswordFocus");
            RaisePropertyChanged("PasswordBoxFocus");
        }

        /******Evento LostFocus del textPassword******/
        private void _TextPassword_LostFocus(object obj)
        {
            var x = obj as PasswordBox;
            if (x.Password.Equals(""))
            {
                _PasswordBoxVisibility = false;
                RaisePropertyChanged("PasswordBoxVisibility");
                RaisePropertyChanged("TextPasswordVisibility");

                _PasswordBoxFocus = false;
                _TextPasswordFocus = false;
                RaisePropertyChanged("TextPasswordFocus");
                RaisePropertyChanged("PasswordBoxFocus");
            }
        }

        /******Notificar los cambios al Modelo******/
        private void login_UserChanged(object sender, EventArgs e)
        {
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() => { RaisePropertyChanged("UserLogueado"); }));
        }

        #endregion
    }
}
