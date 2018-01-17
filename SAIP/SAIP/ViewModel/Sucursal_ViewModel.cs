using SAIP.BusinessObject;
using SAIP.Model;
using SAIP.ViewModel.Base;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Threading;

namespace SAIP.ViewModel
{
    public class Sucursal_ViewModel : ViewModelBase
    {
        #region CONSTRUCTOR
        public Sucursal_ViewModel()
        {
            Sucursal = new Sucursal_BusinessObject();
            Sucursal.SucursalChanged += new EventHandler(SucursalChanged);
        }
        #endregion

        #region CAMPOS
        Sucursal_BusinessObject Sucursal;
        ObservableCollection<Sucursal_Model> _ListaSucursalesActivas;
        #endregion

        #region MÉTODOS O PROPIEDADES
        public ObservableCollection<Sucursal_Model> ListaSucursalesActivas
        {
            get
            {
                return _ListaSucursalesActivas = new ObservableCollection<Sucursal_Model>(Sucursal.GetSucursales());
            }
        }
        #endregion

        #region COMANDOS
        /******Notificar los cambios en el Modelo******/
        private void SucursalChanged(object sender, EventArgs e)
        {
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() => { RaisePropertyChanged("ListaSucursalesActivas"); }));
        }
        #endregion
    }
}
