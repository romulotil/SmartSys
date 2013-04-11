using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SmartSys
{
	public partial class Principal : Window
	{
		public Principal()
		{
            Splash splash = new Splash();
            splash.Show();
            Thread.Sleep(5000);
            splash.Close();

			this.InitializeComponent();
            //Thread th = new Thread(() =>
            //{
            //    Splash splash = new Splash();
            //    splash.Show();
            //    Thread.Sleep(5000);
            //});

            //th.Start();
		}

        private void btnSair_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Deseja sair do sistema?", "SmartSys", MessageBoxButton.YesNo, MessageBoxImage.Warning).Equals(MessageBoxResult.Yes))
            {
                this.Close();
            }
        }

        private void btnRelatorios_Click(object sender, RoutedEventArgs e)
        {
            ucRelatorio rel = new ucRelatorio();
            grdContainer.Children.Clear();
            grdContainer.Children.Add(rel);
        }

        private void btnConsumidores_Click(object sender, RoutedEventArgs e)
        {
            ucConsumidores cons = new ucConsumidores();
            grdContainer.Children.Clear();
            grdContainer.Children.Add(cons);
        }

        private void btnRecursos_Click(object sender, RoutedEventArgs e)
        {
            ucRecursos rec = new ucRecursos();
            grdContainer.Children.Clear();
            grdContainer.Children.Add(rec);
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }
	}
}