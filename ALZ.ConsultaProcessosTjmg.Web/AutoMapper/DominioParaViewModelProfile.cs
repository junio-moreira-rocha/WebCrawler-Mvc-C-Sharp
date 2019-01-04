using ALZ.ConsultaProcessosTjmg.Dominio;
using ALZ.ConsultaProcessosTjmg.Web.ViewModels.Processo;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ALZ.ConsultaProcessosTjmg.Web.AutoMapper
{
    public class DominioParaViewModelProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Processo, ProcessoIndexViewModel>();
        }
    }
}