using ALZ.Comum.Entity;
using ALZ.ConsultaProcessosTjmg.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALZ.ConsultaProcessosTjmg.AcessoDados.Entity.TypeConfiguration
{
    class ProcessoTypeConfiguration : ALZEntityAbstractConfig<Processo>
    {
        protected override void ConfigurarCamposTabela()
        {
            Property(p => p.Id)
                .IsRequired()
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .HasColumnName("PRC_ID");

            Property(p => p.NumeroProcesso)
                .IsRequired()
                .HasColumnName("PRC_NUMERO_PROCESSO")
                .HasMaxLength(50);

            Property(p => p.Autor)
                .IsRequired()
                .HasColumnName("PRC_AUTOR")
                .HasMaxLength(100);

            Property(p => p.Reu)
                .IsRequired()
                .HasColumnName("PRC_REU")
                .HasMaxLength(100);

            Property(p => p.UltimaMovimentacao)
                .IsOptional()
                .HasColumnName("PRC_ULTIMA_MOVIMENTACAO")
                .HasMaxLength(100);

            Property(p => p.Situacao)
                .IsRequired()
                .HasColumnName("PRC_SITUACAO")
                .HasMaxLength(50);

            Property(p => p.DataConsulta)
                .IsRequired()
                //.HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Computed)
                .HasColumnName("PRC_DATA_CONSULTA");

        }

        protected override void ConfigurarChavePrimaria()
        {
            HasKey(pk => pk.Id);
        }

        protected override void ConfigurarChavesEstrangeiras()
        {
        }

        protected override void ConfigurarNomeTabela()
        {
            ToTable("PRC_PROCESSOS");
        }
    }
}
