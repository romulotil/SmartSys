using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SmartSys.Models.Mapping
{
    public class TipoFiltroMap : EntityTypeConfiguration<TipoFiltro>
    {
        public TipoFiltroMap()
        {
            // Primary Key
            this.HasKey(t => t.CodTipoFiltro);

            // Properties
            this.Property(t => t.TipoFiltro1)
                .HasMaxLength(30);

            // Table & Column Mappings
            this.ToTable("TipoFiltro");
            this.Property(t => t.CodTipoFiltro).HasColumnName("CodTipoFiltro");
            this.Property(t => t.TipoFiltro1).HasColumnName("TipoFiltro");
        }
    }
}
