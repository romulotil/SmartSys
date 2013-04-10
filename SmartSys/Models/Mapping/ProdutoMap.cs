using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SmartSys.Models.Mapping
{
    public class ProdutoMap : EntityTypeConfiguration<Produto>
    {
        public ProdutoMap()
        {
            // Primary Key
            this.HasKey(t => t.CodProduto);

            // Properties
            this.Property(t => t.CodProduto)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Produto1)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Produtos");
            this.Property(t => t.CodProduto).HasColumnName("CodProduto");
            this.Property(t => t.Produto1).HasColumnName("Produto");
        }
    }
}
