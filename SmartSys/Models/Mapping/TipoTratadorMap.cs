using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SmartSys.Models.Mapping
{
    public class TipoTratadorMap : EntityTypeConfiguration<TipoTratador>
    {
        public TipoTratadorMap()
        {
            // Primary Key
            this.HasKey(t => t.CodTipoTratador);

            // Properties
            this.Property(t => t.TipoTratador1)
                .HasMaxLength(30);

            // Table & Column Mappings
            this.ToTable("TipoTratador");
            this.Property(t => t.CodTipoTratador).HasColumnName("CodTipoTratador");
            this.Property(t => t.TipoTratador1).HasColumnName("TipoTratador");
        }
    }
}
