using System.Linq;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using SmartSys.Models.Mapping;
using System.Collections.Generic;

namespace SmartSys.Models
{
    public partial class SmartSysContext : DbContext
    {
        static SmartSysContext()
        {
            Database.SetInitializer<SmartSysContext>(null);
        }

        public SmartSysContext()
            : base("Name=SmartSysContext")
        {
        }

        public DbSet<Consumidor> Consumidors { get; set; }
        public DbSet<ConsumidorProduto> ConsumidorProdutoes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<TipoAgua> TipoAguas { get; set; }
        public DbSet<TipoConsumidor> TipoConsumidors { get; set; }
        public DbSet<TipoFiltro> TipoFiltroes { get; set; }
        public DbSet<TipoMaterial> TipoMaterials { get; set; }
        public DbSet<TipoTratador> TipoTratadors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ConsumidorMap());
            modelBuilder.Configurations.Add(new ConsumidorProdutoMap());
            modelBuilder.Configurations.Add(new ProdutoMap());
            modelBuilder.Configurations.Add(new TipoAguaMap());
            modelBuilder.Configurations.Add(new TipoConsumidorMap());
            modelBuilder.Configurations.Add(new TipoFiltroMap());
            modelBuilder.Configurations.Add(new TipoMaterialMap());
            modelBuilder.Configurations.Add(new TipoTratadorMap());
        }

        public List<TipoConsumidor> TipoConsumidor
        {
            get { return TipoConsumidors.ToList(); }
        }
        public List<Consumidor> Consumidor
        {
            get { return Consumidors.ToList(); }
        }
        public List<ConsumidorProduto> ConsumidorProduto
        {
            get { return ConsumidorProdutoes.ToList(); }
        }
        public List<Produto> Produto
        {
            get { return Produtos.ToList(); }
        }
        public List<TipoAgua> TipoAgua
        {
            get { return TipoAguas.ToList(); }
        }
        public List<TipoFiltro> TipoFiltro
        {
            get { return TipoFiltroes.ToList(); }
        }
        public List<TipoMaterial> TipoMaterial
        {
            get { return TipoMaterials.ToList(); }
        }
        public List<TipoTratador> TipoTratador
        {
            get { return TipoTratadors.ToList(); }
        }
    }
}
