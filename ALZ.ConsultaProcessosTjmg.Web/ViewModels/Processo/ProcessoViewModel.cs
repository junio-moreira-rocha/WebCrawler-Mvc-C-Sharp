using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ALZ.ConsultaProcessosTjmg.Web.ViewModels.Processo
{
    public class ProcessoViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O Número do Processo é obrigatório!")]
        [Display(Name = "Número do Processo")]
        public string NumeroProcesso { get; set; }

        [Required(ErrorMessage = "O nome do Autor é obrigatório!")]
        [Display(Name = "Autor")]
        public string Autor { get; set; }

        [Required(ErrorMessage = "O nome Reu é obrigatório!")]
        [Display(Name = "Reu")]
        public string Reu { get; set; }

        [Required(ErrorMessage = "A Última Movimentação é obrigatória!")]
        [Display(Name = "Última Movimentação")]
        public string UltimaMovimentacao { get; set; }

        [Required(ErrorMessage = "A Data da Consulta é obrigatória!")]
        [Display(Name = "Data da Consulta")]
        public DateTime DataConsulta { get; set; }

        [Required(ErrorMessage = "A Situação é obrigatória!")]
        [Display(Name = "Situação")]
        public string Situacao { get; set; }
    }
}