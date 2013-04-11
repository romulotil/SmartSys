using SmartSys.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Linq;
using SmartSys.DAL;
using SmartSys.MDL;

namespace SmartSys
{
	/// <summary>
	/// Interaction logic for udConsumidores.xaml
	/// </summary>
	public partial class ucConsumidores : UserControl
    {
        SmartSysContext context = new SmartSysContext();
        List<MLConsumidor> listaConsumidor = new List<MLConsumidor>();

		public ucConsumidores()
		{
			this.InitializeComponent();
		}

        private void btnAdicionar_Click(object sender, RoutedEventArgs e)
        {
            frmCadastroConsumidor cad = new frmCadastroConsumidor(new MLConsumidor());
            cad.ShowDialog();
            CarregaLista();
        }

        private void btnAlterar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MLConsumidor c = (MLConsumidor)dtgConsumidores.SelectedItem;
                frmCadastroConsumidor cad = new frmCadastroConsumidor(c);
                cad.ShowDialog();
                CarregaLista();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro durante a execução.\nErro: " + ex.Message, "SmartSys", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MLConsumidor index = (MLConsumidor)dtgConsumidores.SelectedItem;
                if (MessageBox.Show("Excluir o registro selecionado?", "SmartSys", MessageBoxButton.YesNo, MessageBoxImage.Warning).Equals(MessageBoxResult.Yes))
                {
                    new DLConsumidor().Delete(index.CodConsumidor);
                    MessageBox.Show("Registro excluído com sucesso.", "SmartSys", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                CarregaLista();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro durante a execução.\nErro: " + ex.Message, "SmartSys", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void dtgConsumidores_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            btnAlterar_Click(sender, e);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            CarregaLista();
        }

        private void CarregaLista()
        {
            DLConsumidor DL = new DLConsumidor();
            listaConsumidor = DL.ListarConsumidores();
            dtgConsumidores.ItemsSource = listaConsumidor;
        }
	}
}