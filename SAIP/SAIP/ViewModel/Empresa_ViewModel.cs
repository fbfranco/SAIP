using SAIP.Model;
using SAIP.BusinessObject;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Threading;
using SAIP.ViewModel.Base;
using SAIP.Service.DialogService;
using SAIP.Helpers;
using System.Windows.Media;

namespace SAIP.ViewModel
{
    public class Empresa_ViewModel : ViewModelBase
    {
        #region CONSTRUCTOR DE LA CLASE

        public Empresa_ViewModel()
        {
            Empresa = new Empresa_BusinessObject();
            Empresa.EmpresaChanged += new EventHandler(EmpresaChanged);

            btnChangedImg = new RelayCommand(_btnChangedImg);
            btnImgDefault = new RelayCommand(_btnImgDefault);
            btnCancelar = new RelayCommand(_btnCancelar);
            btnGuardar = new RelayCommand(_btnGuardar);
            EmpresaUC_Unloaded = new RelayCommand(_EmpresaUC_Unloaded);

            _Empresas = new ObservableCollection<Empresa_Model>(Empresa.GetEmpresas());
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
                return _Empresas;
            }
        }

        public RelayCommand btnChangedImg { get; set; }
        public RelayCommand btnImgDefault { get; set; }
        public RelayCommand btnCancelar { get; set; }
        public RelayCommand btnGuardar { get; set; }
        public RelayCommand EmpresaUC_Unloaded { get; set; }
        #endregion

        #region COMMANDS
        /******Evento Click de Button Cambiar Imagen******/
        private void _btnChangedImg(object obj)
        {
            var x = DialogService.Instance.OpenImage();
            _Empresas[0].Logo = x;
            RaisePropertyChanged("Empresas");
        }

        /******Evento Click de Button Imagen por defecto******/
        private void _btnImgDefault(object obj)
        {
            var x = Application.Current.FindResource("Img_BgLogin") as ImageSource;
            Empresas[0].Logo = x;
        }

        /******Evento Unloaded del EmpresaUserControl******/
        private void _EmpresaUC_Unloaded(object obj)
        {
            _Empresas = new ObservableCollection<Empresa_Model>(Empresa.GetEmpresas());
            RaisePropertyChanged("Empresas");
        }

        /******Evento Clic del Button Cancelar******/
        private void _btnCancelar(object obj)
        {
            _EmpresaUC_Unloaded(null);
        }

        /******Evento Click del Button Guardar******/
        private void _btnGuardar(object obj)
        {
            var x = Empresas[0];
            if (x.RazonSocial.Equals("")||x.Aniversario.Equals(""))
            {
                DialogService.Instance.MostrarMensaje("Los Campos no se llenaron correctamente.\n" +
                                                      "Revise e intente de nuevo por favor.", "SAIP", "Ok", "Warning");
            }
            else
            {
                if (Empresa.Editar(Empresas[0]))
                {
                    DialogService.Instance.MostrarMensaje("Los datos se guardaron correctamente.", "SAIP", "Ok", "Information");
                    RaisePropertyChanged("Empresas");
                }
            }
        }

        /******Notificar cambios al Modelo******/
        private void EmpresaChanged(object sender, EventArgs e)
        {
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() => { RaisePropertyChanged("Empresas"); }));
        }

        #endregion
    }
}
