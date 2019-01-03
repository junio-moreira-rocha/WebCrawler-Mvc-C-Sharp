using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALZ.ConsultaProcessosTjmg.Dominio
{
    public class Processo
    {
        public int Id { get; set; }
        public string NumeroProcesso { get; set; }
        public string Autor { get; set; }
        public string Reu { get; set; }
        public string UltimaMovimentacao { get; set; }
        public DateTime DataConsulta { get; set; }
        public string Situacao { get; set; }
    }
}
