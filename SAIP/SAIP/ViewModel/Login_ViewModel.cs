using SAIP.Model;
using SAIP.Model.BusinessObject;
using SAIP.View;
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
        #region Singleton
        private static Login_ViewModel Instance;
        public static Login_ViewModel GetInstance()
        {
            if (Instance == null)
            {
                Instance = new Login_ViewModel();
            }
            return Instance;
        }
        #endregion

        #region Constructor de la clase

        public Login_ViewModel()
        {
            Login = new Login_BusinessObject();
            Login.UserChanged += new EventHandler(login_UserChanged);
            LoginCommand = new RelayCommand(Singin);
            UpdateBindingGroup = new BindingGroup { Name = "Group1" };
        }

        #endregion

        #region Fields(Campos)

        Login_BusinessObject Login;
        ObservableCollection<Login_Model> _UserLogueado;
        BindingGroup _UpdateBindingGroup;
        private string _v1;
        public static string Username;
        public static string Password;
        public static int IdUsuario;
        #endregion

        #region Propiedades de la Clase

        public ObservableCollection<Login_Model> UserLogueado
        {
            get
            {
                return _UserLogueado;
            }
        }
        public RelayCommand LoginCommand { get; set; }
        public BindingGroup UpdateBindingGroup
        {
            get
            {
                return _UpdateBindingGroup;
            }
            set
            {
                if (_UpdateBindingGroup != value)
                {
                    _UpdateBindingGroup = value;
                    RaisePropertyChanged("UpdateBindingGroup");
                }
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
            //Recibir la Contraseña de la Vista
            PasswordBox Mypass = obj as PasswordBox;
            var parameter = Mypass.Password;

            //Validar Campos
            if (parameter.Equals(""))
            {
                MessageBox.Show("Los campos no se llenaron correctamente","SAIP",MessageBoxButton.OK,MessageBoxImage.Exclamation);
            }
            else
            {
                //Enviar los parámetros a la función Login para llenar el ObservableCollecction
                _UserLogueado = new ObservableCollection<Login_Model>(Login.GetUserLogin(V1, parameter));

                if (_UserLogueado.Count == 0)
                {
                    MessageBox.Show("El Usuario o Contraseña ingresados no son correctos", "SAIP", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                else
                {
                    //Pasar Usuario y Contraseña a Campos Static para su uso en la Venta Principal
                    Username = V1;
                    Password = parameter;
                    IdUsuario = UserLogueado[0].IdUsuario;

                    //Ocultar Ventana Login
                    var ventana = Application.Current.Windows.OfType<Window>().Where(w => w.Name == "View_Login").SingleOrDefault<Window>();
                    ventana.Hide();

                    //Mostrar Ventana Principal
                    MainWindow.GetInstance().Show();
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
