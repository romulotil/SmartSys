using System;
using System.Collections.Generic;

namespace SmartSys.Models
{
    public partial class TipoAgua
    {
        public TipoAgua()
        {
            this.Consumidors = new List<Consumidor>();
        }

        public int CodTipoAgua { get; set; }
        public string TipoAgua1 { get; set; }
        public virtual ICollection<Consumidor> Consumidors { get; set; }
    }
}
