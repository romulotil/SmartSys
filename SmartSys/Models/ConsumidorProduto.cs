using System;
using System.Collections.Generic;

namespace SmartSys.Models
{
    public partial class ConsumidorProduto
    {
        public int CodConsumidorProduto { get; set; }
        public Nullable<int> CodConsumidor { get; set; }
        public Nullable<int> CodProduto { get; set; }
        public virtual Consumidor Consumidor { get; set; }
        public virtual Produto Produto { get; set; }
    }
}
