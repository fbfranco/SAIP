using SAIP.ViewModel;
using System.Data;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace SAIP
{
    public partial class winLogin : Window
    {
        #region PATRON SINGLETON
        private static winLogin Instance;
        public static winLogin GetInstance()
        {
            if (Instance == null)
            {
                Instance = new winLogin();
            }
            return Instance;
        }
        #endregion

        #region CONSTRUCTOR

        public winLogin()
        {
            InitializeComponent();
            this.Name = "View_Login";
            DataContext = new Login_ViewModel();
            textPassword.Visibility = Visibility.Hidden;
            textUsuario.Foreground = new SolidColorBrush(Color.FromRgb(200, 200, 200));
            textPasswordO.Foreground = new SolidColorBrush(Color.FromRgb(200, 200, 200));
        }

        #endregion

        #region EVENTOS DE LA BARRA DE TITULO

        private void contentOverAll_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        #endregion

        #region EFECTO PLACEHOLDER

        private void textUsuario_GotFocus(object sender, RoutedEventArgs e)
        {
            if (textUsuario.Text.Equals("Usuario"))
            {
                textUsuario.Text = "";
                textUsuario.Foreground = new SolidColorBrush(Color.FromRgb(0,0,0));
            }
        }

        private void textUsuario_LostFocus(object sender, RoutedEventArgs e)
        {
            if ("".Equals(textUsuario.Text))
            {
                textUsuario.Text = "Usuario";
                textUsuario.Foreground = new SolidColorBrush(Color.FromRgb(200, 200, 200));
            }
        }

        private void textPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            if ("".Equals(textPassword.Password))
            {
                textPassword.Visibility = Visibility.Hidden;
                textPasswordO.Visibility = Visibility.Visible;
                textPasswordO.Foreground = new SolidColorBrush(Color.FromRgb(200, 200, 200));
            }
        }

        private void textPasswordO_GotFocus(object sender, RoutedEventArgs e)
        {
            textPasswordO.Visibility = Visibility.Hidden;
            textPassword.Visibility = Visibility.Visible;
            textPassword.Focus();
        }

        #endregion

        public static DataRow[] login;
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            //if (textUsuario.Text.Equals("") || textPassword.Equals(""))
            //{
            //    MessageBox.Show("No se llenaron los campos correctamente", "SAIP", MessageBoxButton.OK, MessageBoxImage.Warning);
            //}
            //else
            //{
            //    DataTable usuarios = logUsuarios.ListarUsuarios("N", "");
            //    login = usuarios.Select("usuario='" + textUsuario.Text + "' and password='" + textPassword.Password + "'");

            //    if (login.Length > 0)
            //    {
            //        MainWindow form = new MainWindow(); 
            //        form.CDSidebar.Width = new GridLength(0);
            //        form.SideBar.Width = 0;
            //        form.myMediaTimeLine.Source = new Uri(@"Assets\video\Ipad.mp4", UriKind.Relative);
            //        form.Show();
            //        this.Hide();
            //    }
            //    else
            //    {
            //        MessageBox.Show("El Usuario o la contraseña no son válidos", "SAIP", MessageBoxButton.OK, MessageBoxImage.Warning);
            //    }
            //}
        }
    }
}
