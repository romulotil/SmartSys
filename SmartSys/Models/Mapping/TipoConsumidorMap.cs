using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SmartSys.Models.Mapping
{
    public class TipoConsumidorMap : EntityTypeConfiguration<TipoConsumidor>
    {
        public TipoConsumidorMap()
        {
            // Primary Key
            this.HasKey(t => t.CodTipoConsumidor);

            // Properties
            this.Property(t => t.TipoConsumidor1)
                .HasMaxLength(30);

            // Table & Column Mappings
            this.ToTable("TipoConsumidor");
            this.Property(t => t.CodTipoConsumidor).HasColumnName("CodTipoConsumidor");
            this.Property(t => t.TipoConsumidor1).HasColumnName("TipoConsumidor");
        }
    }
}
