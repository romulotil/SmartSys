using System;
using System.Collections.Generic;

namespace SmartSys.Models
{
    public partial class TipoFiltro
    {
        public TipoFiltro()
        {
            this.Consumidors = new List<Consumidor>();
            this.Consumidors1 = new List<Consumidor>();
        }

        public int CodTipoFiltro { get; set; }
        public string TipoFiltro1 { get; set; }
        public virtual ICollection<Consumidor> Consumidors { get; set; }
        public virtual ICollection<Consumidor> Consumidors1 { get; set; }
    }
}
