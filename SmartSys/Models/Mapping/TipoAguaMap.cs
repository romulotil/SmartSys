using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SmartSys.Models.Mapping
{
    public class TipoAguaMap : EntityTypeConfiguration<TipoAgua>
    {
        public TipoAguaMap()
        {
            // Primary Key
            this.HasKey(t => t.CodTipoAgua);

            // Properties
            this.Property(t => t.TipoAgua1)
                .HasMaxLength(30);

            // Table & Column Mappings
            this.ToTable("TipoAgua");
            this.Property(t => t.CodTipoAgua).HasColumnName("CodTipoAgua");
            this.Property(t => t.TipoAgua1).HasColumnName("TipoAgua");
        }
    }
}
