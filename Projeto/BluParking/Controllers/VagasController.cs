using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BluParking.DAL;
using BluParking.Models;

namespace BluParking.Controllers
{
    public class VagasController : Controller
    {

        private EFContext db = new EFContext();

        // GET: Vagas
        public ActionResult Index()
        {
            var vagas = db.Vagas.Include(v => v.TabelaPreco);
            return View(vagas.ToList());
        }

        // GET: Vagas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vaga vaga = db.Vagas.Find(id);
            if (vaga == null)
            {
                return HttpNotFound();
            }
            return View(vaga);
        }

        // GET: Vagas/Create
        public ActionResult Create()
        {
            Vaga vaga = new Vaga();
            var data = DateTime.Now;
            vaga.Entrada = data;
            ViewBag.TabelaPrecoID = new SelectList(db.TabelaPrecos.Where(t => t.DataInicio <= DateTime.Now && t.DataFim >= DateTime.Now), "TabelaPrecoID", "Preco");
            return View(vaga);
        }

        // POST: Vagas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VagaID,Placa,Entrada,Saida,Duracao,Tempo,ValorPagar,TabelaPrecoID")] Vaga vaga)
        {

            if (ModelState.IsValid)
            {
                db.Vagas.Add(vaga);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TabelaPrecoID = new SelectList(db.TabelaPrecos, "TabelaPrecoID", "Preco", vaga.TabelaPrecoID);
            return View(vaga);
        }

        // GET: Vagas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vaga vaga = db.Vagas.Find(id);
            if (vaga == null)
            {
                return HttpNotFound();
            }
            var data = DateTime.Now;
            vaga.Saida = data;

            //calculo tempo
            TimeSpan tempoDecorrido = data.Subtract(vaga.Entrada);
            vaga.Duracao = tempoDecorrido.ToString();
            vaga.Tempo = Convert.ToInt32(tempoDecorrido.TotalHours);

            ViewBag.TabelaPrecoID = new SelectList(db.TabelaPrecos.Where(t => t.DataInicio <= DateTime.Now && t.DataFim >= DateTime.Now), "TabelaPrecoID", "Preco", vaga.TabelaPrecoID);
            
            //calculo valor a pagar
            var preco = vaga.TabelaPreco.PrecoHoraAdicional;
            var horaInicial = vaga.TabelaPreco.Preco;
            
            if (tempoDecorrido.TotalMinutes <=30)
            {
                var total = horaInicial / 2;
                vaga.ValorPagar = total;
            }
            else if (tempoDecorrido.Minutes <=10)
            {
                var total = preco * tempoDecorrido.Hours;
                vaga.ValorPagar = total + (horaInicial - preco);
            }
            else if (tempoDecorrido.Minutes > 10)
            {
                var total = preco * tempoDecorrido.Hours;
                vaga.ValorPagar = total + horaInicial;
            }

            Console.Write(tempoDecorrido);


            return View(vaga);
        }

        // POST: Vagas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VagaID,Placa,Entrada,Saida,Duracao,Tempo,ValorPagar,TabelaPrecoID")] Vaga vaga)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vaga).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TabelaPrecoID = new SelectList(db.TabelaPrecos.Where(t => t.DataInicio <= DateTime.Now && t.DataFim >= DateTime.Now), "TabelaPrecoID", "Preco", vaga.TabelaPrecoID);
            return View(vaga);
        }

        // GET: Vagas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vaga vaga = db.Vagas.Find(id);
            if (vaga == null)
            {
                return HttpNotFound();
            }
            return View(vaga);
        }

        // POST: Vagas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vaga vaga = db.Vagas.Find(id);
            db.Vagas.Remove(vaga);
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
