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
    public class ANO_LECTIVOController : Controller
    {
        private GatsuGradesv6Entities db = new GatsuGradesv6Entities();

        // GET: ANO_LECTIVO
        public ActionResult Index()
        {
            return View(db.ANO_LECTIVO.ToList());
        }

        // GET: ANO_LECTIVO/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ANO_LECTIVO aNO_LECTIVO = db.ANO_LECTIVO.Find(id);
            if (aNO_LECTIVO == null)
            {
                return HttpNotFound();
            }
            return View(aNO_LECTIVO);
        }

        // GET: ANO_LECTIVO/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ANO_LECTIVO/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_ANO,ANO_DESCRIP")] ANO_LECTIVO aNO_LECTIVO)
        {
            if (ModelState.IsValid)
            {
                db.ANO_LECTIVO.Add(aNO_LECTIVO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aNO_LECTIVO);
        }

        // GET: ANO_LECTIVO/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ANO_LECTIVO aNO_LECTIVO = db.ANO_LECTIVO.Find(id);
            if (aNO_LECTIVO == null)
            {
                return HttpNotFound();
            }
            return View(aNO_LECTIVO);
        }

        // POST: ANO_LECTIVO/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_ANO,ANO_DESCRIP")] ANO_LECTIVO aNO_LECTIVO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aNO_LECTIVO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aNO_LECTIVO);
        }

        // GET: ANO_LECTIVO/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ANO_LECTIVO aNO_LECTIVO = db.ANO_LECTIVO.Find(id);
            if (aNO_LECTIVO == null)
            {
                return HttpNotFound();
            }
            return View(aNO_LECTIVO);
        }

        // POST: ANO_LECTIVO/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ANO_LECTIVO aNO_LECTIVO = db.ANO_LECTIVO.Find(id);
            db.ANO_LECTIVO.Remove(aNO_LECTIVO);
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
