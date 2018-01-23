﻿using System;
using System.Linq;
using System.Windows;

namespace SAIP.Service.DialogService
{
    public class DialogService : IDialogService
    {
        private static IDialogService _Instance;
        public static IDialogService Instance
        {
            get
            {
                var x = _Instance == null ? new DialogService() : _Instance;
                return x;
            }
            internal set { _Instance = value; }
        }

        /******Cerrar Ventanta******/
        public void CerrarVentana(string nombreVentana)
        {
            var ventana = Application.Current.Windows.OfType<Window>().Where(w => w.Name == nombreVentana).SingleOrDefault<Window>();
            if (nombreVentana.Equals("VentanaPrincipal"))
            {
                App.Current.Shutdown();
            }
            else
            {
                ventana.Close();
            }
           
        }

        /******Ocultar Ventana******/
        public void OcultarVentana(string nombreVentana)
        {
            var ventana = Application.Current.Windows.OfType<Window>().Where(w => w.Name == nombreVentana).SingleOrDefault<Window>();
            ventana.Hide();

        }

        /******Mostrar Mensaje******/
        public string MostrarMensaje(string contenido, string titulo, string botones, string imagen)
        {
            return MessageBox.Show(contenido, titulo, ObtenerBotones(botones), ObtenerImagen(imagen)).ToString();
        }

        /******Obtener Botones******/
        private MessageBoxButton ObtenerBotones(string botones)
        {
            MessageBoxButton _botones = new MessageBoxButton();
            switch (botones)
            {

                case "OK":

                    _botones = MessageBoxButton.OK;

                    break;

                case "YesNo":

                    _botones = MessageBoxButton.YesNo;

                    break;

                case "OKCancel":

                    _botones = MessageBoxButton.OKCancel;

                    break;

                case "YesNoCancel":

                    _botones = MessageBoxButton.YesNoCancel;

                    break;

            }

            return _botones;

        }

        /******Obtener Imagen******/
        private MessageBoxImage ObtenerImagen(string imagen)

        {

            MessageBoxImage _imagen = new MessageBoxImage();

            switch (imagen)

            {

                case "Error":

                    _imagen = MessageBoxImage.Error;

                    break;

                case "Hand":

                    _imagen = MessageBoxImage.Hand;

                    break;

                case "Information":

                    _imagen = MessageBoxImage.Information;

                    break;

                case "Question":

                    _imagen = MessageBoxImage.Question;

                    break;

                case "Warning":

                    _imagen = MessageBoxImage.Warning;

                    break;

                case "Stop":

                    _imagen = MessageBoxImage.Stop;

                    break;

                case "Exclamation":

                    _imagen = MessageBoxImage.Exclamation;

                    break;

                case "Asterisk":

                    _imagen = MessageBoxImage.Asterisk;
                    break;

                case "None":

                    _imagen = MessageBoxImage.None;

                    break;

            }

            return _imagen;

        }     
    }
}
