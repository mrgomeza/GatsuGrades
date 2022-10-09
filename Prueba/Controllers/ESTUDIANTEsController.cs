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
    public class ESTUDIANTEsController : Controller
    {
        private GatsuGradesv6Entities db = new GatsuGradesv6Entities();
        public ActionResult Login()
        {
            return View();
        }

        // GET: ESTUDIANTEs
        public ActionResult Index()
        {
            var eSTUDIANTE = db.ESTUDIANTE.Include(e => e.REPRESENTANTE).Include(e => e.TIPO_USUARIO);
            return View(eSTUDIANTE.ToList());
        }

        // GET: ESTUDIANTEs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ESTUDIANTE eSTUDIANTE = db.ESTUDIANTE.Find(id);
            if (eSTUDIANTE == null)
            {
                return HttpNotFound();
            }
            return View(eSTUDIANTE);
        }

        // GET: ESTUDIANTEs/Create
        public ActionResult Create()
        {
            ViewBag.ID_REP = new SelectList(db.REPRESENTANTE, "ID_REP", "REP_USU");
            ViewBag.ID_TIPOU = new SelectList(db.TIPO_USUARIO, "ID_TIPOU", "TU_DESCRIP");
            return View();
        }

        // POST: ESTUDIANTEs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_ESTUDIANTE,EST_USU,ID_REP,ID_TIPOU,EST_NOMBRE,EST_APELLIDO,EST_CEDULA,EST_FECHANAC,EST_PASSWORD")] ESTUDIANTE eSTUDIANTE)
        {
            if (ModelState.IsValid)
            {
                db.ESTUDIANTE.Add(eSTUDIANTE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_REP = new SelectList(db.REPRESENTANTE, "ID_REP", "REP_USU", eSTUDIANTE.ID_REP);
            ViewBag.ID_TIPOU = new SelectList(db.TIPO_USUARIO, "ID_TIPOU", "TU_DESCRIP", eSTUDIANTE.ID_TIPOU);
            return View(eSTUDIANTE);
        }

        //NOE CAMBIOS
        [HttpPost]
        public ActionResult Login(string us, string clave)
        {
            List<ESTUDIANTE> est_temp = new List<ESTUDIANTE>();
            est_temp = db.ESTUDIANTE.Where(est => est.EST_USU == us && est.EST_PASSWORD == clave).ToList();

            if(est_temp.Count != 0) //Usuario existe
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewData["Mensaje"] = "Usuario no encontrado";
                return View();
            }

        }

        // GET: ESTUDIANTEs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ESTUDIANTE eSTUDIANTE = db.ESTUDIANTE.Find(id);
            if (eSTUDIANTE == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_REP = new SelectList(db.REPRESENTANTE, "ID_REP", "REP_USU", eSTUDIANTE.ID_REP);
            ViewBag.ID_TIPOU = new SelectList(db.TIPO_USUARIO, "ID_TIPOU", "TU_DESCRIP", eSTUDIANTE.ID_TIPOU);
            return View(eSTUDIANTE);
        }

        // POST: ESTUDIANTEs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_ESTUDIANTE,EST_USU,ID_REP,ID_TIPOU,EST_NOMBRE,EST_APELLIDO,EST_CEDULA,EST_FECHANAC,EST_PASSWORD")] ESTUDIANTE eSTUDIANTE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eSTUDIANTE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_REP = new SelectList(db.REPRESENTANTE, "ID_REP", "REP_USU", eSTUDIANTE.ID_REP);
            ViewBag.ID_TIPOU = new SelectList(db.TIPO_USUARIO, "ID_TIPOU", "TU_DESCRIP", eSTUDIANTE.ID_TIPOU);
            return View(eSTUDIANTE);
        }

        // GET: ESTUDIANTEs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ESTUDIANTE eSTUDIANTE = db.ESTUDIANTE.Find(id);
            if (eSTUDIANTE == null)
            {
                return HttpNotFound();
            }
            return View(eSTUDIANTE);
        }

        // POST: ESTUDIANTEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ESTUDIANTE eSTUDIANTE = db.ESTUDIANTE.Find(id);
            db.ESTUDIANTE.Remove(eSTUDIANTE);
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
