using System;
using System.Collections.Generic;

namespace SmartSys.Models
{
    public partial class Produto
    {
        public Produto()
        {
            this.ConsumidorProdutoes = new List<ConsumidorProduto>();
        }

        public int CodProduto { get; set; }
        public string Produto1 { get; set; }
        public virtual ICollection<ConsumidorProduto> ConsumidorProdutoes { get; set; }
    }
}
