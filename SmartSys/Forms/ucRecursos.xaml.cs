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
using SmartSys.DAL;
using SmartSys.MDL;

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
            frmCadastroRecursos rec = new frmCadastroRecursos(_recurso, dtgRecursos.SelectedItem);
            rec.ShowDialog();
        }

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageBox.Show("Excluir o registro selecionado?", "SmartSys", MessageBoxButton.YesNo, MessageBoxImage.Warning).Equals(MessageBoxResult.Yes))
                {
                    switch (_recurso)
                    {
                        case "Agua":
                            new DLTipoAgua().Delete((MLTipoAgua)dtgRecursos.SelectedItem);
                            break;
                        case "Consumidor":
                            new DLTipoConsumidor().Delete((MLTipoConsumidor)dtgRecursos.SelectedItem);
                            break;
                        case "Tratador":
                            new DLTipoTratador().Delete((MLTipoTratador)dtgRecursos.SelectedItem);
                            break;
                        case "Material":
                            new DLTipoMaterial().Delete((MLTipoMaterial)dtgRecursos.SelectedItem);
                            break;
                        case "Filtro":
                            new DLTipoFiltro().Delete((MLTipoFiltro)dtgRecursos.SelectedItem);
                            break;
                        case "Produto":
                            new DLProduto().Delete((MLProduto)dtgRecursos.SelectedItem);
                            break;
                    }
                }
                MessageBox.Show("Registro excluído com sucesso.", "SmartSys", MessageBoxButton.OK, MessageBoxImage.Information);
                CarregarLista();
            }
            catch
            {
                MessageBox.Show("Não foi possível concluir a solicitação.", "SmartSys", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnAlterar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                frmCadastroRecursos rec = new frmCadastroRecursos(_recurso, dtgRecursos.SelectedItem);
                rec.ShowDialog();
                CarregarLista();
            }
            catch
            {
                MessageBox.Show("Não foi possível concluir a solicitação.", "SmartSys", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CarregarLista()
        {
            switch (_recurso)
            {
                case "Agua":
                    dtgRecursos.Columns.Clear();
                    DataGridTextColumn agua = new DataGridTextColumn();
                    agua.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
                    agua.Header = "Tipo de Água";
                    agua.Binding = new Binding("TipoAgua");
                    dtgRecursos.Columns.Add(agua);
                    dtgRecursos.ItemsSource = new DLTipoAgua().List();
                    break;
                case "Consumidor":
                    dtgRecursos.Columns.Clear();
                    DataGridTextColumn cons = new DataGridTextColumn();
                    cons.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
                    cons.Header = "Tipo de Consumidor";
                    cons.Binding = new Binding("TipoConsumidor");
                    dtgRecursos.Columns.Add(cons);
                    dtgRecursos.ItemsSource = new DLTipoConsumidor().List();
                    break;
                case "Tratador":
                    dtgRecursos.Columns.Clear();
                    DataGridTextColumn trat = new DataGridTextColumn();
                    trat.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
                    trat.Header = "Tipo de Tratador";
                    trat.Binding = new Binding("TipoTratador");
                    dtgRecursos.Columns.Add(trat);
                    dtgRecursos.ItemsSource = new DLTipoTratador().List();
                    break;
                case "Material":
                    dtgRecursos.Columns.Clear();
                    DataGridTextColumn mat = new DataGridTextColumn();
                    mat.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
                    mat.Header = "Tipo de Material";
                    mat.Binding = new Binding("TipoMaterial");
                    dtgRecursos.Columns.Add(mat);
                    dtgRecursos.ItemsSource = new DLTipoMaterial().List();
                    break;
                case "Filtro":
                    dtgRecursos.Columns.Clear();
                    DataGridTextColumn filt = new DataGridTextColumn();
                    filt.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
                    filt.Header = "Tipo de Filtro";
                    filt.Binding = new Binding("TipoFiltro");
                    dtgRecursos.Columns.Add(filt);
                    dtgRecursos.ItemsSource = new DLTipoFiltro().List();
                    break;
                case "Produto":
                    dtgRecursos.Columns.Clear();
                    DataGridTextColumn prod = new DataGridTextColumn();
                    prod.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
                    prod.Header = "Produto";
                    prod.Binding = new Binding("Produto");
                    dtgRecursos.Columns.Add(prod);
                    dtgRecursos.ItemsSource = new DLProduto().List();
                    break;
            }
        }

        private void btnNovo_Click(object sender, RoutedEventArgs e)
        {
            frmCadastroRecursos rec = new frmCadastroRecursos(_recurso);
            rec.ShowDialog();
            CarregarLista();
        }

        private void btnTipoConsumidor_Click(object sender, RoutedEventArgs e)
        {
            _recurso = "Consumidor";
            grdContent.Visibility = Visibility.Visible;
            lblRecurso.Content = "Tipo de Consumidores";
            CarregarLista();
        }

        private void btnTratador_Click(object sender, RoutedEventArgs e)
        {
            _recurso = "Tratador";
            grdContent.Visibility = Visibility.Visible;
            lblRecurso.Content = "Tipo de Tratadores";
            CarregarLista();
        }

        private void btnAgua_Click(object sender, RoutedEventArgs e)
        {
            _recurso = "Agua";
            grdContent.Visibility = Visibility.Visible;
            lblRecurso.Content = "Tipo de Águas";
            CarregarLista();
        }

        private void btnMaterial_Click(object sender, RoutedEventArgs e)
        {
            _recurso = "Material";
            grdContent.Visibility = Visibility.Visible;
            lblRecurso.Content = "Tipo de Revestimentos";
            CarregarLista();
        }

        private void btnFiltro_Click(object sender, RoutedEventArgs e)
        {
            _recurso = "Filtro";
            grdContent.Visibility = Visibility.Visible;
            lblRecurso.Content = "Tipo de Filtros";
            CarregarLista();
        }

        private void btnProdutos_Click(object sender, RoutedEventArgs e)
        {
            _recurso = "Produto";
            grdContent.Visibility = Visibility.Visible;
            lblRecurso.Content = "Produtos";
            CarregarLista();
        }
	}
}