using FiapSmartCity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace FiapSmartCity.Repository.Context
{
    public class DataBaseContext : DbContext
    {
        public DbSet<TipoProdutoEF> TipoProdutoEF { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<CadastroPessoaEF> CadastroPessoaEF { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
                optionsBuilder.UseSqlServer(config.GetConnectionString("FiapSmartCityConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
       
