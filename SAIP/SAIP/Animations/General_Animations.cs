using SAIP.Helpers;
using SAIP.View.Windows;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace SAIP.Animations
{
    public class General_Animations
    {
        MainWindow MainView = ViewInstances.MainInstance;

        public void Acordeon_Animations(object sender)
        {
            Grid PanelActual = sender as Grid;
            Grid Padre = (Grid)PanelActual.Parent;
            Border Abuelo = (Border)Padre.Parent;
            StackPanel BisAbuelo = (StackPanel)Abuelo.Parent;

            var altoPanel = 0.00;
            DoubleAnimation DaSlideDownPanel = new DoubleAnimation();
            DaSlideDownPanel.Duration = new Duration(new TimeSpan(0, 0, 0, 0, 200));

            DoubleAnimation DaSlideUpPanel = new DoubleAnimation();
            DaSlideUpPanel.Duration = new Duration(new TimeSpan(0, 0, 0, 0, 200));

            //Primero: Cerrar los paneles abiertos
            foreach (Border item in Accesoria.FindVisualChildren2<Border>(BisAbuelo, 2))
            {
                if (item.Height > 35)
                {
                    DaSlideUpPanel.To = 35;
                    Storyboard sb1 = new Storyboard();
                    sb1.Children.Add(DaSlideUpPanel);
                    Storyboard.SetTarget(DaSlideUpPanel, item);
                    Storyboard.SetTargetProperty(DaSlideUpPanel, new PropertyPath("Height"));
                    PanelActual.BeginStoryboard(sb1);
                    break;
                }
            }

            //Segundo: Abrir el panel Seleccionado
            if (Abuelo.Height == 35)
            {
                foreach (Grid item in Accesoria.FindVisualChildren2<Grid>(Abuelo, 1))
                {
                    if (item.Height > 0)
                    {
                        altoPanel = altoPanel + item.Height;
                    }
                }
            }
            else
            {
                altoPanel = 35;
            }
            DaSlideDownPanel.To = altoPanel;
            Storyboard sb = new Storyboard();
            sb.Children.Add(DaSlideDownPanel);
            Storyboard.SetTarget(DaSlideDownPanel, Abuelo);
            Storyboard.SetTargetProperty(DaSlideDownPanel, new PropertyPath("Height"));
            Abuelo.BeginStoryboard(sb);
        }

        public void SliderSideBar_Animations(int v1)
        {
            var x = ViewInstances.MainInstance.SideBar;

            if (v1 == 0) ToggleHome(v1);

            DoubleAnimation SidebarAnimation = new DoubleAnimation();
            SidebarAnimation.Duration = new Duration(new TimeSpan(0, 0, 0, 0, 500));
            SidebarAnimation.From = v1 == 200 ? 0 : 200;
            SidebarAnimation.To = v1;
            Storyboard sb = new Storyboard();
            sb.Children.Add(SidebarAnimation);
            Storyboard.SetTarget(SidebarAnimation, x);
            Storyboard.SetTargetProperty(SidebarAnimation, new PropertyPath("Width"));
            x.BeginStoryboard(sb);

            DoubleAnimation HomeAnimation = new DoubleAnimation();
            HomeAnimation.Duration = new Duration(new TimeSpan(0, 0, 0, 0, 500));
            HomeAnimation.From = MainView.home.Opacity;
            HomeAnimation.To = MainView.home.Opacity == 0 ? 1 : 0;
            Storyboard sb1 = new Storyboard();
            sb1.Children.Add(HomeAnimation);
            Storyboard.SetTarget(HomeAnimation, MainView.home);
            Storyboard.SetTargetProperty(HomeAnimation, new PropertyPath("Opacity"));
            x.BeginStoryboard(sb1);

            DoubleAnimation MediaAnimation = new DoubleAnimation();
            MediaAnimation.Duration = new Duration(new TimeSpan(0, 0, 0, 0, 500));
            MediaAnimation.From = MainView.myMediaElement.Opacity;
            MediaAnimation.To = MainView.myMediaElement.Opacity == 0 ? 1 : 0;
            Storyboard sb2 = new Storyboard();
            sb2.Children.Add(MediaAnimation);
            Storyboard.SetTarget(MediaAnimation, MainView.myMediaElement);
            Storyboard.SetTargetProperty(MediaAnimation, new PropertyPath("Opacity"));
            x.BeginStoryboard(sb2);

            DoubleAnimation BackgroundAnimation = new DoubleAnimation();
            BackgroundAnimation.Duration = new Duration(new TimeSpan(0, 0, 0, 0, 500));
            BackgroundAnimation.From = MainView.backgroudOverAll.Opacity;
            BackgroundAnimation.To = MainView.backgroudOverAll.Opacity == 0 ? 1 : 0;
            Storyboard sb3 = new Storyboard();
            sb1.Children.Add(BackgroundAnimation);
            Storyboard.SetTarget(BackgroundAnimation, MainView.backgroudOverAll);
            Storyboard.SetTargetProperty(BackgroundAnimation, new PropertyPath("Opacity"));
            x.BeginStoryboard(sb3);

            if (v1 == 200)
            {
                DispatcherTimer Timer = new DispatcherTimer();
                Timer.Interval = new TimeSpan(0, 0, 0, 0, 510);
                Timer.Tick += (s, a) =>
                {
                    ToggleHome(v1);
                    Timer.Stop();
                };
                Timer.Start();
            }
        }

        private void ToggleHome(int v1)
        {
            if (v1 == 200)
            {
                MainView.myMediaElement.Stop();
                MainView.myMediaElement.Visibility = Visibility.Hidden;
                MainView.backgroudOverAll.Visibility = Visibility.Hidden;
                MainView.home.Visibility = Visibility.Hidden;
            }
            else
            {
                MainView.myMediaElement.Play();
                MainView.myMediaElement.Visibility = Visibility.Visible;
                MainView.backgroudOverAll.Visibility = Visibility.Visible;
                MainView.home.Visibility = Visibility.Visible;
            }

        }

        public void EfectoDesvanecer(int v1)
        {
            DoubleAnimation EfectoDesvanecer = new DoubleAnimation();
            EfectoDesvanecer.Duration = new Duration(new TimeSpan(0, 0, 0, 0, 500));
            EfectoDesvanecer.From = MainView.MainContainer.Opacity;
            EfectoDesvanecer.To = v1;
            Storyboard sb = new Storyboard();
            sb.Children.Add(EfectoDesvanecer);
            Storyboard.SetTarget(EfectoDesvanecer, MainView.MainContainer);
            Storyboard.SetTargetProperty(EfectoDesvanecer, new PropertyPath("Opacity"));
            MainView.MainContainer.BeginStoryboard(sb);
        }
    }
}
