using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Prueba;
using Rotativa;

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
            List<TIPO_USUARIO> usuarios = db.TIPO_USUARIO.ToList();
            tIPO_USUARIO.ID_TIPOU= usuarios.Last().ID_TIPOU + 1;
            List <TIPO_USUARIO> usu = db.TIPO_USUARIO.Where(us => us.ID_TIPOU == tIPO_USUARIO.ID_TIPOU || us.TU_DESCRIP== tIPO_USUARIO.TU_DESCRIP).ToList();
            if (ModelState.IsValid && usu.Count==0)
            {
                db.TIPO_USUARIO.Add(tIPO_USUARIO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["Val"] = "No puede ingresar un usuario con el mismo id de rol o descripción";
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
            List<TIPO_USUARIO> usu = db.TIPO_USUARIO.Where(us=> us.TU_DESCRIP == tIPO_USUARIO.TU_DESCRIP).ToList();
            if (ModelState.IsValid && usu.Count==0)
            {
                db.Entry(tIPO_USUARIO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["Val"] = "Ingrese otra descripción de usuario";
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
            List<ESTUDIANTE> lstest = db.ESTUDIANTE.Where(est => est.ID_TIPOU==id).ToList();
            List<PROFESOR> lstprof = db.PROFESOR.Where(pr => pr.ID_TIPOU == id).ToList();
            List<REPRESENTANTE> lsrep = db.REPRESENTANTE.Where(rep => rep.ID_TIPOU == id).ToList();
            if(lstest.Count ==0 && lstprof.Count ==0 && lsrep.Count == 0)
            {
                db.TIPO_USUARIO.Remove(tIPO_USUARIO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Alert = "No puede borrar un registro con dependencias";
            return View(tIPO_USUARIO);
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
