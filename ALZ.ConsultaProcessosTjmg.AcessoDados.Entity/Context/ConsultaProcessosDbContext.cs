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
    }
}
