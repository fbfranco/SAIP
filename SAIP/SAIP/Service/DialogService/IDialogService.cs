using SAIP.ViewModel.Base;

namespace SAIP.Service.DialogService
{
    public interface IDialogService
    {
        string MostrarMensaje(string contenido, string titulo, string botones, string imagen);

        void MostrarVentana(ViewModelBase viewModel);

        void CerrarVentana(string nombreVentana);
    }
}
