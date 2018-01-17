using SAIP.BusinessObject;
using SAIP.Model.ListaModel;
using SAIP.View.Windows;
using SAIP.ViewModel.Base;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Threading;

namespace SAIP.ViewModel
{
    public class Usuario_ViewModel : ViewModelBase
    {
        #region SINGLETON
        private static Usuario_ViewModel Instance;
        public static Usuario_ViewModel GetInstance()
        {
            if (Instance == null)
            {
                Instance = new Usuario_ViewModel();
            }
            return Instance;
        }
        #endregion

        #region CONSTRUCTOR
        public Usuario_ViewModel()
        {
            
            Usuarios = new Usuario_BusinessObject();
            Usuarios.UsuarioChanged += new EventHandler(Usuarios_UsuarioChanged);

            //Inicializar Comandos
            textBuscar_KeyUp = new RelayCommand(_textBuscar_KeyUp);
            btnNuevoUsuario_Click = new RelayCommand(_btnNuevoUsuario_Click);
            
            //Inicializar campos por defecto
            _ItemCboCampo.Add("Nombre");
            _ItemCboCampo.Add("Usuario");
            _ItemCboCampo.Add("ID");
            _CampoParameter = "N";
            _BuscarParameter = "";
            _InfoRegistros = "Mostrando " + CountUser + " Registros de " + TotalCountUser;
        }
        #endregion

        #region CAMPOS
        Usuario_BusinessObject Usuarios;
        ObservableCollection<ListaUsuario_Model> _ListaUsuarios;
        ObservableCollection<string> _ItemCboCampo = new ObservableCollection<string>();
        
        private string _CampoParameter;
        private string _BuscarParameter;
        private string _TotalCountUser;
        private string _CountUser;
        private string _InfoRegistros;
        #endregion

        #region PROPIEDADES O MÉTODOS
        public ObservableCollection<string> ItemCboCampo
        {
            get
            {  
                return _ItemCboCampo;
            }
        }
        public ObservableCollection<ListaUsuario_Model> ListarUsuarios
        {
            get
            {
                return _ListaUsuarios = new ObservableCollection<ListaUsuario_Model>(Usuarios.GetListaUsuarios(CampoParameter, BuscarParameter));
            }
            set { _ListaUsuarios = value; RaisePropertyChanged("ListarUsuarios"); }
        }

        public string CampoParameter
        {
            get { return _CampoParameter.Substring(0, 1) ; }
            set { _CampoParameter = value; RaisePropertyChanged("CampoParameter"); }
        }
        public string BuscarParameter
        {
            get { return _BuscarParameter; }
            set { _BuscarParameter = value; RaisePropertyChanged("BuscarParameter"); }
        }
        public string TotalCountUser
        {
            get { return _TotalCountUser = Usuarios.GetListaUsuarios("N","").Count.ToString(); }
            set { _TotalCountUser = value; RaisePropertyChanged("TotalCountUser"); }
        }
        public string CountUser
        {
            get { return _CountUser = ListarUsuarios.Count.ToString(); }
            set { _CountUser = value; RaisePropertyChanged("CountUser"); }
        }
        public string InfoRegistros
        {
            get { return _InfoRegistros; }
            set { _InfoRegistros = value; RaisePropertyChanged("InfoRegistros"); }
        }


        public RelayCommand textBuscar_KeyUp { get; set; }
        public RelayCommand btnNuevoUsuario_Click { get; set; }
        #endregion

        #region COMANDOS
        private void _textBuscar_KeyUp(object obj)
        {//UsuarioCtrlU.GetInstance().dataListadoUsuarios.ItemsSource = ListarUsuarios;
            RaisePropertyChanged("ListarUsuarios");
            _InfoRegistros = "Mostrando " + CountUser + " Registros de " + TotalCountUser;
            RaisePropertyChanged("InfoRegistros");
        }
        private void _btnNuevoUsuario_Click(object obj)
        {
            UsuariosWindow ventana = new UsuariosWindow();
            ventana.ShowDialog();
        }
        private void Usuarios_UsuarioChanged(object sender, System.EventArgs e)
        {
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() => { RaisePropertyChanged("ListarUsuarios"); }));
        }
        #endregion
    }
}
