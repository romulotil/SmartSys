using System;
using System.Collections.Generic;
using System.Text;
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
	/// Interaction logic for frmCadastroRecursos.xaml
	/// </summary>
	public partial class frmCadastroRecursos : Window
	{
        private string _recurso;

		public frmCadastroRecursos()
		{
			this.InitializeComponent();
			
			// Insert code required on object creation below this point.
		}

        public frmCadastroRecursos(string recurso)
        {
            this._recurso = recurso;
            this.InitializeComponent();
            lblRecurso.Content = recurso;
            this.Title = recurso;
        }

        private void btnConfirmar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
	}
}