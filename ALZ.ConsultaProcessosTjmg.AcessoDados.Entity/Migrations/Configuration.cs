namespace ALZ.ConsultaProcessosTjmg.AcessoDados.Entity.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ALZ.ConsultaProcessosTjmg.AcessoDados.Entity.Context.ConsultaProcessosDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ALZ.ConsultaProcessosTjmg.AcessoDados.Entity.Context.ConsultaProcessosDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
