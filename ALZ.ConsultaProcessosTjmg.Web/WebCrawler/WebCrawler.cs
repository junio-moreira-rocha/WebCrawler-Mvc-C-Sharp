using ALZ.ConsultaProcessosTjmg.Dominio;
using ALZ.ConsultaProcessosTjmg.Web.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace ALZ.ConsultaProcessosTjmg.Web.WebCrawler
{
    public class Crawler
    {
        private string html = string.Empty;
        public Processo AcessaTjmg(string numeroProcesso)
        {
            StringBuilder url = new StringBuilder("https://www4.tjmg.jus.br/juridico/sf/proc_resultado.jsp?tipoPesquisa=1&txtProcesso=");
            url.Append(numeroProcesso);
            url.Append("&comrCodigo=24&nomePessoa=&tipoPessoa=X&naturezaProcesso=0&situacaoParte=X&codigoOAB=&tipoOAB=N&ufOAB=MG&numero=1&select=1&tipoConsulta=1&natureza=0&ativoBaixado=X&listaProcessos=");
            url.Append(numeroProcesso);

            WebRequest request = WebRequest.Create(url.ToString());

            WebResponse response = request.GetResponse();

            Stream stream = response.GetResponseStream();

            using (StreamReader sr = new StreamReader(stream, Encoding.GetEncoding("ISO-8859-1")))
            {
                html = sr.ReadToEnd();
            }

            Processo processo = new Processo
            {
                NumeroProcesso = ExpressoesRegulares.RecuperaNumeroProcesso(html),
                Autor = ExpressoesRegulares.RecuperaNomeAutor(html),
                Reu = ExpressoesRegulares.RecuperaNomeReu(html),
                UltimaMovimentacao = ExpressoesRegulares.RecuperaDescricaoUltimaMovimentacao(html) + " ( EM: " + ExpressoesRegulares.RecuperaDataUltimaMovimentacao(html) + " )",
                Situacao = ExpressoesRegulares.RecuperaSituacaoProcesso(html),
                DataConsulta = DateTime.Now
            };

            return processo;
        }
    }
}