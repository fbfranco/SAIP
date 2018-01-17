using SAIP.Model;
using SAIP.BusinessObject;
using SAIP.View.Windows;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using SAIP.ViewModel.Base;

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
            //
            //Inicialiando Instancias para la comunicación con otras clases
            //
            Login = new Login_BusinessObject();
            Accesos = new AccesoSucursal_BusinessObject();
            //
            //Inicializando Campos del tipo ObservableCollection
            //
            _AccesosSucursales = new ObservableCollection<AccesoSucursal_Model>(Accesos.GetAccesos());
            _SucursalesActivas = new ObservableCollection<DataRow[]>();
            //
            //Inicializando Parámetros del Usuario Logueado
            //
            UserName = Login_ViewModel.Username;
            Password = Login_ViewModel.Password;
            //
            //Inicializando Eventos para la interacción en del usuario en la Vista
            //
            LoadAccesos = new RelayCommand(CargarSucursales);
            btnSucursal_Click = new RelayCommand(_btnSucursal_Click);
            lblSucursal_MouseLeftButtonDown = new RelayCommand(_lblSucursal_MouseLeftButtonDown);
            btnDocumentos_MouseLeftButtonUp = new RelayCommand(_btnDocumentos_MouseLeftButtonUp);
            btnCloseUserControl = new RelayCommand(_btnCloseUserControl);
            //
            //Inicializando Datos por Defecto
            //
            _WidthSideBar = "0";
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
        private DataTemplate _ControlView;
        public static string _WidthSideBar;
        public static string _NombreSucursal;

        public RelayCommand lblSucursal_MouseLeftButtonDown { get; set; }
        public RelayCommand LoadAccesos { get; set; }
        public RelayCommand btnSucursal_Click { get; set; }
        public RelayCommand btnDocumentos_MouseLeftButtonUp { get; set; }
        public RelayCommand btnCloseUserControl { get; set; }
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
        #endregion

        #region COMMANDS
        //
        //Cargar los Botones de Sucursales de acuerdo al IdUsuario
        //
        private void CargarSucursales(object obj)
        {
            var CtnWrap = MainWindow.GetInstance().ContenedorWrap;
            var NombreSucursal = "";
            for (int i = 0; i < SucursalesActivas.Count; i++)
            {
                foreach (DataRow item in SucursalesActivas[i])
                {
                    NombreSucursal = item[6].ToString();
                }

                CtnWrap.Children.Add(new Button
                {
                    Style = Application.Current.FindResource("StyleBtnSucursal") as Style,
                    Content = NombreSucursal,
                    Name = "btnSucursal" + i
                });
                var BtnS = CtnWrap.Children[i] as Button;
                BtnS.CommandParameter = BtnS.Content;
            }
        }
        //
        //Pasar el Nombre de la sucursal para su respectivo manejo en la clase Main_ViewModel
        //
        public void _btnSucursal_Click(object obj)
        {
            MainWindow.GetInstance().lblSucursal.Text = obj.ToString();
            SliderSideBar(200);
        }
        //
        //Animación para Ocultar o Mostrar el SideBar
        //
        private void SliderSideBar(int v1)
        {
            MainWindow MainView = MainWindow.GetInstance();
            MainView.CDSidebar.Width = new GridLength(v1);

            DoubleAnimation SidebarAnimation = new DoubleAnimation();
            SidebarAnimation.Duration = new Duration(new TimeSpan(0, 0, 0, 0, 200));
            SidebarAnimation.From = v1 == 200 ? 0 : 200;
            SidebarAnimation.To = v1;
            Storyboard sb = new Storyboard();
            sb.Children.Add(SidebarAnimation);
            Storyboard.SetTarget(SidebarAnimation, MainView.SideBar);
            Storyboard.SetTargetProperty(SidebarAnimation, new PropertyPath("Width"));
            MainView.SideBar.BeginStoryboard(sb);

            if (v1 == 200)
            {
                MainView.myMediaElement.Stop();
                MainView.myMediaElement.Visibility = Visibility.Hidden;
                MainView.backgroudOverAll.Visibility = Visibility.Hidden;
                MainView.home.Visibility = Visibility.Hidden;
            }
            else
            {
                MainView.myMediaElement.Play();
                MainView.myMediaElement.Visibility = Visibility.Visible;
                MainView.backgroudOverAll.Visibility = Visibility.Visible;
                MainView.home.Visibility = Visibility.Visible;
            }
        }

        private void _lblSucursal_MouseLeftButtonDown(object obj)
        {
            MainWindow.GetInstance().MainContainer.Children.Clear();
            SliderSideBar(0);
        }
        private void _btnDocumentos_MouseLeftButtonUp(object obj)
        {
            _ControlView = App.Current.FindResource("DocumentosView") as DataTemplate;
            RaisePropertyChanged("ControlView");
        }
        private void _btnCloseUserControl(object obj)
        {
            _ControlView = null;
            RaisePropertyChanged("ControlView");
        }
        #endregion
    }
}
