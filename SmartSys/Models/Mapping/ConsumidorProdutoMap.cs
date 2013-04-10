using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SmartSys.Models.Mapping
{
    public class ConsumidorProdutoMap : EntityTypeConfiguration<ConsumidorProduto>
    {
        public ConsumidorProdutoMap()
        {
            // Primary Key
            this.HasKey(t => t.CodConsumidorProduto);

            // Properties
            // Table & Column Mappings
            this.ToTable("ConsumidorProduto");
            this.Property(t => t.CodConsumidorProduto).HasColumnName("CodConsumidorProduto");
            this.Property(t => t.CodConsumidor).HasColumnName("CodConsumidor");
            this.Property(t => t.CodProduto).HasColumnName("CodProduto");

            // Relationships
            this.HasOptional(t => t.Consumidor)
                .WithMany(t => t.ConsumidorProdutoes)
                .HasForeignKey(d => d.CodConsumidor);
            this.HasOptional(t => t.Produto)
                .WithMany(t => t.ConsumidorProdutoes)
                .HasForeignKey(d => d.CodProduto);

        }
    }
}
