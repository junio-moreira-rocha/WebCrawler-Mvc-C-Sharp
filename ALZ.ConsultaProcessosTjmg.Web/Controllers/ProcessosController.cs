using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ALZ.ConsultaProcessosTjmg.AcessoDados.Entity.Context;
using ALZ.ConsultaProcessosTjmg.Dominio;
using ALZ.ConsultaProcessosTjmg.Web.ViewModels.Processo;
using ALZ.ConsultaProcessosTjmg.Web.WebCrawler;
using AutoMapper;

namespace ALZ.ConsultaProcessosTjmg.Web.Controllers
{
    public class ProcessosController : Controller
    {
        private ConsultaProcessosDbContext db = new ConsultaProcessosDbContext();

        // GET: Processos
        public ActionResult Index()
        {
            return View(Mapper.Map<List<Processo>, List<ProcessoExibicaoViewModel>>(db.Processos.ToList()));
        }

        // GET: Processos/FiltrarPorNumero/5
        public ActionResult FiltrarPorNumero(string numeroProcesso)
        {
            return View();
        }

        // POST: Processos/Busca
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FiltrarPorNumero([Bind(Include = "NumeroProcesso")] ProcessoViewModel viewModel)
        {
            viewModel.NumeroProcesso = viewModel.NumeroProcesso.Replace("-", "").Replace(".", "");
            Processo processo = Mapper.Map<ProcessoViewModel, Processo>(viewModel);
            using (var context = new ConsultaProcessosDbContext())
            {
                var processoExistente = context.Processos
                                        .Where(p => p.NumeroProcesso.Equals(viewModel.NumeroProcesso))
                                        .FirstOrDefault();
                processo = processoExistente;
                if (processo == null)
                {
                    ViewBag.Mensagem = "Processo não encontrado!";
                    return View();
                }                
            }

            return RedirectToAction("Details", new { id = processo.Id });
        }

        // GET: Processos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Processo processo = db.Processos.Find(id);
            if (processo == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Processo, ProcessoExibicaoViewModel>(processo));
        }

        // GET: Processos/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: Processos/Busca
        public ActionResult Busca()
        {
            return View();
        }

        // POST: Processos/Busca
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Busca([Bind(Include = "NumeroProcesso")] ProcessoViewModel viewModel)
        {
            viewModel.NumeroProcesso = viewModel.NumeroProcesso.Replace("-", "").Replace(".", "");
            Processo processo = Mapper.Map<ProcessoViewModel, Processo>(viewModel);
            using (var context = new ConsultaProcessosDbContext())
            {
                var processoExistente = context.Processos
                                        .Where(p => p.NumeroProcesso.Equals(viewModel.NumeroProcesso))
                                        .FirstOrDefault();
                if (processoExistente != null)
                {
                    Processo processoParaDeletar = db.Processos.Find(processoExistente.Id);
                    db.Processos.Remove(processoParaDeletar);
                    db.SaveChanges();
                }
            }
            Crawler crawler = new Crawler();
            processo = crawler.AcessaTjmg(viewModel.NumeroProcesso);
            db.Processos.Add(processo);
            db.SaveChanges();

            return RedirectToAction("Details", new { id = processo.Id });
        }

        // POST: Processos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NumeroProcesso,Autor,Reu,UltimaMovimentacao,Situacao")] ProcessoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Processo processo = Mapper.Map<ProcessoViewModel, Processo>(viewModel);
                processo.DataConsulta = DateTime.Now;
                db.Processos.Add(processo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        // GET: Processos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Processo processo = db.Processos.Find(id);
            if (processo == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Processo, ProcessoViewModel>(processo));
        }

        // POST: Processos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NumeroProcesso,Autor,Reu,UltimaMovimentacao,DataConsulta,Situacao")] ProcessoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Processo processo = Mapper.Map<ProcessoViewModel, Processo>(viewModel);
                db.Entry(processo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        // GET: Processos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Processo processo = db.Processos.Find(id);
            if (processo == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Processo, ProcessoExibicaoViewModel>(processo));
        }

        // POST: Processos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Processo processo = db.Processos.Find(id);
            db.Processos.Remove(processo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
