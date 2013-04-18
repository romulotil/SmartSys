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
        #region Fields and Properties

        public string _operacao;
        public MLConsumidor Consumidor { get; set; }
        public List<MLConsumidorProduto> consumidorprodutos { get; set; }
        public List<MLProduto> produtos = new List<MLProduto>();
        public ObservableCollection<MLProduto> produtosSelecionados = new ObservableCollection<MLProduto>(); 

        #endregion

        #region Constructors

        public frmCadastroConsumidor()
        {
            this.InitializeComponent();
        }

        public frmCadastroConsumidor(MLConsumidor cons)
        {
            Consumidor = cons;
            this.DataContext = Consumidor;
            this.InitializeComponent();
            CarregarCombos();
            CarregarListas();
        } 

        #endregion

        #region Methods

        private void CarregarCombos()
        {
            cbbTipoConsumidor.ItemsSource = new DLTipoConsumidor().List();
            cbbTipoConsumidor.SelectedValuePath = "CodTipoConsumidor";
            cbbTipoConsumidor.DisplayMemberPath = "TipoConsumidor";

            cbbTratador.ItemsSource = new DLTipoTratador().List();
            cbbTratador.SelectedValuePath = "CodTipoTratador";
            cbbTratador.DisplayMemberPath = "TipoTratador";

            cbbAgua.ItemsSource = new DLTipoAgua().List();
            cbbAgua.SelectedValuePath = "CodTipoAgua";
            cbbAgua.DisplayMemberPath = "TipoAgua";

            cbbFiltroPiscina.ItemsSource = new DLTipoFiltro().List();
            cbbFiltroPiscina.SelectedValuePath = "CodTipoFiltro";
            cbbFiltroPiscina.DisplayMemberPath = "TipoFiltro";

            cbbFiltroSpa.ItemsSource = new DLTipoFiltro().List();
            cbbFiltroSpa.SelectedValuePath = "CodTipoFiltro";
            cbbFiltroSpa.DisplayMemberPath = "TipoFiltro";

            cbbPiscina.ItemsSource = new DLTipoMaterial().List();
            cbbPiscina.SelectedValuePath = "CodTipoMaterial";
            cbbPiscina.DisplayMemberPath = "TipoMaterial";

            cbbSpa.ItemsSource = new DLTipoMaterial().List();
            cbbSpa.SelectedValuePath = "CodTipoMaterial";
            cbbSpa.DisplayMemberPath = "TipoMaterial";

        }

        private void CarregarListas()
        {
            produtos = new DLProduto().List();
            if (Consumidor.ListaConsumidorProduto.Count > 0)
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

        private bool ValidarCadastro()
        {
            StringBuilder sb = new StringBuilder();
            if (string.IsNullOrEmpty(Consumidor.Nome))
            {
                sb.Append("- Nome;\n");
            }
            if (string.IsNullOrEmpty(Consumidor.Cidade))
            {
                sb.Append("- Cidade;\n");
            }
            if (string.IsNullOrEmpty(Consumidor.UF))
            {
                sb.Append("- UF;\n");
            }

            if (!string.IsNullOrEmpty(sb.ToString()))
            {
                MessageBox.Show("Campos obrigatórios:\n" + sb.ToString(), "SmartSys", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            else
            {
                return true;
            }
        } 

        #endregion

        #region Events

        private void btnConfirmar_Click(object sender, RoutedEventArgs e)
        {
            if (ValidarCadastro())
            {
                DLConsumidor DL = new DLConsumidor();
                try
                {
                    DL.InsertUpdateConsumidor(Consumidor);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro durante a execução.\nErro: " + ex.Message, "SmartSys", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                return;
            }
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

        #endregion
	}
}