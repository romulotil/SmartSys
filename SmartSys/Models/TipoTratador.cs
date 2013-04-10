using System;
using System.Collections.Generic;

namespace SmartSys.Models
{
    public partial class TipoTratador
    {
        public TipoTratador()
        {
            this.Consumidors = new List<Consumidor>();
        }

        public int CodTipoTratador { get; set; }
        public string TipoTratador1 { get; set; }
        public virtual ICollection<Consumidor> Consumidors { get; set; }
    }
}
