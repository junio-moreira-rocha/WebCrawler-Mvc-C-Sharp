using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ALZ.ConsultaProcessosTjmg.Web.ViewModels.Processo
{
    public class ProcessoIndexViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Número do Processo")]
        public string NumeroProcesso { get; set; }
        [Display(Name = "Autor")]
        public string Autor { get; set; }
        [Display(Name = "Reu")]
        public string Reu { get; set; }
        [Display(Name = "Última Movimentação")]
        public string UltimaMovimentacao { get; set; }
        [Display(Name = "Data da Consulta")]
        public DateTime DataConsulta { get; set; }
        [Display(Name = "Situação")]
        public string Situacao { get; set; }
    }
}