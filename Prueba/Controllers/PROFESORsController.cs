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
    public class PROFESORsController : Controller
    {
        private GatsuGradesv6Entities db = new GatsuGradesv6Entities();

        // GET: PROFESORs
        public ActionResult Index()
        {
            var pROFESOR = db.PROFESOR.Include(p => p.TIPO_USUARIO);
            return View(pROFESOR.ToList());
        }

        // GET: PROFESORs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PROFESOR pROFESOR = db.PROFESOR.Find(id);
            if (pROFESOR == null)
            {
                return HttpNotFound();
            }
            return View(pROFESOR);
        }

        // GET: PROFESORs/Create
        public ActionResult Create()
        {
            ViewBag.ID_TIPOU = new SelectList(db.TIPO_USUARIO, "ID_TIPOU", "TU_DESCRIP");
            return View();
        }

        // POST: PROFESORs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_PROFESOR,PROF_USU,ID_TIPOU,PROF_NOMBRE,PROF_APELLIDO,PROF_CEDULA,PROF_DIRECCION,PROF_TELF,PROF_PASSWORD")] PROFESOR pROFESOR)
        {
            if (ModelState.IsValid)
            {
                db.PROFESOR.Add(pROFESOR);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_TIPOU = new SelectList(db.TIPO_USUARIO, "ID_TIPOU", "TU_DESCRIP", pROFESOR.ID_TIPOU);
            return View(pROFESOR);
        }

        // GET: PROFESORs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PROFESOR pROFESOR = db.PROFESOR.Find(id);
            if (pROFESOR == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_TIPOU = new SelectList(db.TIPO_USUARIO, "ID_TIPOU", "TU_DESCRIP", pROFESOR.ID_TIPOU);
            return View(pROFESOR);
        }

        // POST: PROFESORs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_PROFESOR,PROF_USU,ID_TIPOU,PROF_NOMBRE,PROF_APELLIDO,PROF_CEDULA,PROF_DIRECCION,PROF_TELF,PROF_PASSWORD")] PROFESOR pROFESOR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pROFESOR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_TIPOU = new SelectList(db.TIPO_USUARIO, "ID_TIPOU", "TU_DESCRIP", pROFESOR.ID_TIPOU);
            return View(pROFESOR);
        }

        // GET: PROFESORs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PROFESOR pROFESOR = db.PROFESOR.Find(id);
            if (pROFESOR == null)
            {
                return HttpNotFound();
            }
            return View(pROFESOR);
        }

        // POST: PROFESORs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PROFESOR pROFESOR = db.PROFESOR.Find(id);
            db.PROFESOR.Remove(pROFESOR);
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
