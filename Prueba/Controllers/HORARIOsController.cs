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
    public class HORARIOsController : Controller
    {
        private GatsuGradesv6Entities db = new GatsuGradesv6Entities();

        // GET: HORARIOs
        public ActionResult Index()
        {
            var hORARIO = db.HORARIO.Include(h => h.MATERIA);
            return View(hORARIO.ToList());
        }

        // GET: HORARIOs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HORARIO hORARIO = db.HORARIO.Find(id);
            if (hORARIO == null)
            {
                return HttpNotFound();
            }
            return View(hORARIO);
        }

        // GET: HORARIOs/Create
        public ActionResult Create()
        {
            ViewBag.ID_MATERIA = new SelectList(db.MATERIA, "ID_MATERIA", "MAT_COD");
            return View();
        }

        // POST: HORARIOs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_HORARIO,ID_MATERIA,HOR_DIA,HOR_HORA")] HORARIO hORARIO)
        {
            if (ModelState.IsValid)
            {
                db.HORARIO.Add(hORARIO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_MATERIA = new SelectList(db.MATERIA, "ID_MATERIA", "MAT_COD", hORARIO.ID_MATERIA);
            return View(hORARIO);
        }

        // GET: HORARIOs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HORARIO hORARIO = db.HORARIO.Find(id);
            if (hORARIO == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_MATERIA = new SelectList(db.MATERIA, "ID_MATERIA", "MAT_COD", hORARIO.ID_MATERIA);
            return View(hORARIO);
        }

        // POST: HORARIOs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_HORARIO,ID_MATERIA,HOR_DIA,HOR_HORA")] HORARIO hORARIO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hORARIO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_MATERIA = new SelectList(db.MATERIA, "ID_MATERIA", "MAT_COD", hORARIO.ID_MATERIA);
            return View(hORARIO);
        }

        // GET: HORARIOs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HORARIO hORARIO = db.HORARIO.Find(id);
            if (hORARIO == null)
            {
                return HttpNotFound();
            }
            return View(hORARIO);
        }

        // POST: HORARIOs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HORARIO hORARIO = db.HORARIO.Find(id);
            db.HORARIO.Remove(hORARIO);
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
