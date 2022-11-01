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
        #region validar cedula
        private string validar(string cedula)
        {
            string result = "";

            //Preguntamos si la cedula consta de 10 digitos
            if (cedula == null)
            {
                result = "incorrecta";
            }
            if (cedula.Length == 10)
            {

                //Obtenemos el digito de la region que sonlos dos primeros digitos
                int digito_region = int.Parse(cedula.Substring(0, 2));

                //Pregunto si la region existe ecuador se divide en 24 regiones
                if (digito_region >= 1 && digito_region <= 24)
                {

                    // Extraigo el ultimo digito
                    string ultimo_digito = cedula.Substring(9);

                    //Agrupo todos los pares y los sumo
                    int par1 = 0, par2 = 0, par3 = 0, par4 = 0, par5 = 0;
                    int impar1 = 0, impar2 = 0, impar3 = 0, impar4 = 0, impar5 = 0;


                    par1 = int.Parse(cedula.Substring(1, 1));
                    par2 = int.Parse(cedula.Substring(3, 1));
                    par3 = int.Parse(cedula.Substring(5, 1));
                    par4 = int.Parse(cedula.Substring(7, 1));

                    int pares = par1 + par2 + par3 + par4;

                    //Agrupo los impares, los multiplico por un factor de 2, si la resultante es > que 9 le restamos el 9 a la resultante
                    impar1 = int.Parse(cedula.Substring(0, 1)) * 2;
                    if (impar1 > 9) { impar1 = (impar1 - 9); }

                    impar2 = int.Parse(cedula.Substring(2, 1)) * 2;
                    if (impar2 > 9) { impar2 = (impar2 - 9); }

                    impar3 = int.Parse(cedula.Substring(4, 1)) * 2;
                    if (impar3 > 9) { impar3 = (impar3 - 9); }

                    impar4 = int.Parse(cedula.Substring(6, 1)) * 2;
                    if (impar4 > 9) { impar4 = (impar4 - 9); }

                    impar5 = int.Parse(cedula.Substring(8, 1)) * 2;
                    if (impar5 > 9) { impar5 = (impar5 - 9); }

                    int impares = impar1 + impar2 + impar3 + impar4 + impar5;

                    //Suma total
                    int suma_total = (pares + impares);

                    //extraemos el primero digito
                    string primer_digito_suma = (suma_total).ToString().Substring(0, 1);

                    //Obtenemos la decena inmediata
                    int decena = (int.Parse(primer_digito_suma) + 1) * 10;

                    //Obtenemos la resta de la decena inmediata - la suma_total esto nos da el digito validador
                    int digito_validador = decena - suma_total;

                    //Si el digito validador es = a 10 toma el valor de 0
                    if (digito_validador == 10)
                        digito_validador = 0;

                    //Validamos que el digito validador sea igual al de la cedula
                    if (digito_validador == int.Parse(ultimo_digito))
                    {
                        result = ("correcto");
                    }
                    else
                    {
                        result = ("la cédula:" + cedula + "es incorrecta");
                    }

                }
                else
                {
                    // imprimimos en consola si la region no pertenece
                    result = ("Esta cédula no pertenece a ninguna region");
                }
            }
            else if (cedula.Length > 10)
            {
                //imprimimos en consola si la cedula tiene mas o menos de 10 digitos
                result = ("Esta cédula tiene más de 10 dígitos");
            }
            else
            {
                //imprimimos en consola si la cedula tiene mas o menos de 10 digitos
                result = ("Esta cédula tiene menos de 10 dígitos");
            }
            return result;
        }
        #endregion
        private GatsuGradesv8Entities db = new GatsuGradesv8Entities();
        public static int usu = 0;
        public static string cel = "";

        // GET: PROFESORs
        public ActionResult Index()
        {
            var pROFESOR = db.PROFESOR.Include(p => p.TIPO_USUARIO);
            return View(pROFESOR.ToList());
        }
        public ActionResult LoginAdmin()
        {
            return View();
        }
        //NOE CAMBIOS
        [HttpPost]
        public ActionResult LoginAdmin(string us, string clave)
        {
            List<PROFESOR> prof_temp = new List<PROFESOR>();
            prof_temp = db.PROFESOR.Where(prof => prof.PROF_USU == us && prof.PROF_PASSWORD == clave && prof.ID_TIPOU==4).ToList();

            if (prof_temp.Count != 0) //Usuario existe
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewData["Mensaje"] = "Usuario no encontrado";
                return View();
            }

        }
        public ActionResult HomeProfesores()
        {
            PROFESOR prof = db.PROFESOR.Find(usu);
            //ViewData["nombre"] = "Bienvenido/a " + prof.PROF_NOMBRE.ToString() + " " + prof.PROF_APELLIDO.ToString();
            return View();
        }
        public ActionResult LoginProf()
        {
            
            return View();
        }
        
        //NOE CAMBIOS
        [HttpPost]
        public ActionResult LoginProf(string us, string clave)
        {
            List<PROFESOR> prof_temp = new List<PROFESOR>();
            prof_temp = db.PROFESOR.Where(prof => prof.PROF_USU == us && prof.PROF_PASSWORD == clave).ToList();
            

            if (prof_temp.Count != 0) //Usuario existe
            {
                usu = prof_temp.First().ID_PROFESOR;
                return RedirectToAction("HomeProfesores", "PROFESORs");
            }
            else
            {
                ViewData["Mensaje"] = "Usuario no encontrado/Contraseña Incorrecta";
                return View();
            }

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
            ViewBag.ID_TIPOU = new SelectList(db.TIPO_USUARIO, "ID_TIPOU", "TU_DESCRIP", 2);
            return View();
        }

        // POST: PROFESORs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_PROFESOR,PROF_USU,ID_TIPOU,PROF_NOMBRE,PROF_APELLIDO,PROF_CEDULA,PROF_DIRECCION,PROF_TELF,PROF_PASSWORD")] PROFESOR pROFESOR)
        {
            List<PROFESOR> usu=db.PROFESOR.Where(pr=>pr.PROF_USU ==pROFESOR.PROF_USU).ToList();
            List<PROFESOR> na = db.PROFESOR.Where(pr => pr.PROF_NOMBRE == pROFESOR.PROF_NOMBRE && pr.PROF_APELLIDO==pROFESOR.PROF_APELLIDO).ToList();
            List<PROFESOR> ce = db.PROFESOR.Where(pr => pr.PROF_CEDULA == pROFESOR.PROF_CEDULA).ToList();
            List<ESTUDIANTE> est = db.ESTUDIANTE.Where(estu => estu.EST_USU == pROFESOR.PROF_USU).ToList();
            List<REPRESENTANTE> reps = db.REPRESENTANTE.Where(rep => rep.REP_USU == pROFESOR.PROF_USU).ToList();

            cel = validar(pROFESOR.PROF_CEDULA);
            if (ModelState.IsValid && usu.Count==0 && na.Count==0 && ce.Count==0 && est.Count==0 && reps.Count==0 && cel == "correcto")
            {
                pROFESOR.ID_TIPOU = 2;
                db.PROFESOR.Add(pROFESOR);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["Val"] = "Existen campos coincidentes con otro usuario";
            ViewBag.ID_TIPOU = new SelectList(db.TIPO_USUARIO, "ID_TIPOU", "TU_DESCRIP", 2);
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
            ViewBag.ID_TIPOU = new SelectList(db.TIPO_USUARIO, "ID_TIPOU", "TU_DESCRIP", 2);
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
            ViewBag.ID_TIPOU = new SelectList(db.TIPO_USUARIO, "ID_TIPOU", "TU_DESCRIP", 2);
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
