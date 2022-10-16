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
    public class TIPO_USUARIOController : Controller
    {
        private GatsuGradesv8Entities db = new GatsuGradesv8Entities();

        // GET: TIPO_USUARIO
        public ActionResult Index()
        {
            return View(db.TIPO_USUARIO.ToList());
        }

        // GET: TIPO_USUARIO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPO_USUARIO tIPO_USUARIO = db.TIPO_USUARIO.Find(id);
            if (tIPO_USUARIO == null)
            {
                return HttpNotFound();
            }
            return View(tIPO_USUARIO);
        }

        // GET: TIPO_USUARIO/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TIPO_USUARIO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_TIPOU,TU_DESCRIP")] TIPO_USUARIO tIPO_USUARIO)
        {
            if (ModelState.IsValid)
            {
                db.TIPO_USUARIO.Add(tIPO_USUARIO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tIPO_USUARIO);
        }

        // GET: TIPO_USUARIO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPO_USUARIO tIPO_USUARIO = db.TIPO_USUARIO.Find(id);
            if (tIPO_USUARIO == null)
            {
                return HttpNotFound();
            }
            return View(tIPO_USUARIO);
        }

        // POST: TIPO_USUARIO/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_TIPOU,TU_DESCRIP")] TIPO_USUARIO tIPO_USUARIO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tIPO_USUARIO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tIPO_USUARIO);
        }

        // GET: TIPO_USUARIO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TIPO_USUARIO tIPO_USUARIO = db.TIPO_USUARIO.Find(id);
            if (tIPO_USUARIO == null)
            {
                return HttpNotFound();
            }
            return View(tIPO_USUARIO);
        }

        // POST: TIPO_USUARIO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TIPO_USUARIO tIPO_USUARIO = db.TIPO_USUARIO.Find(id);
            db.TIPO_USUARIO.Remove(tIPO_USUARIO);
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
