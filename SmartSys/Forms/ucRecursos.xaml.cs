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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SmartSys
{
	/// <summary>
	/// Interaction logic for ucRecursos.xaml
	/// </summary>
	public partial class ucRecursos : UserControl
	{
        private string _recurso = "";

		public ucRecursos()
		{
			this.InitializeComponent();
		}

        private void dtgRecursos_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAlterar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnNovo_Click(object sender, RoutedEventArgs e)
        {
            frmCadastroRecursos rec = new frmCadastroRecursos(_recurso);
            rec.ShowDialog();
        }

        private void btnTipoConsumidor_Click(object sender, RoutedEventArgs e)
        {
            _recurso = "Consumidor";
            grdContent.Visibility = Visibility.Visible;
            lblRecurso.Content = "Tipo de Consumidores";
        }

        private void btnTratador_Click(object sender, RoutedEventArgs e)
        {
            _recurso = "Tratador";
            grdContent.Visibility = Visibility.Visible;
            lblRecurso.Content = "Tipo de Tratadores";
        }

        private void btnAgua_Click(object sender, RoutedEventArgs e)
        {
            _recurso = "Agua";
            grdContent.Visibility = Visibility.Visible;
            lblRecurso.Content = "Tipo de Águas";
        }

        private void btnMaterial_Click(object sender, RoutedEventArgs e)
        {
            _recurso = "Material";
            grdContent.Visibility = Visibility.Visible;
            lblRecurso.Content = "Tipo de Revestimentos";
        }

        private void btnFiltro_Click(object sender, RoutedEventArgs e)
        {
            _recurso = "Filtro";
            grdContent.Visibility = Visibility.Visible;
            lblRecurso.Content = "Tipo de Filtros";
        }

        private void btnProdutos_Click(object sender, RoutedEventArgs e)
        {
            _recurso = "Produto";
            grdContent.Visibility = Visibility.Visible;
            lblRecurso.Content = "Produtos";
        }
	}
}