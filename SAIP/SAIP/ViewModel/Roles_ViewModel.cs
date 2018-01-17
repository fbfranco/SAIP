using SAIP.BusinessObject;
using SAIP.Model;
using SAIP.ViewModel.Base;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Threading;

namespace SAIP.ViewModel
{
    public class Roles_ViewModel : ViewModelBase
    {
        #region CONSTRUCTOR
        public Roles_ViewModel()
        {
            Roles = new Roles_BusinessObject();
            Roles.RolesChanged += new EventHandler(RolesChanged);
        }

        #endregion

        #region CAMPOS
        Roles_BusinessObject Roles;
        ObservableCollection<Roles_Model> _ListarRoles;
        #endregion

        #region MÉTODOS O PROPIEDADES
        public ObservableCollection<Roles_Model> ListarRoles
        {
            get
            {
                return _ListarRoles = new ObservableCollection<Roles_Model>(Roles.GetRoles());
            }
        }
        #endregion

        #region COMANDOS
        /******Notificar los Cambiosal Modelo******/
        private void RolesChanged(object sender, EventArgs e)
        {
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() => RaisePropertyChanged("ListarRoles")));
        }
        #endregion
    }
}
