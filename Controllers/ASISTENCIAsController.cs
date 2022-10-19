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
    public class ASISTENCIAsController : Controller
    {
        private GatsuGradesv6Entities1 db = new GatsuGradesv6Entities1();

        // GET: ASISTENCIAs
        public ActionResult Index()
        {
            var aSISTENCIA = db.ASISTENCIA.Include(a => a.ESTUDIANTE).Include(a => a.HORARIO);
            return View(aSISTENCIA.ToList());
        }

        // GET: ASISTENCIAs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ASISTENCIA aSISTENCIA = db.ASISTENCIA.Find(id);
            if (aSISTENCIA == null)
            {
                return HttpNotFound();
            }
            return View(aSISTENCIA);
        }

        // GET: ASISTENCIAs/Create
        public ActionResult Create()
        {
            ViewBag.ID_ESTUDIANTE = new SelectList(db.ESTUDIANTE, "ID_ESTUDIANTE", "EST_USU");
            ViewBag.ID_HORARIO = new SelectList(db.HORARIO, "ID_HORARIO", "HOR_DIA");
            return View();
        }

        // POST: ASISTENCIAs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_ASIS,ID_HORARIO,ID_ESTUDIANTE,ASIS_FECHA,ASIS_CONF")] ASISTENCIA aSISTENCIA)
        {
            if (ModelState.IsValid)
            {
                db.ASISTENCIA.Add(aSISTENCIA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_ESTUDIANTE = new SelectList(db.ESTUDIANTE, "ID_ESTUDIANTE", "EST_USU", aSISTENCIA.ID_ESTUDIANTE);
            ViewBag.ID_HORARIO = new SelectList(db.HORARIO, "ID_HORARIO", "HOR_DIA", aSISTENCIA.ID_HORARIO);
            return View(aSISTENCIA);
        }

        // GET: ASISTENCIAs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ASISTENCIA aSISTENCIA = db.ASISTENCIA.Find(id);
            if (aSISTENCIA == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_ESTUDIANTE = new SelectList(db.ESTUDIANTE, "ID_ESTUDIANTE", "EST_USU", aSISTENCIA.ID_ESTUDIANTE);
            ViewBag.ID_HORARIO = new SelectList(db.HORARIO, "ID_HORARIO", "HOR_DIA", aSISTENCIA.ID_HORARIO);
            return View(aSISTENCIA);
        }

        // POST: ASISTENCIAs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_ASIS,ID_HORARIO,ID_ESTUDIANTE,ASIS_FECHA,ASIS_CONF")] ASISTENCIA aSISTENCIA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aSISTENCIA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_ESTUDIANTE = new SelectList(db.ESTUDIANTE, "ID_ESTUDIANTE", "EST_USU", aSISTENCIA.ID_ESTUDIANTE);
            ViewBag.ID_HORARIO = new SelectList(db.HORARIO, "ID_HORARIO", "HOR_DIA", aSISTENCIA.ID_HORARIO);
            return View(aSISTENCIA);
        }

        // GET: ASISTENCIAs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ASISTENCIA aSISTENCIA = db.ASISTENCIA.Find(id);
            if (aSISTENCIA == null)
            {
                return HttpNotFound();
            }
            return View(aSISTENCIA);
        }

        // POST: ASISTENCIAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ASISTENCIA aSISTENCIA = db.ASISTENCIA.Find(id);
            db.ASISTENCIA.Remove(aSISTENCIA);
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
