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
    public class MATERIAsController : Controller
    {
        private GatsuGradesv6Entities1 db = new GatsuGradesv6Entities1();

        // GET: MATERIAs
        public ActionResult Index()
        {
            var mATERIA = db.MATERIA.Include(m => m.PROFESOR);
            return View(mATERIA.ToList());
        }
        

        // GET: MATERIAs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MATERIA mATERIA = db.MATERIA.Find(id);
            if (mATERIA == null)
            {
                return HttpNotFound();
            }
            return View(mATERIA);
        }

        // GET: MATERIAs/Create
        public ActionResult Create()
        {
            ViewBag.ID_PROFESOR = new SelectList(db.PROFESOR, "ID_PROFESOR", "PROF_USU");
            return View();
        }

        // POST: MATERIAs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_MATERIA,MAT_COD,ID_PROFESOR,MAT_NOMBRE,MAT_GRADO,MAT_PARALELO")] MATERIA mATERIA)
        {
            if (ModelState.IsValid)
            {
                db.MATERIA.Add(mATERIA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_PROFESOR = new SelectList(db.PROFESOR, "ID_PROFESOR", "PROF_USU", mATERIA.ID_PROFESOR);
            return View(mATERIA);
        }

        // GET: MATERIAs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MATERIA mATERIA = db.MATERIA.Find(id);
            if (mATERIA == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_PROFESOR = new SelectList(db.PROFESOR, "ID_PROFESOR", "PROF_USU", mATERIA.ID_PROFESOR);
            return View(mATERIA);
        }

        // POST: MATERIAs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_MATERIA,MAT_COD,ID_PROFESOR,MAT_NOMBRE,MAT_GRADO,MAT_PARALELO")] MATERIA mATERIA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mATERIA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_PROFESOR = new SelectList(db.PROFESOR, "ID_PROFESOR", "PROF_USU", mATERIA.ID_PROFESOR);
            return View(mATERIA);
        }

        // GET: MATERIAs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MATERIA mATERIA = db.MATERIA.Find(id);
            if (mATERIA == null)
            {
                return HttpNotFound();
            }
            return View(mATERIA);
        }

        // POST: MATERIAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MATERIA mATERIA = db.MATERIA.Find(id);
            db.MATERIA.Remove(mATERIA);
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
