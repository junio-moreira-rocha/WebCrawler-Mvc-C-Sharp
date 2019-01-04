namespace ALZ.ConsultaProcessosTjmg.AcessoDados.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracaoInicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PRC_PROCESSOS",
                c => new
                    {
                        PRC_ID = c.Int(nullable: false, identity: true),
                        PRC_NUMERO_PROCESSO = c.String(nullable: false, maxLength: 50),
                        PRC_AUTOR = c.String(nullable: false, maxLength: 100),
                        PRC_REU = c.String(nullable: false, maxLength: 100),
                        PRC_ULTIMA_MOVIMENTACAO = c.String(maxLength: 100),
                        PRC_DATA_CONSULTA = c.DateTime(nullable: false),
                        PRC_SITUACAO = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.PRC_ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PRC_PROCESSOS");
        }
    }
}
