using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace ALZ.ConsultaProcessosTjmg.Web.Utils
{
    public static class ExpressoesRegulares
    {
        public static string RecuperaNumeroProcesso(string text)
        {
            Match[] regexNumeroProcesso = Regex.Matches(text, @"NUMERAÇÃO ÚNICA:(.*)</b>").Cast<Match>().ToArray();
            string numeroProcesso = regexNumeroProcesso[0].Groups[1].Value.Trim();
            numeroProcesso = numeroProcesso.Replace("-", "").Replace(".", "");
            return numeroProcesso;
        }

        public static string RecuperaNomeAutor(string text)
        {
            Match[] regexAutor = Regex.Matches(text, @"<td><b>Autor:<\/b>&nbsp; <\/td>\s*<td>(.*)\s*</td>").Cast<Match>().ToArray();
            string autor = regexAutor[0].Groups[1].Value.Trim();
            autor = autor.ToUpper();
            return autor;
        }

        public static string RecuperaNomeReu(string text)
        {
            Match[] regexReu = Regex.Matches(text, @"<td><b>Réu :<\/b>&nbsp; <\/td>\s*<td>(.*)\s*<\/td>").Cast<Match>().ToArray();
            string reu = (regexReu[0].Groups[1].Value).Trim();
            reu = reu.ToUpper();
            return reu;
        }

        public static string RecuperaDescricaoUltimaMovimentacao(string text)
        {
            string regex = string.Format(@"<td id=" + "\"descricaoProc1_0\"" + @">(.*)&nbsp;&nbsp*; <\/td>");
            Match[] regexDescricaoUltimaMovimentacao = Regex.Matches(text, regex).Cast<Match>().ToArray();
            string descricaoUltimaMovimentacao = (regexDescricaoUltimaMovimentacao[0].Groups[1].Value).Trim();
            descricaoUltimaMovimentacao = descricaoUltimaMovimentacao.ToUpper();
            return descricaoUltimaMovimentacao;
        }

        public static string RecuperaDataUltimaMovimentacao(string text)
        {
            string regex = string.Format(@"<td id=" + "\"dataProc1_0\"" + @">(.*)<\/td>");
            Match[] regexDataUltimaMovimentacao = Regex.Matches(text, regex).Cast<Match>().ToArray();
            string dataUltimaMovimentacao = (regexDataUltimaMovimentacao[0].Groups[1].Value).Trim();
            return dataUltimaMovimentacao;
        }

        public static string RecuperaSituacaoProcesso(string text)
        {
            string regex = string.Format(@"id=" + "\"campoStatus\"" + @"><b>(.*)<\/b>");
            Match[] regexSituacaoProcesso = Regex.Matches(text, regex).Cast<Match>().ToArray();
            string situacaoProcesso = (regexSituacaoProcesso[0].Groups[1].Value).Trim();
            situacaoProcesso = situacaoProcesso.ToUpper();
            return situacaoProcesso;
        }
    }
}