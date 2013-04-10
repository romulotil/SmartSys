using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SmartSys.Models.Mapping
{
    public class ConsumidorMap : EntityTypeConfiguration<Consumidor>
    {
        public ConsumidorMap()
        {
            // Primary Key
            this.HasKey(t => t.CodConsumidor);

            // Properties
            this.Property(t => t.Nome)
                .HasMaxLength(60);

            this.Property(t => t.Endereco)
                .HasMaxLength(100);

            this.Property(t => t.Complemento)
                .HasMaxLength(30);

            this.Property(t => t.Bairro)
                .HasMaxLength(30);

            this.Property(t => t.Cidade)
                .HasMaxLength(50);

            this.Property(t => t.UF)
                .HasMaxLength(2);

            this.Property(t => t.CEP)
                .HasMaxLength(10);

            this.Property(t => t.Telefone)
                .HasMaxLength(20);

            this.Property(t => t.Celular)
                .HasMaxLength(20);

            this.Property(t => t.Email)
                .HasMaxLength(100);

            this.Property(t => t.Observacao)
                .HasMaxLength(200);

            this.Property(t => t.VolPiscina)
                .HasMaxLength(15);

            this.Property(t => t.VolSpa)
                .HasMaxLength(15);

            // Table & Column Mappings
            this.ToTable("Consumidor");
            this.Property(t => t.CodConsumidor).HasColumnName("CodConsumidor");
            this.Property(t => t.Nome).HasColumnName("Nome");
            this.Property(t => t.Endereco).HasColumnName("Endereco");
            this.Property(t => t.Numero).HasColumnName("Numero");
            this.Property(t => t.Complemento).HasColumnName("Complemento");
            this.Property(t => t.Bairro).HasColumnName("Bairro");
            this.Property(t => t.Cidade).HasColumnName("Cidade");
            this.Property(t => t.UF).HasColumnName("UF");
            this.Property(t => t.CEP).HasColumnName("CEP");
            this.Property(t => t.Telefone).HasColumnName("Telefone");
            this.Property(t => t.Celular).HasColumnName("Celular");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.News).HasColumnName("News");
            this.Property(t => t.Observacao).HasColumnName("Observacao");
            this.Property(t => t.CodTipoConsumidor).HasColumnName("CodTipoConsumidor");
            this.Property(t => t.CodTipoTratador).HasColumnName("CodTipoTratador");
            this.Property(t => t.CodTipoAgua).HasColumnName("CodTipoAgua");
            this.Property(t => t.CodTipoPiscina).HasColumnName("CodTipoPiscina");
            this.Property(t => t.CodTipoSpa).HasColumnName("CodTipoSpa");
            this.Property(t => t.CodFiltroPiscina).HasColumnName("CodFiltroPiscina");
            this.Property(t => t.CodFiltroSpa).HasColumnName("CodFiltroSpa");
            this.Property(t => t.VolPiscina).HasColumnName("VolPiscina");
            this.Property(t => t.VolSpa).HasColumnName("VolSpa");

            // Relationships
            this.HasOptional(t => t.TipoMaterial)
                .WithMany(t => t.Consumidors)
                .HasForeignKey(d => d.CodTipoPiscina);
            this.HasOptional(t => t.TipoMaterial1)
                .WithMany(t => t.Consumidors1)
                .HasForeignKey(d => d.CodTipoSpa);
            this.HasOptional(t => t.TipoAgua)
                .WithMany(t => t.Consumidors)
                .HasForeignKey(d => d.CodTipoAgua);
            this.HasOptional(t => t.TipoConsumidor)
                .WithMany(t => t.Consumidors)
                .HasForeignKey(d => d.CodTipoConsumidor);
            this.HasOptional(t => t.TipoFiltro)
                .WithMany(t => t.Consumidors)
                .HasForeignKey(d => d.CodFiltroPiscina);
            this.HasOptional(t => t.TipoFiltro1)
                .WithMany(t => t.Consumidors1)
                .HasForeignKey(d => d.CodFiltroSpa);
            this.HasOptional(t => t.TipoTratador)
                .WithMany(t => t.Consumidors)
                .HasForeignKey(d => d.CodTipoTratador);

        }
    }
}
