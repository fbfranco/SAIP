using SAIP.Model;
using SAIP.Model.BusinessObject;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Threading;

namespace SAIP.ViewModel
{
    public class Empresa_ViewModel : ViewModelBase
    {
        #region CONSTRUCTOR DE LA CLASE

        public Empresa_ViewModel()
        {
            Empresa = new Empresa_BusinessObject();
            Empresa.EmpresaChanged += new EventHandler(EmpresaChanged);
        }


        #endregion

        #region CAMPOS DE LA CLASE
        Empresa_BusinessObject Empresa;
        ObservableCollection<Empresa_Model> _Empresas;
        #endregion

        #region PROPIEDADES O MÉTODOS DE LA CLASE

        public ObservableCollection<Empresa_Model> Empresas
        {
            get
            {
                return _Empresas = new ObservableCollection<Empresa_Model>(Empresa.GetEmpresas());
            }
        }

        #endregion

        #region COMMANDS

        private void EmpresaChanged(object sender, EventArgs e)
        {
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() => { RaisePropertyChanged("Empresas"); }));
        }

        #endregion
    }
}
