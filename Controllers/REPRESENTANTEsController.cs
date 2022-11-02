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
        public ActionResult HomeRepresentantes()
        {
            REPRESENTANTE rep = db.REPRESENTANTE.Find(usu);
            ViewData["nombre"] = "Bienvenido/a " + rep.REP_NOMBRE.ToString() + " " + rep.REP_APELLIDO.ToString();
            return View();
        }
        public ActionResult LoginRep()
        {

            return View();
        }

        //NOE CAMBIOS
        [HttpPost]
        public ActionResult LoginRep(string us, string clave)
        {
            List<REPRESENTANTE> rep_temp = new List<REPRESENTANTE>();
            rep_temp = db.REPRESENTANTE.Where(rep => rep.REP_USU == us && rep.REP_PASSWORD == clave).ToList();


            if (rep_temp.Count != 0) //Usuario existe
            {
                usu = rep_temp.First().ID_REP;
                return RedirectToAction("HomeRepresentantes", "REPRESENTANTEs");
            }
            else
            {
                ViewData["Mensaje"] = "Usuario no encontrado/Contraseña Incorrecta";
                return View();
            }

        }
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
            ViewBag.ID_TIPOU = new SelectList(db.TIPO_USUARIO, "ID_TIPOU", "TU_DESCRIP", 3);
            return View();
        }

        // POST: REPRESENTANTEs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_REP,REP_USU,ID_TIPOU,REP_NOMBRE,REP_APELLIDO,REP_CEDULA,REP_DIRECCION,REP_TELEFONO,REP_PASSWORD")] REPRESENTANTE rEPRESENTANTE)
        {
            List<REPRESENTANTE> usu = db.REPRESENTANTE.Where(rp => rp.REP_USU == rEPRESENTANTE.REP_USU).ToList();
            List<REPRESENTANTE> na = db.REPRESENTANTE.Where(rp => rp.REP_NOMBRE == rEPRESENTANTE.REP_NOMBRE && rp.REP_APELLIDO == rEPRESENTANTE.REP_APELLIDO).ToList();
            List<REPRESENTANTE> ce = db.REPRESENTANTE.Where(rp => rp.REP_CEDULA == rEPRESENTANTE.REP_CEDULA).ToList();
            List<ESTUDIANTE> est = db.ESTUDIANTE.Where(estu => estu.EST_USU == rEPRESENTANTE.REP_USU).ToList();
            List<PROFESOR> prof = db.PROFESOR.Where(pr => pr.PROF_USU == rEPRESENTANTE.REP_USU).ToList();

            cel = validar(rEPRESENTANTE.REP_CEDULA);
            if (ModelState.IsValid && usu.Count == 0 && na.Count == 0 && ce.Count == 0 && est.Count == 0 && prof.Count == 0 && cel == "correcto")
            {
                rEPRESENTANTE.ID_TIPOU = 3;
                db.REPRESENTANTE.Add(rEPRESENTANTE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["Val"] = "Existen campos coincidentes con otro usuario";
            ViewBag.ID_TIPOU = new SelectList(db.TIPO_USUARIO, "ID_TIPOU", "TU_DESCRIP", 3);
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
            ViewBag.ID_TIPOU = new SelectList(db.TIPO_USUARIO, "ID_TIPOU", "TU_DESCRIP", 3);
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
            ViewBag.ID_TIPOU = new SelectList(db.TIPO_USUARIO, "ID_TIPOU", "TU_DESCRIP", 3);
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
            List<ESTUDIANTE> lstest=db.ESTUDIANTE.Where(est=>est.ID_REP==id).ToList();
            REPRESENTANTE rEPRESENTANTE = db.REPRESENTANTE.Find(id);
            if (lstest.Count() == 0)
            {
                db.REPRESENTANTE.Remove(rEPRESENTANTE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Alert = "No puede borrar un registro con dependencias";
            return View(rEPRESENTANTE);

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
