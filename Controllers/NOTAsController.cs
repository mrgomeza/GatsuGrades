using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Prueba;

namespace Prueba.Controllers
{
    public class NOTAsController : Controller
    {
        private GatsuGradesv6Entities1 db = new GatsuGradesv6Entities1();

        // GET: NOTAs
        public ActionResult Index()
        {
            var nOTA = db.NOTA.Include(n => n.ANO_LECTIVO).Include(n => n.ESTUDIANTE).Include(n => n.MATERIA);
            return View(nOTA.ToList());
        }

        // GET: NOTAs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NOTA nOTA = db.NOTA.Find(id);
            if (nOTA == null)
            {
                return HttpNotFound();
            }
            return View(nOTA);
        }

        // GET: NOTAs/Create
        public ActionResult Create()
        {
            ViewBag.ID_ANO = new SelectList(db.ANO_LECTIVO, "ID_ANO", "ANO_DESCRIP");
            ViewBag.ID_ESTUDIANTE = new SelectList(db.ESTUDIANTE, "ID_ESTUDIANTE", "EST_USU");
            ViewBag.ID_MATERIA = new SelectList(db.MATERIA, "ID_MATERIA", "MAT_COD");
            return View();
        }

        // POST: NOTAs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_NOTA,ID_MATERIA,ID_ESTUDIANTE,ID_ANO,NP1,NP2,NP3,EQ1,Q1,NP4,NP5,NP6,EQ2,Q2,FINAL")] NOTA nOTA)
        {
            if (ModelState.IsValid)
            {
                db.NOTA.Add(nOTA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_ANO = new SelectList(db.ANO_LECTIVO, "ID_ANO", "ANO_DESCRIP", nOTA.ID_ANO);
            ViewBag.ID_ESTUDIANTE = new SelectList(db.ESTUDIANTE, "ID_ESTUDIANTE", "EST_USU", nOTA.ID_ESTUDIANTE);
            ViewBag.ID_MATERIA = new SelectList(db.MATERIA, "ID_MATERIA", "MAT_COD", nOTA.ID_MATERIA);
            return View(nOTA);
        }

        // GET: NOTAs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NOTA nOTA = db.NOTA.Find(id);
            if (nOTA == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_ANO = new SelectList(db.ANO_LECTIVO, "ID_ANO", "ANO_DESCRIP", nOTA.ID_ANO);
            ViewBag.ID_ESTUDIANTE = new SelectList(db.ESTUDIANTE, "ID_ESTUDIANTE", "EST_USU", nOTA.ID_ESTUDIANTE);
            ViewBag.ID_MATERIA = new SelectList(db.MATERIA, "ID_MATERIA", "MAT_COD", nOTA.ID_MATERIA);
            return View(nOTA);
        }

        // POST: NOTAs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_NOTA,ID_MATERIA,ID_ESTUDIANTE,ID_ANO,NP1,NP2,NP3,EQ1,Q1,NP4,NP5,NP6,EQ2,Q2,FINAL")] NOTA nOTA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nOTA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_ANO = new SelectList(db.ANO_LECTIVO, "ID_ANO", "ANO_DESCRIP", nOTA.ID_ANO);
            ViewBag.ID_ESTUDIANTE = new SelectList(db.ESTUDIANTE, "ID_ESTUDIANTE", "EST_USU", nOTA.ID_ESTUDIANTE);
            ViewBag.ID_MATERIA = new SelectList(db.MATERIA, "ID_MATERIA", "MAT_COD", nOTA.ID_MATERIA);
            return View(nOTA);
        }

        // GET: NOTAs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NOTA nOTA = db.NOTA.Find(id);
            if (nOTA == null)
            {
                return HttpNotFound();
            }
            return View(nOTA);
        }

        // POST: NOTAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NOTA nOTA = db.NOTA.Find(id);
            db.NOTA.Remove(nOTA);
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
