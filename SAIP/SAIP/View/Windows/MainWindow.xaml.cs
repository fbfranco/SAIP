using SAIP.View.UserControls;
using SAIP.ViewModel;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;

namespace SAIP.View.Windows
{
    public partial class MainWindow : Window
    {
        #region Singleton
        private static MainWindow Instance;
        public static MainWindow GetInstance()
        {
            if (Instance == null)
            {
                Instance = new MainWindow();
            }
            return Instance;
        }
        #endregion

        #region Constructor
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new Main_ViewModel();
            InfoEmpresa.DataContext = new Empresa_ViewModel().Empresas;

            InicializarMenuAcordeon();
        }
        #endregion

        #region Menú Acordeon
        Double altoPanel;
        private void InicializarMenuAcordeon()
        {
            foreach (Border item in FindVisualChildren<Border>(stkPanel, 2))
            {

                foreach (Grid subItem in FindVisualChildren<Grid>(item, 1))
                {
                    if (subItem.Height == 35)
                    {
                        subItem.MouseLeftButtonDown += new MouseButtonEventHandler(item_MouseLeftButtonDown);
                        subItem.MouseEnter += new MouseEventHandler(item_MouseEnter);
                        subItem.MouseLeave += new MouseEventHandler(item_MouseLeave);
                    }
                    else if(subItem.Height > 0)
                    {
                        subItem.MouseEnter += new MouseEventHandler(subItem_MouseEnter);
                        subItem.MouseLeave += new MouseEventHandler(subItem_MouseLeave);
                        subItem.MouseLeftButtonDown += new MouseButtonEventHandler(subItem_MouseLefButtonDown);
                    }
                }
            }
        }

        private void subItem_MouseLefButtonDown(object sender, MouseButtonEventArgs e)
        {
            Grid btn = sender as Grid;
            Label lbl = btn.Children[1] as Label;

            switch (lbl.Content)
            {
                case "Usuarios":
                    MainContainer.Children.Clear();
                    MainContainer.Children.Add(new UsuarioCtrlU());
                    break;
                default:
                    break;
            }
        }
        
        private void item_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            altoPanel = 0;
            Grid PanelActual = sender as Grid;
            DoubleAnimation DaSlideDownPanel = new DoubleAnimation();
            DaSlideDownPanel.Duration = new Duration(new TimeSpan(0, 0, 0, 0, 200));

            DoubleAnimation DaSlideUpPanel = new DoubleAnimation();
            DaSlideUpPanel.Duration = new Duration(new TimeSpan(0, 0, 0, 0, 200));

            //Primero: Cerrar los paneles abiertos
            foreach (Border item in FindVisualChildren<Border>(stkPanel,2))
            {
                if (item.Height > 35)
                {
                    DaSlideUpPanel.To = 35;
                    Storyboard sb1 = new Storyboard();
                    sb1.Children.Add(DaSlideUpPanel);
                    Storyboard.SetTarget(DaSlideUpPanel, item);
                    Storyboard.SetTargetProperty(DaSlideUpPanel, new PropertyPath("Height"));
                    PanelActual.BeginStoryboard(sb1);
                    break;
                }
            }

            //Segundo: Abrir el panel Seleccionado
            Grid Padre = (Grid)PanelActual.Parent;
            Border Abuelo = (Border)Padre.Parent;
            if (Abuelo.Height == 35)
            {
                foreach (Grid item in FindVisualChildren<Grid>(Abuelo, 1))
                {
                    if (item.Height > 0)
                    {
                        altoPanel = altoPanel + item.Height;
                    }
                }
            }
            else
            {
                altoPanel = 35;
            }
            DaSlideDownPanel.To = altoPanel;
            Storyboard sb = new Storyboard();
            sb.Children.Add(DaSlideDownPanel);
            Storyboard.SetTarget(DaSlideDownPanel, Abuelo);
            Storyboard.SetTargetProperty(DaSlideDownPanel, new PropertyPath("Height"));
            Abuelo.BeginStoryboard(sb);
        }

        void item_MouseEnter(object sender, MouseEventArgs e)
        {
            Grid item = sender as Grid;
            item.Background = new SolidColorBrush(Color.FromRgb(62, 62, 64));
        }

        void item_MouseLeave(object sender, MouseEventArgs e)
        {
            Grid item = sender as Grid;
            item.Background = new SolidColorBrush(Color.FromRgb(30, 30, 30));
        }

        void subItem_MouseEnter(object sender, MouseEventArgs e)
        {
            Grid item = sender as Grid;
            item.Background = new SolidColorBrush(Color.FromRgb(62, 62, 64));
        }

        void subItem_MouseLeave(object sender, MouseEventArgs e)
        {
            Grid item = sender as Grid;
            if (item.Height != 35)
            {
                item.Background = new SolidColorBrush(Color.FromRgb(45, 45, 48));
            }
        }

        //Función para obtener los acceso a los controles
        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj, int tipo) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    if (tipo == 1)
                    {
                        foreach (T childOfChild in FindVisualChildren<T>(child,tipo))
                        {
                            yield return childOfChild;
                        }
                    }
                }
            }
        }
        #endregion

        #region Botones de la Barra de Título
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult cerrar = MessageBox.Show("¿Está seguro de salir del Sistema", "SAIP", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            if (cerrar == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        private void btnMaximizar_Click(object sender, RoutedEventArgs e)
        {
            if(this.WindowState == WindowState.Normal)
            {
                btnMaximizar.Background.SetValue(ImageBrush.ImageSourceProperty, new BitmapImage(new Uri(@"images/dashboard/reajustar.png".Replace(@"bin\Debug\",""),UriKind.Relative)));
                this.WindowState = WindowState.Maximized;
            }
            else
            {
                btnMaximizar.Background.SetValue(ImageBrush.ImageSourceProperty, new BitmapImage(new Uri(@"images/dashboard/maximizar.png", UriKind.Relative)));
                this.WindowState = WindowState.Normal;
            }
        }

        private void btnMinimizar_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        #endregion
    }
}
