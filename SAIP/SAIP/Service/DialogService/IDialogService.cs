using SAIP.ViewModel.Base;
using System;

namespace SAIP.Service.DialogService
{
    public interface IDialogService
    {
        string MostrarMensaje(string contenido, string titulo, string botones, string imagen);

        void OcultarVentana(string nombreVentana);

        void CerrarVentana(string nombreVentana);
    }
}
