using System;
using System.Collections.Generic;

namespace SmartSys.Models
{
    public partial class Consumidor
    {
        public Consumidor()
        {
            this.ConsumidorProdutoes = new List<ConsumidorProduto>();
        }

        public int CodConsumidor { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public Nullable<int> Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string CEP { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public Nullable<bool> News { get; set; }
        public string Observacao { get; set; }
        public Nullable<int> CodTipoConsumidor { get; set; }
        public Nullable<int> CodTipoTratador { get; set; }
        public Nullable<int> CodTipoAgua { get; set; }
        public Nullable<int> CodTipoPiscina { get; set; }
        public Nullable<int> CodTipoSpa { get; set; }
        public Nullable<int> CodFiltroPiscina { get; set; }
        public Nullable<int> CodFiltroSpa { get; set; }
        public string VolPiscina { get; set; }
        public string VolSpa { get; set; }
        public virtual TipoMaterial TipoMaterial { get; set; }
        public virtual TipoMaterial TipoMaterial1 { get; set; }
        public virtual TipoAgua TipoAgua { get; set; }
        public virtual TipoConsumidor TipoConsumidor { get; set; }
        public virtual TipoFiltro TipoFiltro { get; set; }
        public virtual TipoFiltro TipoFiltro1 { get; set; }
        public virtual TipoTratador TipoTratador { get; set; }
        public virtual ICollection<ConsumidorProduto> ConsumidorProdutoes { get; set; }
    }
}
