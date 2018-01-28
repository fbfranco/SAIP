using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SAIP.Helpers
{
    public class Accesoria
    {
        #region Métodos Accesorios
        //Método para hacer la conversión de imágenes desde el tipo Byte[] en la base de datos hasta ImageSource para las ventanas
        public static ImageSource ByteToImage(byte[] imageData)
        {
            BitmapImage biImg = new BitmapImage();
            MemoryStream ms = new MemoryStream(imageData);
            biImg.BeginInit();
            biImg.StreamSource = ms;
            biImg.EndInit();

            ImageSource imgSrc = biImg as ImageSource;

            return imgSrc;
        }

        //Método para Recorrer el Árbol Visual de Objetos de las Ventanas
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

        //Método para Recorrer el Árbol Visual de Objetos de las Ventanas Modificada
        public static IEnumerable<T> FindVisualChildren2<T>(DependencyObject depObj, int tipo) where T : DependencyObject
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

                    if (tipo == 1)
                    {
                        foreach (T childOfChild in FindVisualChildren2<T>(child, tipo))
                        {
                            yield return childOfChild;
                        }
                    }
                }
            }
        }
       
        //Formatear Fecha
        public static string DateFormater(DateTime fecha)
        {
            return fecha.ToShortDateString();
        }
        #endregion
    }
}
