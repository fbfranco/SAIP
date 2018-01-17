using SAIP.BusinessObject;
using SAIP.Model;
using SAIP.Service.DialogService;
using SAIP.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Threading;

namespace SAIP.ViewModel
{
    public class Documentos_ViewModel : ViewModelBase
    {
        #region CONSTRUCTOR
        public Documentos_ViewModel()
        {
            Documentos = new Documentos_BusinessObject();
            Documentos.DocumentosChanged += new EventHandler(DocumentosChanged);
            _ItemCboDocumentos = new ObservableCollection<string>();
            btnEditar_Click = new RelayCommand(_btnEditar_Click);
            btnCancelar_Click = new RelayCommand(_btnCancelar_Click);
            btnEliminar_Click = new RelayCommand(_btnEliminar_Click);
            btnGuardar_Click = new RelayCommand(_btnGuardar_Click);
            btnClosing_Click = new RelayCommand(_btnClosing_Click);
        }
        #endregion

        #region CAMPOS
        private static Documentos_BusinessObject Documentos;
        private static ObservableCollection<Documentos_Model> _ListarDocumentos;
        ObservableCollection<string> _ItemCboDocumentos;
        ICollectionView _DocumentosAgrupados;
        private object _SelectedItem;
        #endregion

        #region MÉTODOS O PROPIEDADES
        public static ObservableCollection<Documentos_Model> ListarDocumentos
        {
            get
            {
                return _ListarDocumentos = new ObservableCollection<Documentos_Model>(Documentos.GetDocumentos());
            }
        }
        public ObservableCollection<string> ItemCboDocumentos
        {
            get
            {
                _ItemCboDocumentos.Add("Persona");
                _ItemCboDocumentos.Add("Comprobante");
                return _ItemCboDocumentos;
            }
        }
        public ICollectionView DocumentosAgrupados
        {
            get
            {
                _DocumentosAgrupados = CollectionViewSource.GetDefaultView(ListarDocumentos);
                _DocumentosAgrupados.GroupDescriptions.Add(new PropertyGroupDescription("Tipo"));
                return _DocumentosAgrupados;
            }
            set { _DocumentosAgrupados = value; RaisePropertyChanged("DocumentosAgrupados"); }
        }
        public object SelectedItem
        {
            get { return _SelectedItem; }
            set { _SelectedItem = value; RaisePropertyChanged("SelectedItem"); }
        }
        public RelayCommand btnEditar_Click { get; set; }
        public RelayCommand btnCancelar_Click { get; set; }
        public RelayCommand btnEliminar_Click { get; set; }
        public RelayCommand btnClosing_Click { get; set; }
        public RelayCommand btnGuardar_Click { get; set; }
        #endregion

        #region COMANDOS
        /*******Notificar los Cambios al Modelo******/
        private void DocumentosChanged(object sender, EventArgs e)
        {
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() => RaisePropertyChanged("ListarDocumentos")));
        }

        /******Evento Click del Button Editar******/
        private void _btnEditar_Click(object parameter)
        {
            var Lista = new List<object>() { parameter };
            _SelectedItem = Lista;
            RaisePropertyChanged("SelectedItem");
        }

        /******Evento Click del Button Cancelar******/
        private void _btnCancelar_Click(object obj)
        {
            if (obj != null)
            {
                _SelectedItem = null;
            }
            else
            {
                var Lista = new List<object>() { obj };
                _SelectedItem = Lista;
            }
            RaisePropertyChanged("SelectedItem");
        }

        /******Evento Click del Button Eliminar******/
        private void _btnEliminar_Click(object obj)
        {
            if (DialogService.Instance.MostrarMensaje("¿Esta seguro de Eliminar el Documento Seleccionado?", "SAIP", "YesNo", "Question") == "Yes")
            {
                var data = obj as Documentos_Model;
                if (Documentos.Eliminar(data))
                {
                    DialogService.Instance.MostrarMensaje("El Documento se elminó correctamente", "SAIP", "OK", "Iformation");
                    RaisePropertyChanged("DocumentosAgrupados");
                }
            }    
        }

        /******Evento Click del Button Guardar******/
        private void _btnGuardar_Click(object obj)
        {
            string[] ParametersString = ((string)obj).Split(new char[] { ':' });

            if (ParametersString[1].Equals("") || ParametersString[2].Equals(""))
            {
                DialogService.Instance.MostrarMensaje("Los campos no se llenaron correctamente correctamente", "SAIP", "OK", "Warning");
            }
            else
            {
                var data = new Documentos_Model();
                data.Nombre = ParametersString[1];
                data.Tipo = ParametersString[2];

                if (!ParametersString[0].Equals(""))
                {
                    data.IdDocumento = int.Parse(ParametersString[0]);
                    if (Documentos.Editar(data))
                    {
                        DialogService.Instance.MostrarMensaje("El Documento se actualizó correctamente", "SAIP", "OK", "Iformation");
                        RaisePropertyChanged("DocumentosAgrupados");
                        _SelectedItem = null;
                        RaisePropertyChanged("SelectedItem");
                    }
                }
                else
                {

                    if (Documentos.Guardar(data))
                    {
                        DialogService.Instance.MostrarMensaje("El Documento se guardó correctamente", "SAIP", "OK", "Iformation");
                        RaisePropertyChanged("DocumentosAgrupados");
                        _SelectedItem = obj;
                        RaisePropertyChanged("SelectedItem");
                    }
                }
            }
        }

        /******Evento Click del Button Closing******/
        private void _btnClosing_Click(object obj)
        {
            if (DialogService.Instance.MostrarMensaje("¿Esta seguro que desea salir del Sistema?", "SAIP", "YesNo", "Question") == "Yes")
                DialogService.Instance.CerrarVentana("VentanaPrincipal");
        }
        #endregion
    }
}
