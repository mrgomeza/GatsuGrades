using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Web.UI;
using Prueba;
using Rotativa;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;

namespace Prueba.Controllers
{
    public class ESTUDIANTEsController : Controller
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
        public static string cel = "";
        public static int usu = 0;
        public static List<reporteNotaEst> repNota = null;
        public ActionResult Login()
        {
            return View();
        }

        

        public ActionResult NotasEst()
        {

            ESTUDIANTE estu = db.ESTUDIANTE.Find(usu);
            ViewData["nombre"] =  estu.EST_NOMBRE.ToString() + " " + estu.EST_APELLIDO.ToString();

            ESTUDIANTE est = new ESTUDIANTE(); 
            est = db.ESTUDIANTE.Find(usu);
            string est_grado = est.EST_USU.Substring(est.EST_USU.Length - 1, 1);

            List<MATERIA> materias = new List<MATERIA>();
            materias =  db.MATERIA.Where(ma => ma.MAT_GRADO == est_grado).ToList();

            NOTA nAux = new NOTA();
            repNota = new List<reporteNotaEst>();


            for (int i = 0; i < materias.Count; i++)
            {
                nAux = db.NOTA.Find(materias[i].ID_MATERIA);

                reporteNotaEst auxNota = new reporteNotaEst();

                auxNota.MAT_NOMBRE = materias[i].MAT_NOMBRE; 
                auxNota.NP1 = nAux.NP1;
                auxNota.NP2 = nAux.NP2;
                auxNota.EQ1 = nAux.EQ1;
                auxNota.Q1 = nAux.Q1;
                auxNota.NP3 = nAux.NP3;
                auxNota.NP4 = nAux.NP4;
                auxNota.EQ2 = nAux.EQ2;
                auxNota.Q2 = nAux.Q2;

                auxNota.FINAL = nAux.FINAL;

                repNota.Add(auxNota);
            }


            return View(repNota);


        }







        public ActionResult HomeEstudiante()
        {
            ESTUDIANTE est = db.ESTUDIANTE.Find(usu);
            ViewData["nombre"] = "Bienvenido/a " + est.EST_NOMBRE.ToString() + " " + est.EST_APELLIDO.ToString();
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
            ViewBag.ID_REP = new SelectList(db.REPRESENTANTE, "ID_REP", "REP_NOMBRE","REP_APELLIDO");
            ViewBag.ID_TIPOU = new SelectList(db.TIPO_USUARIO, "ID_TIPOU", "TU_DESCRIP", 1);
            return View();
        }

        // POST: ESTUDIANTEs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_ESTUDIANTE,EST_USU,ID_REP,ID_TIPOU,EST_NOMBRE,EST_APELLIDO,EST_CEDULA,EST_FECHANAC,EST_PASSWORD")] ESTUDIANTE eSTUDIANTE)
        {
            List<ESTUDIANTE> usu = db.ESTUDIANTE.Where(es => es.EST_USU == eSTUDIANTE.EST_USU).ToList();
            List<ESTUDIANTE> na = db.ESTUDIANTE.Where(es => es.EST_NOMBRE == eSTUDIANTE.EST_NOMBRE && es.EST_APELLIDO == eSTUDIANTE.EST_APELLIDO).ToList();
            List<ESTUDIANTE> ce = db.ESTUDIANTE.Where(es => es.EST_CEDULA == eSTUDIANTE.EST_CEDULA).ToList();
            List<PROFESOR> prof = db.PROFESOR.Where(pr => pr.PROF_USU == eSTUDIANTE.EST_USU).ToList();
            List<REPRESENTANTE> reps = db.REPRESENTANTE.Where(rep => rep.REP_USU == eSTUDIANTE.EST_USU).ToList();
            cel = validar(eSTUDIANTE.EST_CEDULA);

            if (ModelState.IsValid &&usu.Count == 0 && na.Count == 0 && ce.Count == 0 && prof.Count == 0 && reps.Count == 0 && cel == "correcto")
            {
                eSTUDIANTE.ID_TIPOU = 1;
                db.ESTUDIANTE.Add(eSTUDIANTE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewData["Val"] = "Existen campos coincidentes con otro usuario";
            ViewBag.ID_REP = new SelectList(db.REPRESENTANTE, "ID_REP", "REP_USU", eSTUDIANTE.ID_REP);
            ViewBag.ID_TIPOU = new SelectList(db.TIPO_USUARIO, "ID_TIPOU", "TU_DESCRIP", 1);
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
                usu = est_temp.First().ID_ESTUDIANTE;
                return RedirectToAction("HomeEstudiante", "ESTUDIANTEs");
            }
            else
            {
                ViewData["Mensaje"] = "Usuario no encontrado/Contraseña Incorrecta";
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
            ViewBag.ID_TIPOU = new SelectList(db.TIPO_USUARIO, "ID_TIPOU", "TU_DESCRIP", 1);
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
            ViewBag.ID_TIPOU = new SelectList(db.TIPO_USUARIO, "ID_TIPOU", "TU_DESCRIP", 1);
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
            List<NOTA> lstnot=db.NOTA.Where(not=>not.ID_ESTUDIANTE==id).ToList();
            List<ASISTENCIA> lstasis = db.ASISTENCIA.Where(not => not.ID_ESTUDIANTE == id).ToList();
            if(lstnot.Count==0 && lstasis.Count == 0)
            {
                db.ESTUDIANTE.Remove(eSTUDIANTE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Alert = "No puede borrar un registro con dependencias";
            return View(eSTUDIANTE);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        public void ExportContentToXls()
        {
            var gv = new GridView
            {
                DataSource = repNota
            };
            gv.DataBind();

            Response.ClearContent();
            Response.AddHeader("content-disposition",
                                String.Format("attachment;filename=Notas_{0}.xlsx", DateTime.Now));
            Response.ContentType = "application/excel";

            var strw = new StringWriter();
            var htmlTw = new HtmlTextWriter(strw);

            gv.RenderControl(htmlTw);
            Response.Write(strw.ToString());
            Response.End();
        }

        public ActionResult ExportContentToPdf()
        {
            string nArchivo = String.Format("Notas_{0}.pdf", DateTime.Now);
            return new ActionAsPdf("NotasEst", new { nombre = "NotasGlobal" }) { FileName = nArchivo };
        }



    }
}
