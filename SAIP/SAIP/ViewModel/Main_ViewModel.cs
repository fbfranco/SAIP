using SAIP.Animations;
using SAIP.BusinessObject;
using SAIP.Model;
using SAIP.Service.DialogService;
using SAIP.ViewModel.Base;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;
using System.Windows.Threading;

namespace SAIP.ViewModel
{
    public class Main_ViewModel : ViewModelBase
    {
        #region SINGLETON
        private static Main_ViewModel Instance;
        public static Main_ViewModel GetInstance()
        {
            if (Instance == null)
            {
                Instance = new Main_ViewModel();
            }
            return Instance;
        }
        #endregion

        #region CONSTRUCTOR DE LA CLASE
        public Main_ViewModel()
        {
            Login = new Login_BusinessObject();
            Accesos = new AccesoSucursal_BusinessObject();

            _AccesosSucursales = new ObservableCollection<AccesoSucursal_Model>(Accesos.GetAccesos());
            _SucursalesActivas = new ObservableCollection<DataRow[]>();

            lblSucursal_MouseLeftButtonDown = new RelayCommand(_lblSucursal_MouseLeftButtonDown);
            myMediaElement_MediaOpened = new RelayCommand(_myMediaElement_MediaOpened);
            WindowState = new RelayCommand(_WindowState);
            btnSucursal_Click = new RelayCommand(_btnSucursal_Click);
            btnSubItem_Click = new RelayCommand(_btnSubItem_Click);
            btnCloseUserControl = new RelayCommand(_btnCloseUserControl);
            btnClosing_Click = new RelayCommand(_btnClosing_Click);
            btnMaximizar = new RelayCommand(_btnMaximizar);
            btnMinimizar = new RelayCommand(_btnMinimizar);
            btnSideBar_Click = new RelayCommand(_btnSideBar_Click);

            UserName = Login_ViewModel.Username;
            Password = Login_ViewModel.Password;
            _WidthSideBar = "0";
            _WindowVisibility = true;
            _ImgStates = Application.Current.FindResource("Img_BtnMaximizar");
        }
        #endregion

        #region CAMPOS DE LA CLASE
        Login_BusinessObject Login;
        AccesoSucursal_BusinessObject Accesos;

        ObservableCollection<Login_Model> _DatosUsuarioLogueado;
        ObservableCollection<DataRow[]> _SucursalesActivas;
        ObservableCollection<AccesoSucursal_Model> _AccesosSucursales;

        private string UserName;
        private string Password;
        public static string _WidthSideBar;
        public static string _NombreSucursal;
        private DataTemplate _ControlView;
        private Boolean _WindowVisibility;
        private object _ImgStates;

        public RelayCommand lblSucursal_MouseLeftButtonDown { get; set; }
        public RelayCommand LoadAccesos { get; set; }
        public RelayCommand btnSucursal_Click { get; set; }
        public RelayCommand btnSubItem_Click { get; set; }
        public RelayCommand btnCloseUserControl { get; set; }
        public RelayCommand myMediaElement_MediaOpened { get; set; }
        public RelayCommand btnClosing_Click { get; set; }
        public RelayCommand btnMaximizar { get; set; }
        public RelayCommand btnMinimizar { get; set; }
        public RelayCommand WindowState { get; set; }
        public RelayCommand btnSideBar_Click { get; set; }
        #endregion

        #region MÉTODOS O PROPIEDADES DE LA CLASE
        public ObservableCollection<Login_Model> DatosUsuarioLogueado
        {
            get
            {
                return _DatosUsuarioLogueado = new ObservableCollection<Login_Model>(Login.GetUserLogin(UserName,Password));
            }
        }
        public ObservableCollection<DataRow[]> SucursalesActivas
        {
            get
            {
                return _SucursalesActivas = new ObservableCollection<DataRow[]>(Accesos.GetAccesoUsuarioActivo(Login_ViewModel.IdUsuario));
            }
        }
        
        public string WidthSideBar
        {
            get { return _WidthSideBar; }
            set { _WidthSideBar = value; RaisePropertyChanged("WidthSidBar"); }
        }
        public string NombreSucursal
        {
            get { return _NombreSucursal; }
            set { _NombreSucursal = value; RaisePropertyChanged("NombreSucursal"); }
        }
        public DataTemplate ControlView
        {
            get { return _ControlView; }
            set { _ControlView = value; RaisePropertyChanged("ControlView"); }
        }
        public Boolean WindowVisibility
        {
            get { return _WindowVisibility; }
            set { _WindowVisibility = value; RaisePropertyChanged("WindowVisibility"); }
        }
        public object ImgStates
        {
            get { return _ImgStates; }
            set { _ImgStates = value; RaisePropertyChanged("ImgStates"); }
        }


        #endregion

        #region COMMANDS
        /******Cargar el Home al inicio de la reproduccion del MediaElement******/
        private void _myMediaElement_MediaOpened(object obj)
        {
            _WindowVisibility = true;
            RaisePropertyChanged("WindowVisibility");
        }

        /******Pasar el Nombre de la sucursal para su respectivo manejo en la clase Main_ViewModel******/
        public void _btnSucursal_Click(object obj)
        {
            _NombreSucursal = obj.ToString();
            RaisePropertyChanged("NombreSucursal");
            _WidthSideBar = "200";
            RaisePropertyChanged("WidthSideBar");
            new General_Animations().SliderSideBar_Animations(200);
        }

        /******Evento Click para asignar la sucursal Activada******/
        private void _lblSucursal_MouseLeftButtonDown(object obj)
        {
            _btnCloseUserControl(null);
            new General_Animations().SliderSideBar_Animations(0);
        }

        /******Evento Click en el Button Documento******/
        private void _btnSubItem_Click(object obj)
        {
            var x = obj.ToString();
            if (ControlView != null)
            {
                _btnCloseUserControl(null);
                var Delay1 = new DispatcherTimer();
                Delay1.Interval = new TimeSpan(0, 0, 0, 0, 200);
                Delay1.Tick += (s1, a1) =>
                {
                    _ControlView = App.Current.FindResource(x) as DataTemplate;
                    RaisePropertyChanged("ControlView");

                    var Delay2 = new DispatcherTimer();
                    Delay2.Interval = new TimeSpan(0, 0, 0, 0, 50);
                    Delay2.Tick += (s2, a2) =>
                    {
                        new General_Animations().EfectoDesvanecer(1);
                        Delay2.Stop();
                    };
                    Delay2.Start();
                    Delay1.Stop();
                };
                Delay1.Start();
            }
            else
            {
                _ControlView = App.Current.FindResource(x) as DataTemplate;
                RaisePropertyChanged("ControlView");

                var Delay = new DispatcherTimer();
                Delay.Interval = new TimeSpan(0, 0, 0, 0, 50);  
                Delay.Tick += (s, a) =>
                {
                    new General_Animations().EfectoDesvanecer(1);
                    Delay.Stop();
                };
                Delay.Start();
            }
        }

        /******Evento para Limpiar el Contenedor Principal******/
        private void _btnCloseUserControl(object obj)
        {
            new General_Animations().EfectoDesvanecer(0);
            var Delay = new DispatcherTimer();
            Delay.Interval = new TimeSpan(0, 0, 0, 0, 200);
            Delay.Tick += (s, a) =>
            {
                _ControlView = null;
                RaisePropertyChanged("ControlView");
                Delay.Stop();
            };
            Delay.Start();
        }

        /******Minimizar Ventana******/
        private void _btnMinimizar(object obj)
        {
            var x = obj as Window;
            x.WindowState = System.Windows.WindowState.Minimized;
        }

        /******Maximizar Ventana******/
        private int x = 1; 
        private void _btnMaximizar(object obj)
        {
            var y = obj as Window;

            if (x == 1)
            {
                y.WindowState = System.Windows.WindowState.Maximized;
                x = 0;
            }
            else
            {
                y.WindowState = System.Windows.WindowState.Normal;
                x = 1;
            }
        }

        /******Cambiar Imagen al btnMaximizar******/
        private void _WindowState(object obj)
        {
            var x = obj as Window;
            _ImgStates = x.WindowState == System.Windows.WindowState.Maximized ? Application.Current.FindResource("Img_BtnRestaurar") : Application.Current.FindResource("Img_BtnMaximizar");
            RaisePropertyChanged("ImgStates");
        }

        /******Evento Animar el Sidebar Acordeon******/
        private void _btnSideBar_Click(object obj)
        {
            new General_Animations().Acordeon_Animations(obj);
        }

        /******Evento Click del Button Closing******/
        private void _btnClosing_Click(object obj)
        {
            if (DialogService.Instance.MostrarMensaje("¿Esta seguro que desea salir del Sistema?", "SAIP", "YesNo", "Question") == "Yes") DialogService.Instance.CerrarVentana("VentanaPrincipal");
        }
        #endregion
    }
}
