using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SmartSys.Models.Mapping
{
    public class TipoMaterialMap : EntityTypeConfiguration<TipoMaterial>
    {
        public TipoMaterialMap()
        {
            // Primary Key
            this.HasKey(t => t.CodTipoMaterial);

            // Properties
            this.Property(t => t.TipoMaterial1)
                .HasMaxLength(30);

            // Table & Column Mappings
            this.ToTable("TipoMaterial");
            this.Property(t => t.CodTipoMaterial).HasColumnName("CodTipoMaterial");
            this.Property(t => t.TipoMaterial1).HasColumnName("TipoMaterial");
        }
    }
}
