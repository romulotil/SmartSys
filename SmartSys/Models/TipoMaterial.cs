using System;
using System.Collections.Generic;

namespace SmartSys.Models
{
    public partial class TipoMaterial
    {
        public TipoMaterial()
        {
            this.Consumidors = new List<Consumidor>();
            this.Consumidors1 = new List<Consumidor>();
        }

        public int CodTipoMaterial { get; set; }
        public string TipoMaterial1 { get; set; }
        public virtual ICollection<Consumidor> Consumidors { get; set; }
        public virtual ICollection<Consumidor> Consumidors1 { get; set; }
    }
}
