namespace ALZ.ConsultaProcessosTjmg.AcessoDados.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AtualizacaoTabela : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PRC_PROCESSOS", "PRC_DATA_CONSULTA", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PRC_PROCESSOS", "PRC_DATA_CONSULTA", c => c.DateTime(nullable: false));
        }
    }
}
