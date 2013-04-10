using System;
using System.Collections.Generic;

namespace SmartSys.Models
{
    public partial class TipoConsumidor
    {
        public TipoConsumidor()
        {
            this.Consumidors = new List<Consumidor>();
        }

        public int CodTipoConsumidor { get; set; }
        public string TipoConsumidor1 { get; set; }
        public virtual ICollection<Consumidor> Consumidors { get; set; }
    }
}
