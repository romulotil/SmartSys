using SmartSys.DAL;
using SmartSys.MDL;
using System;
using System.Collections;
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
using System.Windows.Shapes;


namespace SmartSys
{
	/// <summary>
	/// Interaction logic for frmCadastroConsumidor.xaml
	/// </summary>
	public partial class frmCadastroConsumidor : Window
	{
        public string _operacao;
        public MLConsumidor Consumidor { get; set; }
        public List<MLConsumidorProduto> consumidorprodutos { get; set; }
        public List<MLProduto> produtos = new List<MLProduto>();
        public ObservableCollection<MLProduto> produtosSelecionados = new ObservableCollection<MLProduto>();
        
		public frmCadastroConsumidor()
        {
            this.InitializeComponent();          
		}

        public frmCadastroConsumidor(MLConsumidor cons)
        {
            Consumidor = cons;
            this.DataContext = Consumidor;
            this.InitializeComponent();
            CarregarListas();
        }

        private void CarregarListas()
        {
            produtos = new DLProduto().List();
            if (Consumidor.ListaConsumidorProduto.Count < 0)
            {
                foreach (MLConsumidorProduto cp in Consumidor.ListaConsumidorProduto)
                {
                    MLProduto produto = new MLProduto();
                    produto = produtos.Find(x => x.CodProduto == cp.CodProduto);
                    produtosSelecionados.Add(produto);
                }
            }
            lstProdutos.ItemsSource = produtos;
            lstProdutosSelecionados.ItemsSource = produtosSelecionados;
        }

        private void btnConfirmar_Click(object sender, RoutedEventArgs e)
        {
            DLConsumidor DL = new DLConsumidor();
            DL.InsertUpdateConsumidor(Consumidor);
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnEnviarTodos_Click(object sender, RoutedEventArgs e)
        {
            foreach (MLProduto produto in produtos)
            {
                if (Consumidor.ListaConsumidorProduto.FindAll(p => p.CodProduto == produto.CodProduto).Count <= 0)
                {
                    MLConsumidorProduto cp = new MLConsumidorProduto();
                    cp.CodProduto = produto.CodProduto;
                    Consumidor.ListaConsumidorProduto.Add(cp);
                    produtosSelecionados.Add(produto);
                }
            }
        }

        private void btnEnviar_Click(object sender, RoutedEventArgs e)
        {
            if (lstProdutos.SelectedItems.Count > 0)
            {
                foreach (MLProduto pro in lstProdutos.SelectedItems)
                {
                    if (Consumidor.ListaConsumidorProduto.FindAll(p => p.CodProduto == pro.CodProduto).Count <= 0)
                    {
                        MLConsumidorProduto cp = new MLConsumidorProduto();
                        cp.CodProduto = pro.CodProduto;
                        Consumidor.ListaConsumidorProduto.Add(cp);
                        produtosSelecionados.Add(pro);
                    }
                }
            }
        }

        private void btnRemover_Click(object sender, RoutedEventArgs e)
        {
            if (lstProdutosSelecionados.SelectedItems.Count > 0)
            {
                List<MLProduto> aux = new List<MLProduto>();
                foreach (MLProduto pro in lstProdutosSelecionados.SelectedItems)
                {
                    aux.Add(pro);
                    Consumidor.ListaConsumidorProduto.RemoveAll(cp => cp.CodProduto == pro.CodProduto);
                }
                foreach (MLProduto p in aux)
                {
                    produtosSelecionados.Remove(p);
                }
                
            }
        }

        private void btnRemoverTodos_Click(object sender, RoutedEventArgs e)
        {
            produtosSelecionados.Clear();
            Consumidor.ListaConsumidorProduto.Clear();
        }
	}
}