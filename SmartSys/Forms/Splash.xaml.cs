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
	/// <summary>
	/// Interaction logic for Splash.xaml
	/// </summary>
	public partial class Splash : Window
	{
		public Splash()
		{
			this.InitializeComponent();
            //Loaded += Splash_Loaded;
		}

        private void Splash_Loaded(object sender, RoutedEventArgs e)
        {
            //Thread.Sleep(5000);
            //new Principal().Show();
            //this.Close();
            

        }
	}
}