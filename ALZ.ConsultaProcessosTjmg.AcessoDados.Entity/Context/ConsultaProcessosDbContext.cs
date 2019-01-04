using ALZ.ConsultaProcessosTjmg.AcessoDados.Entity.TypeConfiguration;
using ALZ.ConsultaProcessosTjmg.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALZ.ConsultaProcessosTjmg.AcessoDados.Entity.Context
{
    public class ConsultaProcessosDbContext : DbContext
    {
        public DbSet<Processo> Processos { get; set; }

        public ConsultaProcessosDbContext()
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProcessoTypeConfiguration());
        }
    }
}
