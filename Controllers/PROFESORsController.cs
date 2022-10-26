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
        private GatsuGradesv6Entities1 db = new GatsuGradesv6Entities1();
        public static int prof_conectado = 0;
        public static string grad_seleccionado = "";
        public static List<HORARIO> horario_mat_grado = new List<HORARIO>();
        public static List<ESTUDIANTE> est_grado = new List<ESTUDIANTE>();
        public static int horario_seleccionado = 0;
        public static int mat_id = 0;

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
        public ActionResult AsistenciasProf()
        {
            if(horario_mat_grado.Count == 0)
            {
                var dic_Aut = db.HORARIO.ToDictionary(s => s.ID_HORARIO, s => ( s.HOR_DIA + " " +s.HOR_HORA.ToString("HH:mm")) );
                ViewBag.Horario = new SelectList(dic_Aut, "Key", "Value");
                //ViewBag.Horario = new SelectList(db.HORARIO, "ID_HORARIO", "HOR_DIA");
            }
            else
            {
                var dic_Aut = db.HORARIO.Where(hor => hor.ID_MATERIA == mat_id).ToDictionary(s => s.ID_HORARIO, s => (s.HOR_DIA + " " + s.HOR_HORA.ToString("HH:mm")));
                //SelectList horarios = new SelectList(db.HORARIO.Where(hor => hor.ID_MATERIA == mat_id), "ID_HORARIO", "HOR_DIA", horario_mat_grado[0].ID_HORARIO);
                //ViewBag.Horario = horarios;
                ViewBag.Horario = new SelectList(dic_Aut, "Key", "Value");
            }
            //horario_seleccionado = Horario;
            return View();
        }
        //NOE CAMBIOS
        [HttpPost]
        public ActionResult LoginAdmin(string us, string clave)
        {
            List<PROFESOR> prof_temp = new List<PROFESOR>();
            prof_temp = db.PROFESOR.Where(prof => prof.PROF_USU == us && prof.PROF_PASSWORD == clave ).ToList();

            if (prof_temp.Count != 0) //Usuario existe
            {
                prof_conectado = prof_temp[0].ID_PROFESOR;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewData["Mensaje"] = "Usuario no encontrado";
                return View();
            }

        }
        [HttpPost]
        public ActionResult AsistenciasProf(string Grado, string Materia, int Horario)
        {
            grad_seleccionado = Grado;
            List<MATERIA> materias_prof = new List<MATERIA>();
            est_grado = new List<ESTUDIANTE>();


            //Listar Materias que da Profesor
            materias_prof = db.MATERIA.Where(mat => mat.MAT_COD == Materia + Grado && mat.ID_PROFESOR == prof_conectado).ToList();

            if(materias_prof.Count != 0)
            {

                //Listar horarios de la materia seleccionada
                mat_id = materias_prof[0].ID_MATERIA;
                horario_mat_grado = db.HORARIO.Where(hor => hor.ID_MATERIA == mat_id).ToList();


                if (horario_mat_grado.Count != 0)
                {
                    ViewData["Mat"] = "Gestión de Asistencias " + materias_prof[0].MAT_NOMBRE + " " +Grado +  " EGB";
                    AsistenciasProf();
                    //SelectList horarios = new SelectList(db.HORARIO.Where(hor => hor.ID_MATERIA == mat_id), "ID_HORARIO", "HOR_DIA", horario_mat_grado[0].ID_HORARIO);
                    //Listar combo box con dia y hora del horario
                    //ViewBag.Horario = horarios;
                    //Almacena el valor de horario seleccionado
                    horario_seleccionado = Horario;
                    //Listar estudiantes del grado seleccionado - De acuerdo al ultimo caracter del nombre de ususario Estudiante
                    est_grado = db.ESTUDIANTE.Where(est => est.EST_USU.Substring(est.EST_USU.Length - 1, 1) == Grado).ToList();


                    if (est_grado.Count != 0)
                    {
                        //Colocar una tabla de estudiantes y bool asistencia, de acuerdo al horario filtrado
                        return View(est_grado);
                    }
                }
                else
                {
                    //ViewBag.Horario = new SelectList(db.HORARIO.Where(hor => hor.ID_MATERIA == 0), "ID_HORARIO", "HOR_DIA");
                    ViewBag.Alert = "La Materia " + materias_prof[0].MAT_NOMBRE + " no tiene un horario asignado en " + Grado + " EGB";
                    AsistenciasProf();
                }

            }
            else
            {
                //ViewBag.Horario = new SelectList(db.HORARIO.Where(hor => hor.ID_MATERIA == 0), "ID_HORARIO", "HOR_DIA");
                ViewBag.Alert = "El profesor seleccionado no dicta la materia ";
                AsistenciasProf();
            }
            return View();
        }

        //Carga de datos
        public List<string> Validar(List<ASISTENCIA> asis_val_aux)
        {
            List<string> datos_conf = new List<string>();
            string aux = "";
            for (int i = 0; i < asis_val_aux.Count; i++)
            {
                if (asis_val_aux[i].ASIS_CONF == "SI")
                {
                    aux = "true";
                }
                else{
                    aux = "false";
                }
                datos_conf.Add(aux);
            }
            return datos_conf;
        }


        //CREAR ASISTENCIA
        [HttpPost]
        public ActionResult CrearAsistencia(DateTime fecha, string[] asis)
        {
            DateTime fechaaux = fecha;
            String[] conf = asis;
            List<ASISTENCIA> asis_val_aux = new List<ASISTENCIA>();
            string aux_conf = "";

            int day = fechaaux.Day; // Obtiene el día de una variable DateTime.3



            //Validaciones....
            for (int i = 0; i < est_grado.Count; i++)
            {
                if (conf[i] == "false")
                {
                    aux_conf = "NO";
                }
                else
                {
                    aux_conf = "SI";
                }
                //Valido que no existan asistencias ingresadas
                int id_aux = est_grado[i].ID_ESTUDIANTE;
                List<ASISTENCIA> asis_val = new List<ASISTENCIA>();
                asis_val = db.ASISTENCIA.Where(asis_validar => asis_validar.ID_ESTUDIANTE == id_aux
                && asis_validar.ASIS_FECHA == fechaaux && asis_validar.ID_HORARIO == horario_seleccionado ).ToList();

                if(asis_val.Count != 0)
                {
                    asis_val_aux.Add(asis_val[0]);
                }
            }

            //Ya existen asistencias en esa fecha, hora, dia
            if(asis_val_aux.Count == est_grado.Count)
            {
                //LLAMAR AL METODO
                ViewData["Res"] = "Ya existen asistencias registradas de los estudiantes en la fecha seleccionada";
            }
            else //Crea asistencias 
            {

                 for (int i = 0; i < est_grado.Count; i++)
                 {
                     //Creo objeto asistencia
                     ASISTENCIA asis_est = new ASISTENCIA();
                     //Id Horario
                     asis_est.ID_HORARIO = horario_seleccionado;
                     //Fecha
                     asis_est.ASIS_FECHA = fechaaux;
                     //Conf
                     if (conf[i] == "false")
                     {
                         asis_est.ASIS_CONF = "NO";
                     }
                     else
                     {
                         asis_est.ASIS_CONF = "SI";
                     }
                     //Est
                     asis_est.ID_ESTUDIANTE = est_grado[i].ID_ESTUDIANTE;

                     //Creo asistencia
                     db.ASISTENCIA.Add(asis_est);
                     db.SaveChanges();
                     ViewData["Res"] = "Registro ingresado";
                 }
            }
            SelectList horarios = new SelectList(db.HORARIO.Where(hor => hor.ID_MATERIA == mat_id), "ID_HORARIO", "HOR_DIA", horario_mat_grado[0].ID_HORARIO);
            //Listar combo box con dia y hora del horario
            ViewBag.Horario = horarios;
            return View("AsistenciasProf", est_grado);
        }

         // GET: PROFESORs/Details/5
        public ActionResult Details(int? id){
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
