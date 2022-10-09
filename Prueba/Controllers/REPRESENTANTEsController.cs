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
    public class REPRESENTANTEsController : Controller
    {
        private GatsuGradesv6Entities db = new GatsuGradesv6Entities();

        // GET: REPRESENTANTEs
        public ActionResult Index()
        {
            var rEPRESENTANTE = db.REPRESENTANTE.Include(r => r.TIPO_USUARIO);
            return View(rEPRESENTANTE.ToList());
        }

        // GET: REPRESENTANTEs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            REPRESENTANTE rEPRESENTANTE = db.REPRESENTANTE.Find(id);
            if (rEPRESENTANTE == null)
            {
                return HttpNotFound();
            }
            return View(rEPRESENTANTE);
        }

        // GET: REPRESENTANTEs/Create
        public ActionResult Create()
        {
            ViewBag.ID_TIPOU = new SelectList(db.TIPO_USUARIO, "ID_TIPOU", "TU_DESCRIP");
            return View();
        }

        // POST: REPRESENTANTEs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_REP,REP_USU,ID_TIPOU,REP_NOMBRE,REP_APELLIDO,REP_CEDULA,REP_DIRECCION,REP_TELEFONO,REP_PASSWORD")] REPRESENTANTE rEPRESENTANTE)
        {
            if (ModelState.IsValid)
            {
                db.REPRESENTANTE.Add(rEPRESENTANTE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_TIPOU = new SelectList(db.TIPO_USUARIO, "ID_TIPOU", "TU_DESCRIP", rEPRESENTANTE.ID_TIPOU);
            return View(rEPRESENTANTE);
        }

        // GET: REPRESENTANTEs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            REPRESENTANTE rEPRESENTANTE = db.REPRESENTANTE.Find(id);
            if (rEPRESENTANTE == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_TIPOU = new SelectList(db.TIPO_USUARIO, "ID_TIPOU", "TU_DESCRIP", rEPRESENTANTE.ID_TIPOU);
            return View(rEPRESENTANTE);
        }

        // POST: REPRESENTANTEs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_REP,REP_USU,ID_TIPOU,REP_NOMBRE,REP_APELLIDO,REP_CEDULA,REP_DIRECCION,REP_TELEFONO,REP_PASSWORD")] REPRESENTANTE rEPRESENTANTE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rEPRESENTANTE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_TIPOU = new SelectList(db.TIPO_USUARIO, "ID_TIPOU", "TU_DESCRIP", rEPRESENTANTE.ID_TIPOU);
            return View(rEPRESENTANTE);
        }

        // GET: REPRESENTANTEs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            REPRESENTANTE rEPRESENTANTE = db.REPRESENTANTE.Find(id);
            if (rEPRESENTANTE == null)
            {
                return HttpNotFound();
            }
            return View(rEPRESENTANTE);
        }

        // POST: REPRESENTANTEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            REPRESENTANTE rEPRESENTANTE = db.REPRESENTANTE.Find(id);
            db.REPRESENTANTE.Remove(rEPRESENTANTE);
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
