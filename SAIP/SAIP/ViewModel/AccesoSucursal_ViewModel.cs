using SAIP.Model;
using SAIP.Model.BusinessObject;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;
using System.Windows.Threading;

namespace SAIP.ViewModel
{
    public class AccesoSucursal_ViewModel : ViewModelBase
    {
        #region CONSTRUCTOR DE LA CLASE
        public AccesoSucursal_ViewModel()
        {
            Accesos = new AccesoSucursal_BusinessObject();
            Accesos.AccesoSucursalChanged += new EventHandler(Acceso_AccesoSucursalChanged);
            
            NombreSucursal = "";
        }
        #endregion

        #region CAMPOS DE LA CLASE
        AccesoSucursal_BusinessObject Accesos;
        ObservableCollection<AccesoSucursal_Model> _AccesosSucursales;
        ObservableCollection<DataRow[]> _SucursalesActivas = new ObservableCollection<DataRow[]>();
        public static string NombreSucursal;
        #endregion

        #region PROPIEDADES O MÉTODOS DE LA CLASE
        public ObservableCollection<AccesoSucursal_Model> AccesosSucursales
        {
            get
            {
                return _AccesosSucursales;
            }
        }
        
       
        #endregion

        #region COMMANDS
        //
        //Cambio y actualización de datos para los Métodos
        //
        private void Acceso_AccesoSucursalChanged(object sender, EventArgs e)
        {
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() => { RaisePropertyChanged("AccesosSucursales"); }));
        }
        
        #endregion
    }
}
