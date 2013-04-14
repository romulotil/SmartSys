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
using SmartSys.DAL;
using SmartSys.MDL;

namespace SmartSys
{
	/// <summary>
	/// Interaction logic for frmCadastroRecursos.xaml
	/// </summary>
	public partial class frmCadastroRecursos : Window
	{
        private string _recurso;
        private object _object;        

		public frmCadastroRecursos()
		{
			this.InitializeComponent();
		}

        public frmCadastroRecursos(string recurso)
        {
            this._recurso = recurso;
            this.InitializeComponent();
            lblRecurso.Content = recurso;
            this.Title = recurso;
            Loaded += frmCadastroRecursos_Loaded;
        }

        public frmCadastroRecursos(string recurso, object objeto)
        {
            this._recurso = recurso;
            this.InitializeComponent();
            lblRecurso.Content = recurso;
            this.Title = recurso;
            this._object = objeto;

            Loaded += frmCadastroRecursos_Loaded;
        }

        private void frmCadastroRecursos_Loaded(object sender, RoutedEventArgs e)
        {
            switch (_recurso)
            {
                case "Agua":
                    var ta = (MLTipoAgua)_object;
                    txtRecurso.Text = ta.TipoAgua;
                    break;
                case "Consumidor":
                    var tc = (MLTipoConsumidor)_object;
                    txtRecurso.Text = tc.TipoConsumidor;
                    break;
                case "Tratador":
                    var tt = (MLTipoTratador)_object;
                    txtRecurso.Text = tt.TipoTratador;
                    break;
                case "Material":
                    var tm = (MLTipoMaterial)_object;
                    txtRecurso.Text = tm.TipoMaterial;
                    break;
                case "Filtro":
                    var tf = (MLTipoFiltro)_object;
                    txtRecurso.Text = tf.TipoFiltro;
                    break;
                case "Produto":
                    var p = (MLProduto)_object;
                    txtRecurso.Text = p.Produto;
                    break;
            }
        }

        private void btnConfirmar_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtRecurso.Text))
            {
                try
                {
                    switch (_recurso)
                    {
                        case "Agua":
                            var ta = (MLTipoAgua)_object;
                            ta.TipoAgua = txtRecurso.Text;
                            new DLTipoAgua().InsertUpdate(ta);
                            break;
                        case "Consumidor":
                            var tc = (MLTipoConsumidor)_object;
                            tc.TipoConsumidor = txtRecurso.Text;
                            new DLTipoConsumidor().InsertUpdate(tc);
                            break;
                        case "Tratador":
                            var tt = (MLTipoTratador)_object;
                            tt.TipoTratador = txtRecurso.Text;
                            new DLTipoTratador().InsertUpdate(tt);
                            break;
                        case "Material":
                            var tm = (MLTipoMaterial)_object;
                            tm.TipoMaterial = txtRecurso.Text;
                            new DLTipoMaterial().InsertUpdate(tm);
                            break;
                        case "Filtro":
                            var tf = (MLTipoFiltro)_object;
                            tf.TipoFiltro = txtRecurso.Text;
                            new DLTipoFiltro().InsertUpdate(tf);
                            break;
                        case "Produto":
                            var p = (MLProduto)_object;
                            p.Produto = txtRecurso.Text;
                            new DLProduto().InsertUpdate(p);
                            break;
                    }
                    this.Close();
                }
                catch { }
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
	}
}