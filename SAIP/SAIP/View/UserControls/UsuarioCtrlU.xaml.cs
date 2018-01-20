using SAIP.Helpers;
using SAIP.View.Windows;
using SAIP.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SAIP.View.UserControls
{
    /// <summary>
    /// Lógica de interacción para UsuarioCtrlU.xaml
    /// </summary>
    public partial class UsuarioCtrlU : UserControl
    {
        #region SINGLETON
        private static UsuarioCtrlU Instance;
        public static UsuarioCtrlU GetInstance()
        {
            if( Instance == null)
            {
                Instance = new UsuarioCtrlU();
            }
            return Instance;
        }
        #endregion
        public UsuarioCtrlU()
        {
            DataContext = Usuario_ViewModel.GetInstance();
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //InfoRegistros();
            EnlazarEventos();
        }

        #region Funciones

        #region Función para buscar elementos en el DOM
        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
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

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }
        #endregion

        #region Enzalar eventos a los botones del datagrid
        private void EnlazarEventos()
        {
            foreach (Button item in FindVisualChildren<Button>(dataListadoUsuarios))
            {
                if ("btnEditar".Equals(item.Name))
                {
                    item.Click += new RoutedEventHandler(itemEditar_Click);
                }
                else if ("btnEliminar".Equals(item.Name))
                {
                    item.Click += new RoutedEventHandler(itemEliminar_Click);
                }
            }
        }
        #endregion

        #region Eventos de los botones del DataGrid
        private void itemEliminar_Click(object sender, RoutedEventArgs e)
        {
            DataRowView dr = dataListadoUsuarios.SelectedItem as DataRowView;
            MessageBox.Show(Convert.ToString(dr[0]));
        }

        private void itemEditar_Click(object sender, RoutedEventArgs e)
        {
            DataRowView dr = dataListadoUsuarios.SelectedItem as DataRowView;
            MessageBox.Show(Convert.ToString(dr[6]));
        }









        #endregion

        #endregion

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            ViewInstances.MainInstance.MainContainer.Children.Clear();
        }
    }
}
