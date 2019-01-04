using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ALZ.ConsultaProcessosTjmg.AcessoDados.Entity.Context;
using ALZ.ConsultaProcessosTjmg.Dominio;

namespace ALZ.ConsultaProcessosTjmg.Web.Controllers
{
    public class ProcessosController : Controller
    {
        private ConsultaProcessosDbContext db = new ConsultaProcessosDbContext();

        // GET: Processos
        public ActionResult Index()
        {
            return View(db.Processos.ToList());
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
            return View(processo);
        }

        // GET: Processos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Processos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NumeroProcesso,Autor,Reu,UltimaMovimentacao,DataConsulta,Situacao")] Processo processo)
        {
            if (ModelState.IsValid)
            {
                db.Processos.Add(processo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(processo);
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
            return View(processo);
        }

        // POST: Processos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NumeroProcesso,Autor,Reu,UltimaMovimentacao,DataConsulta,Situacao")] Processo processo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(processo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(processo);
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
            return View(processo);
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
