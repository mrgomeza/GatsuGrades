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
    public class PROFESORsController : Controller
    {
        private GatsuGradesv8Entities db = new GatsuGradesv8Entities();
        public static int prof_conectado = 0;
        public static string grad_seleccionado = "";
        public static string mat_seleccionado = "";
        public static List<HORARIO> horario_mat_grado = new List<HORARIO>();
        public static List<ESTUDIANTE> est_grado = new List<ESTUDIANTE>();
        public static string horario_seleccionado = "";
        public static int mat_id = 0;
        public static int usu = 0;
        public static string cel = "";
        public static int idtemp = 0;
        public static string mats = "";
        public static string grads = "";
        public static MATGRAD model2 = new MATGRAD();
        public static List <NotasModel> model= new List<NotasModel>();
        public static List<NotasModel> modelaux = new List<NotasModel>();
        public static List<Modelos.Asistencia> modelo_asis = new List<Modelos.Asistencia>();

        // GET: PROFESORs
        public ActionResult Index()
        {
            var pROFESOR = db.PROFESOR.Include(p => p.TIPO_USUARIO);
            return View(pROFESOR.ToList());
        }

        #region Notas
        public ActionResult NotasProf()
        {
            List<string> lst1 = db.MATERIA.Where(mat => mat.ID_PROFESOR == prof_conectado).Select(mat => mat.MAT_NOMBRE).Distinct().ToList();

            List<SelectListItem> lst = new List<SelectListItem>();
            List<SelectListItem> lst2 = new List<SelectListItem>();

            lst.Add(new SelectListItem() { Text = "Seleccionar", Value = "All" });
            lst2.Add(new SelectListItem() { Text = "Seleccionar", Value = "All" });

            for (int i = 0; i < lst1.Count; i++)
            {
                lst.Add(new SelectListItem() { Text = lst1[i], Value = lst1[i] });
            }

            ViewBag.ID_MATERIA = lst;
            ViewBag.CB_GRADO = lst2;
            return View();
        }

        public ActionResult EditNota(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NOTA not = db.NOTA.Find(id);
            if (not == null)
            {
                return HttpNotFound();
            }
            ESTUDIANTE est = db.ESTUDIANTE.Find(not.ID_ESTUDIANTE);
            ViewData["est"] = "Estudiante: " + est.EST_NOMBRE.ToString() + " " + est.EST_APELLIDO.ToString();
            return View(not);
        }
        [HttpPost]
        public ActionResult EditNota([Bind(Include = "ID_NOTA,ID_ESTUDIANTE,NP1,NP2,EQ1,NP3,NP4,EQ2")] NOTA not)
        {
            
            List<NotasModel> model2 = new List<NotasModel>();
            if (ModelState.IsValid)
            {
                NOTA nota_temp = db.NOTA.Find(not.ID_NOTA);

                nota_temp.NP1 = not.NP1;
                nota_temp.NP2 = not.NP2;
                nota_temp.EQ1 = not.EQ1;
                nota_temp.NP3 = not.NP3;
                nota_temp.NP4 = not.NP4;
                nota_temp.EQ2 = not.EQ2;

                float np1 = (float)not.NP1;
                float np2 = (float)not.NP2;
                float eq1 = (float)not.EQ1;
                float np3 = (float)not.NP3;
                float np4 = (float)not.NP4;
                float eq2 = (float)not.EQ2;
                float tot1 = 0; float tot2 = 0; float fin = 0;

                if (not.NP1 != 0 && not.NP2 != 0 && not.EQ1 != 0)
                {
                    tot1 = (float)CalcularPromedioParcial(np1, np2, eq1);
                    nota_temp.Q1 = tot1;
                }
                if (not.NP4 != 0 && not.NP5 != 0 && not.EQ2 != 0)
                {
                    tot2 = (float)CalcularPromedioParcial(np3, np4, eq2);
                    nota_temp.Q2 = tot2;
                }
                if (tot1 != 0 && tot2 != 0)
                {
                    fin = (tot1 + tot2) / 2;
                    nota_temp.FINAL = fin;
                }
                db.SaveChanges();
                
            }
            //Grados en base a materia Ingresada
            List<SelectListItem> lstgrad1 = new List<SelectListItem>();
            lstgrad1.Add(new SelectListItem() { Text = "Seleccionar", Value = "All" });
            List<string> lst3 = db.MATERIA.Where(ma => ma.ID_PROFESOR == prof_conectado && ma.MAT_NOMBRE == mats).Select(ma => ma.MAT_GRADO).ToList();
            for (int k = 0; k < lst3.Count; k++)
            {
                lstgrad1.Add(new SelectListItem() { Text = lst3[k], Value = lst3[k] });
            }
            //Llenamos de nuevo el combo de materias
            List<string> lstm1 = db.MATERIA.Where(ma => ma.ID_PROFESOR == prof_conectado).Select(ma => ma.MAT_NOMBRE).Distinct().ToList();
            List<SelectListItem> lst11 = new List<SelectListItem>();
            lst11.Add(new SelectListItem() { Text = "Seleccionar", Value = "All" });

            for (int r = 0; r < lstm1.Count; r++)
            {
                lst11.Add(new SelectListItem() { Text = lstm1[r], Value = lstm1[r] });
            }
            ViewBag.ID_MATERIA = new SelectList(lst11, "Text", "Value", mats);
            ViewBag.CB_GRADO = new SelectList(lstgrad1, "Text", "Value", grads);
            return View("NotasProf");
        }

        [HttpPost]
        public List<NOTA> validarNota(int mat_id, List<ESTUDIANTE> est)
        {
            //Instancia NOTA
            List<NOTA> nota = new List<NOTA>();
            //Parametros
            int anio = 1;

            //Consulta
            for (int i = 0; i < est.Count; i++)
            {
                List<NOTA> n = new List<NOTA>();
                //Un solo registro
                int estu = est[i].ID_ESTUDIANTE;
                n = db.NOTA.Where(not => not.ID_MATERIA == mat_id && not.ID_ESTUDIANTE == estu).ToList();
                if (n.Count != 0)
                {
                    nota.Add(n[0]);
                }
            }
            return nota;
        }
        public static bool validacion = false;
        [HttpPost]
        public ActionResult CargarDatos()
        {
            validacion = false;
            //Creo un nuevo Modelo
            if (grad_seleccionado != grads && mat_seleccionado != mats) { model = new List<NotasModel>(); }

            //Listar estudiantes del grado seleccionado - De acuerdo al último caracter del nombre de ususario Estudiante
            grad_seleccionado = grads;
            mat_seleccionado = mats;
            est_grado = db.ESTUDIANTE.Where(est => est.EST_USU.Substring(est.EST_USU.Length - 1, 1) == grad_seleccionado).ToList();


            //Validar existencia de nota
            List<int> mat = db.MATERIA.Where(mate => mats == mate.MAT_NOMBRE && mate.MAT_GRADO == grad_seleccionado).Select(mate => mate.ID_MATERIA).ToList();

            //Existe nota
            List<NOTA> aux_nota = validarNota(mat[0], est_grado);
            if (aux_nota.Count != 0)
            {
                model = new List<NotasModel>();
                for (int i = 0; i < aux_nota.Count; i++)
                {
                    NotasModel aux = new NotasModel();
                    aux.ID_ESTUDIANTE = aux_nota[i].ID_ESTUDIANTE;
                    aux.EST_NOMBRE = est_grado[i].EST_NOMBRE;
                    aux.EST_APELLIDO = est_grado[i].EST_APELLIDO;
                    if (aux_nota[i].NP1 != 0) { aux.np1 = aux_nota[i].NP1; }
                    if (aux_nota[i].NP2 != 0) { aux.np2 = aux_nota[i].NP2; }
                    if (aux_nota[i].EQ1 != 0) { aux.eq1 = aux_nota[i].EQ1; }
                    if (aux_nota[i].NP3 != 0) { aux.np3 = aux_nota[i].NP3; }
                    if (aux_nota[i].NP4 != 0) { aux.np4 = aux_nota[i].NP4; }
                    if (aux_nota[i].EQ2 != 0) { aux.eq2 = aux_nota[i].EQ2; }
                    if (aux_nota[i].Q1 != 0) { aux.q1 = aux_nota[i].Q1; }
                    if (aux_nota[i].Q2 != 0) { aux.q2 = aux_nota[i].Q2; }
                    if (aux_nota[i].FINAL != 0) { aux.final = aux_nota[i].FINAL; }
                    aux.ID_NOTA = aux_nota[i].ID_NOTA;
                    model.Add(aux);
                }
                validacion = true;
                ViewData["en"] = "false";
                //ViewData["Res"] = "Ya existe un registro de notas";
            }
            else
            {
                //Ingresar datos al modelo por primera vez
                if (model.Count == 0)
                {
                    for (int i = 0; i < est_grado.Count; i++)
                    {
                        NotasModel aux = new NotasModel();
                        aux.ID_ESTUDIANTE = est_grado[i].ID_ESTUDIANTE;
                        aux.EST_NOMBRE = est_grado[i].EST_NOMBRE;
                        aux.EST_APELLIDO = est_grado[i].EST_APELLIDO;
                        model.Add(aux);
                        ViewData["en"] = "true";
                    }
                }
            }
            //Grados en base a materia Ingresada
            List<SelectListItem> lstgrad1 = new List<SelectListItem>();
            lstgrad1.Add(new SelectListItem() { Text = "Seleccionar", Value = "All" });
            List<string> lst3 = db.MATERIA.Where(ma => ma.ID_PROFESOR == prof_conectado && ma.MAT_NOMBRE == mats).Select(ma => ma.MAT_GRADO).ToList();
            for (int k = 0; k < lst3.Count; k++)
            {
                lstgrad1.Add(new SelectListItem() { Text = lst3[k], Value = lst3[k] });
            }
            //Llenamos de nuevo el combo de materias
            List<string> lstm1 = db.MATERIA.Where(ma => ma.ID_PROFESOR == prof_conectado).Select(ma => ma.MAT_NOMBRE).Distinct().ToList();
            List<SelectListItem> lst11 = new List<SelectListItem>();
            lst11.Add(new SelectListItem() { Text = "Seleccionar", Value = "All" });

            for (int r = 0; r < lstm1.Count; r++)
            {
                lst11.Add(new SelectListItem() { Text = lstm1[r], Value = lstm1[r] });
            }
            ViewBag.ID_MATERIA = new SelectList(lst11, "Text", "Value", mats);
            ViewBag.CB_GRADO = new SelectList(lstgrad1, "Text", "Value", grads);
            return View("NotasProf", model);
        }
        [HttpPost]
        public void CargarDatosdef()
        {
            validacion = false;
            //Creo un nuevo Modelo
            if (grad_seleccionado != grads && mat_seleccionado != mats) { modelaux = new List<NotasModel>(); }

            //Listar estudiantes del grado seleccionado - De acuerdo al ultimo caracter del nombre de ususario Estudiante
            grad_seleccionado = grads;
            mat_seleccionado = mats;
            est_grado = db.ESTUDIANTE.Where(est => est.EST_USU.Substring(est.EST_USU.Length - 1, 1) == grad_seleccionado).ToList();


            //Validar existencia de nota
            List<int> mat = db.MATERIA.Where(mate => mats == mate.MAT_NOMBRE && mate.MAT_GRADO == grad_seleccionado).Select(mate => mate.ID_MATERIA).ToList();

            //Existe nota
            List<NOTA> aux_nota = validarNota(mat[0], est_grado);
            if (aux_nota.Count != 0)
            {
                modelaux = new List<NotasModel>();
                for (int i = 0; i < aux_nota.Count; i++)
                {
                    NotasModel aux = new NotasModel();
                    aux.ID_ESTUDIANTE = aux_nota[i].ID_ESTUDIANTE;
                    aux.EST_NOMBRE = est_grado[i].EST_NOMBRE;
                    aux.EST_APELLIDO = est_grado[i].EST_APELLIDO;
                    if (aux_nota[i].NP1 != 0) { aux.np1 = aux_nota[i].NP1; }
                    if (aux_nota[i].NP2 != 0) { aux.np2 = aux_nota[i].NP2; }
                    if (aux_nota[i].EQ1 != 0) { aux.eq1 = aux_nota[i].EQ1; }
                    if (aux_nota[i].NP3 != 0) { aux.np3 = aux_nota[i].NP3; }
                    if (aux_nota[i].NP4 != 0) { aux.np4 = aux_nota[i].NP4; }
                    if (aux_nota[i].EQ2 != 0) { aux.eq2 = aux_nota[i].EQ2; }
                    if (aux_nota[i].Q1 != 0) { aux.q1 = aux_nota[i].Q1; }
                    if (aux_nota[i].Q2 != 0) { aux.q2 = aux_nota[i].Q2; }
                    if (aux_nota[i].FINAL != 0) { aux.final = aux_nota[i].FINAL; }
                    aux.ID_NOTA = aux_nota[i].ID_NOTA;
                    modelaux.Add(aux);
                }
                validacion = true;
                //ViewData["Res"] = "Ya existe un registro de notas";
                ViewData["en"] = "false";
            }
            else
            {
                //Ingresar datos al modelo por primera vez
                if (modelaux.Count == 0)
                {
                    for (int i = 0; i < est_grado.Count; i++)
                    {
                        NotasModel aux = new NotasModel();
                        aux.ID_ESTUDIANTE = est_grado[i].ID_ESTUDIANTE;
                        aux.EST_NOMBRE = est_grado[i].EST_NOMBRE;
                        aux.EST_APELLIDO = est_grado[i].EST_APELLIDO;
                        modelaux.Add(aux);
                        ViewData["en"] = "false";
                    }
                }
            }
            //Grados en base a materia Ingresada
            List<SelectListItem> lstgrad1 = new List<SelectListItem>();
            lstgrad1.Add(new SelectListItem() { Text = "Seleccionar", Value = "All" });
            List<string> lst3 = db.MATERIA.Where(ma => ma.ID_PROFESOR == prof_conectado && ma.MAT_NOMBRE == mats).Select(ma => ma.MAT_GRADO).ToList();
            for (int k = 0; k < lst3.Count; k++)
            {
                lstgrad1.Add(new SelectListItem() { Text = lst3[k], Value = lst3[k] });
            }
            //Llenamos de nuevo el combo de materias
            List<string> lstm1 = db.MATERIA.Where(ma => ma.ID_PROFESOR == prof_conectado).Select(ma => ma.MAT_NOMBRE).Distinct().ToList();
            List<SelectListItem> lst11 = new List<SelectListItem>();
            lst11.Add(new SelectListItem() { Text = "Seleccionar", Value = "All" });

            for (int r = 0; r < lstm1.Count; r++)
            {
                lst11.Add(new SelectListItem() { Text = lstm1[r], Value = lstm1[r] });
            }
            ViewBag.ID_MATERIA = new SelectList(lst11, "Text", "Value", mats);
            ViewBag.CB_GRADO = new SelectList(lstgrad1, "Text", "Value", grads);
        }
        public double CalcularPromedioParcial(float p1, float p2, float ex)
        {
            float parciales = (p1 + p2) / 2;
            double prom_fin = (double)((parciales * 0.8) + (ex * 0.2));
            return prom_fin;
        }
        [HttpPost]
        public ActionResult CrearNota(float[] np1, float[] np2, float[] eq1, float[] q1, float[] np3, float[] np4, float[] eq2, float[] q2, float[] final)
        {
            //dimensionar listas vacias de quimestres y final
            List<NotasModel> lstmdnotas=new List<NotasModel>();
            q2= np2;
            q1 = np1;
            final = eq1;
            List<int> mat = db.MATERIA.Where(mate => mats == mate.MAT_NOMBRE && mate.MAT_GRADO == grad_seleccionado).Select(mate => mate.ID_MATERIA).ToList();

            //Crea nota porque no hay existencias
            if (validacion == false)
            {
                //Ingresar datos al modelo
                model = new List<NotasModel>();
                //Instancia NOTA

                //Parametros
                int anio = 1;
                int mat_id = mat[0];

                //Crear Nota
                for (int i = 0; i < est_grado.Count; i++)
                {
                    NOTA nota = new NOTA();
                    nota.ID_MATERIA = mat_id;
                    nota.ID_ANO = anio;
                    nota.ID_ESTUDIANTE = est_grado[i].ID_ESTUDIANTE;

                    //PARCIAL 1
                    nota.NP1 = np1[i];
                    nota.NP2 = np2[i];
                    nota.EQ1 = eq1[i];
                    //Realiza calculos si las notas están completas
                    if (np1[i] != 0 && np2[i] != 0 && eq1[i] != 0)
                    {
                        q1[i] = (float)CalcularPromedioParcial(np1[i], np2[i], eq1[i]);
                        nota.Q1 = q1[i];
                    }

                    //PARCIAL 2  
                    nota.NP3 = np3[i];
                    nota.NP4 = np4[i];
                    nota.EQ2 = eq2[i];
                    //Realiza calculos si las notas están completas
                    if (np3[i] != 0 && np4[i] != 0 && eq2[i] != 0)
                    {
                        q2[i] = (float)CalcularPromedioParcial(np3[i], np4[i], eq2[i]);
                        nota.Q2 = q2[i];
                    }

                    //final -si las notas están completas
                    if (q2[i] != 0 && q1[i] != 0)
                    {
                        final[i] = (q1[i] + q2[i]) / 2;
                        nota.FINAL = final[i];
                    }

                    db.NOTA.Add(nota);
                    db.SaveChanges();
                    ViewData["Res"] = "Registros ingresados";

                    //INGRESO DATOS AL MODELO
                    NotasModel aux = new NotasModel();
                    aux.ID_ESTUDIANTE = est_grado[i].ID_ESTUDIANTE;
                    aux.EST_NOMBRE = est_grado[i].EST_NOMBRE;
                    aux.EST_APELLIDO = est_grado[i].EST_APELLIDO;

                    if (np1[i] != 0) { aux.np1 = np1[i]; }
                    if (np2[i] != 0) { aux.np2 = np2[i]; }
                    if (eq1[i] != 0) { aux.eq1 = eq1[i]; }
                    if (np3[i] != 0) { aux.np3 = np3[i]; }
                    if (np4[i] != 0) { aux.np4 = np4[i]; }
                    if (eq2[i] != 0) { aux.eq2 = eq2[i]; }
                    if (q1[i] != 0) { aux.q1 = q1[i]; }
                    if (q2[i] != 0) { aux.q2 = q2[i]; }
                    if (final[i] != 0) { aux.final = final[i]; }
                    model.Add(aux);
                }
            }

            //Existe nota
            else
            {
                ViewData["Res"] = "No puede ingresar datos. Registro existente";
            }

            //Grados en base a materia Ingresada
            List<SelectListItem> lstgrad1 = new List<SelectListItem>();
            lstgrad1.Add(new SelectListItem() { Text = "Seleccionar", Value = "All" });
            List<string> lst3 = db.MATERIA.Where(ma => ma.ID_PROFESOR == prof_conectado && ma.MAT_NOMBRE == mats).Select(ma => ma.MAT_GRADO).ToList();
            for (int k = 0; k < lst3.Count; k++)
            {
                lstgrad1.Add(new SelectListItem() { Text = lst3[k], Value = lst3[k] });
            }
            //Llenamos de nuevo el combo de materias
            List<string> lstm1 = db.MATERIA.Where(ma => ma.ID_PROFESOR == prof_conectado).Select(ma => ma.MAT_NOMBRE).Distinct().ToList();
            List<SelectListItem> lst11 = new List<SelectListItem>();
            lst11.Add(new SelectListItem() { Text = "Seleccionar", Value = "All" });

            for (int r = 0; r < lstm1.Count; r++)
            {
                lst11.Add(new SelectListItem() { Text = lstm1[r], Value = lstm1[r] });
            }
            ViewBag.ID_MATERIA = new SelectList(lst11, "Text", "Value", mats);
            ViewBag.CB_GRADO = new SelectList(lstgrad1, "Text", "Value", grads);

            return View("NotasProf");

            //return RedirectToAction("CargarDatos", "PROFESORs");
        }

        //GESTIÓN ASISTENCIAS
        [HttpPost]
        public ActionResult DesplegarGrados1(string ID_MATERIA)
        {
            
            //Grados en base a materia Ingresada
            List<SelectListItem> lstgrad = new List<SelectListItem>();
            List<string> lst2 = db.MATERIA.Where(mate => mate.ID_PROFESOR == prof_conectado && mate.MAT_NOMBRE == ID_MATERIA).Select(mate => mate.MAT_GRADO).ToList();
            lstgrad.Add(new SelectListItem() { Text = "Seleccionar", Value = "All" });
            for (int i = 0; i < lst2.Count; i++)
            {
                lstgrad.Add(new SelectListItem() { Text = lst2[i], Value = lst2[i] });
            }
            List<string> lst1 = db.MATERIA.Where(mat => mat.ID_PROFESOR == prof_conectado).Select(mat => mat.MAT_NOMBRE).Distinct().ToList();

            //Llenamos de nuevo el combo de materias
            List<SelectListItem> lst = new List<SelectListItem>();
            lst.Add(new SelectListItem() { Text = "Seleccionar", Value = "All" });

            for (int i = 0; i < lst1.Count; i++)
            {
                lst.Add(new SelectListItem() { Text = lst1[i], Value = lst1[i] });
            }
            ViewBag.ID_MATERIA = lst;
            ViewBag.CB_GRADO = lstgrad;

            MATGRAD model = new MATGRAD()
            {
                matList = new SelectList(lst, "MAT_NOMBRE", "MAT_NOMBRE"),
                matNombre = ID_MATERIA,
                gradList = new SelectList(lstgrad, "MAT_GRADO", "MAT_GRADO")
            };
            mats = ID_MATERIA;
            model2 = model;
            return View("NotasProf");
        }
        [HttpPost]
        public ActionResult ObtenerDatos1(string CB_GRADO)
        {
            if (horario_mat_grado.Count == 0)
            {
                var dic_Aut = db.HORARIO.ToDictionary(s => s.ID_HORARIO, s => (s.HOR_DIA + " " + s.HOR_HORA.ToString("HH:mm")));
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


            List<MATERIA> mat = db.MATERIA.Where(ma => ma.ID_PROFESOR == prof_conectado && ma.MAT_NOMBRE == mats && ma.MAT_GRADO == CB_GRADO).ToList();

            PROFESOR prof = db.PROFESOR.Find(mat.First().ID_PROFESOR);
            idtemp = mat.First().ID_MATERIA;
            List<HORARIO> hora = db.HORARIO.Where(hor => hor.ID_MATERIA == idtemp).ToList();



            //Grados en base a materia Ingresada
            List<SelectListItem> lstgrad = new List<SelectListItem>();
            lstgrad.Add(new SelectListItem() { Text = "Seleccionar", Value = "All" });
            List<string> lst2 = db.MATERIA.Where(mate => mate.ID_PROFESOR == prof_conectado && mate.MAT_NOMBRE == mats).Select(mate => mate.MAT_GRADO).ToList();
            for (int i = 0; i < lst2.Count; i++)
            {
                lstgrad.Add(new SelectListItem() { Text = lst2[i], Value = lst2[i] });
            }


            //Llenamos de nuevo el combo de materias
            List<string> lst1 = db.MATERIA.Where(mate => mate.ID_PROFESOR == prof_conectado).Select(mate => mate.MAT_NOMBRE).Distinct().ToList();
            List<SelectListItem> lst = new List<SelectListItem>();
            lst.Add(new SelectListItem() { Text = "Seleccionar", Value = "All" });

            for (int i = 0; i < lst1.Count; i++)
            {
                lst.Add(new SelectListItem() { Text = lst1[i], Value = lst1[i] });
            }

            ViewBag.ID_MATERIA = new SelectList(lst, "Text", "Value", mats);
            ViewBag.CB_GRADO = new SelectList(lstgrad, "Text", "Value", grads);
            grads = CB_GRADO;

            return View("NotasProf");
        }
        #endregion
        #region Asistencia
        public ActionResult AsistenciasProf()
        {
            List<string> lst1 = db.MATERIA.Where(mat => mat.ID_PROFESOR == prof_conectado).Select(mat => mat.MAT_NOMBRE).Distinct().ToList();

            List<SelectListItem> lst = new List<SelectListItem>();
            List<SelectListItem> lst2 = new List<SelectListItem>();
            List<SelectListItem> lst3 = new List<SelectListItem>();

            lst.Add(new SelectListItem() { Text = "Seleccionar", Value = "All" });
            lst2.Add(new SelectListItem() { Text = "Seleccionar", Value = "All" });
            lst3.Add(new SelectListItem() { Text = "Seleccionar", Value = "All" });

            for (int i = 0; i < lst1.Count; i++)
            {
                lst.Add(new SelectListItem() { Text = lst1[i], Value = lst1[i] });
            }
            ViewBag.ID_MATERIA = lst;
            ViewBag.CB_GRADO = lst2;
            ViewBag.Horario = lst3;
            ViewBag.fecha = DateTime.Now.ToString();
            return View();
        }
        [HttpPost]
        public ActionResult DesplegarGrados(string ID_MATERIA)
        {
            //Grados en base a materia Ingresada
            List<SelectListItem> lstgrad = new List<SelectListItem>();
            List<string> lst2 = db.MATERIA.Where(mate => mate.ID_PROFESOR == prof_conectado && mate.MAT_NOMBRE == ID_MATERIA).Select(mate => mate.MAT_GRADO).ToList();
            lstgrad.Add(new SelectListItem() { Text = "Seleccionar", Value = "All" });
            for (int i = 0; i < lst2.Count; i++)
            {
                lstgrad.Add(new SelectListItem() { Text = lst2[i], Value = lst2[i] });
            }
            List<string> lst1 = db.MATERIA.Where(mat => mat.ID_PROFESOR == prof_conectado).Select(mat => mat.MAT_NOMBRE).Distinct().ToList();

            //Llenamos de nuevo el combo de materias
            List<SelectListItem> lst = new List<SelectListItem>();
            lst.Add(new SelectListItem() { Text = "Seleccionar", Value = "All" });

            for (int i = 0; i < lst1.Count; i++)
            {
                lst.Add(new SelectListItem() { Text = lst1[i], Value = lst1[i] });
            }
            ViewBag.ID_MATERIA = lst;
            ViewBag.CB_GRADO = lstgrad;

            MATGRAD model = new MATGRAD()
            {
                matList = new SelectList(lst, "MAT_NOMBRE", "MAT_NOMBRE"),
                matNombre = ID_MATERIA,
                gradList = new SelectList(lstgrad, "MAT_GRADO", "MAT_GRADO")
            };
            mats = ID_MATERIA;
            model2 = model;
            List<SelectListItem> lst3 = new List<SelectListItem>();
            lst3.Add(new SelectListItem() { Text = "Seleccionar", Value = "All" });
            ViewBag.Horario = lst3;
            ViewBag.fecha = DateTime.Now.ToString();
            return View("AsistenciasProf");
        }
        [HttpPost]
        public ActionResult ObtenerDatos(string CB_GRADO, string Horario)
        {

            List<MATERIA> mat = db.MATERIA.Where(ma => ma.ID_PROFESOR == prof_conectado && ma.MAT_NOMBRE == mats && ma.MAT_GRADO == CB_GRADO).ToList();

            PROFESOR prof = db.PROFESOR.Find(mat.First().ID_PROFESOR);
            idtemp = mat.First().ID_MATERIA;
            List<HORARIO> hora = db.HORARIO.Where(hor => hor.ID_MATERIA == idtemp).ToList();



            //Grados en base a materia Ingresada
            List<SelectListItem> lstgrad = new List<SelectListItem>();
            lstgrad.Add(new SelectListItem() { Text = "Seleccionar", Value = "All" });
            List<string> lst2 = db.MATERIA.Where(mate => mate.ID_PROFESOR == prof_conectado && mate.MAT_NOMBRE == mats).Select(mate => mate.MAT_GRADO).ToList();
            for (int i = 0; i < lst2.Count; i++)
            {
                lstgrad.Add(new SelectListItem() { Text = lst2[i], Value = lst2[i] });
            }


            //Llenamos de nuevo el combo de materias
            List<string> lst1 = db.MATERIA.Where(mate => mate.ID_PROFESOR == prof_conectado).Select(mate => mate.MAT_NOMBRE).Distinct().ToList();
            List<SelectListItem> lst = new List<SelectListItem>();
            lst.Add(new SelectListItem() { Text = "Seleccionar", Value = "All" });

            for (int i = 0; i < lst1.Count; i++)
            {
                lst.Add(new SelectListItem() { Text = lst1[i], Value = lst1[i] });
            }

            ViewBag.ID_MATERIA = new SelectList(lst, "Text", "Value", mats);
            ViewBag.CB_GRADO = new SelectList(lstgrad, "Text", "Value", grads);
            grads = CB_GRADO;


            //HORARIOS EN BASE A LA MATERIA INGRESADA
            List<SelectListItem> lsthor = new List<SelectListItem>();
            lsthor.Add(new SelectListItem() { Text = "Seleccionar", Value = "All" });
            List<string> lst3 = db.HORARIO.Where(mate => mate.ID_MATERIA == idtemp).Select(mate => mate.HOR_DIA).Distinct().ToList();
            for (int i = 0; i < lst3.Count; i++)
            {
                lsthor.Add(new SelectListItem() { Text = lst3[i], Value = lst3[i] });
            }

            ViewBag.Horario = new SelectList(lsthor, "Text", "Value", horario_seleccionado);
            horario_seleccionado = Horario;
            ViewBag.fecha = DateTime.Now.ToString();
            return View("AsistenciasProf");
        }
        [HttpPost]
        public ActionResult CargarHorario1(string Horario)
        {

            //HORARIOS EN BASE A LA MATERIA INGRESADA
            List<SelectListItem> lsthor = new List<SelectListItem>();
            lsthor.Add(new SelectListItem() { Text = "Seleccionar", Value = "All" });
            List<string> lst3 = db.HORARIO.Where(mate => mate.ID_MATERIA == idtemp).Select(mate => mate.HOR_DIA).Distinct().ToList();
            for (int i = 0; i < lst3.Count; i++)
            {
                lsthor.Add(new SelectListItem() { Text = lst3[i], Value = lst3[i] });
            }


            //Grados en base a materia Ingresada
            List<SelectListItem> lstgrad = new List<SelectListItem>();
            lstgrad.Add(new SelectListItem() { Text = "Seleccionar", Value = "All" });
            List<string> lst2 = db.MATERIA.Where(mate => mate.ID_PROFESOR == prof_conectado && mate.MAT_NOMBRE == mats).Select(mate => mate.MAT_GRADO).ToList();
            for (int i = 0; i < lst2.Count; i++)
            {
                lstgrad.Add(new SelectListItem() { Text = lst2[i], Value = lst2[i] });
            }


            //Llenamos de nuevo el combo de materias
            List<string> lst1 = db.MATERIA.Where(mate => mate.ID_PROFESOR == prof_conectado).Select(mate => mate.MAT_NOMBRE).Distinct().ToList();
            List<SelectListItem> lst = new List<SelectListItem>();
            lst.Add(new SelectListItem() { Text = "Seleccionar", Value = "All" });

            for (int i = 0; i < lst1.Count; i++)
            {
                lst.Add(new SelectListItem() { Text = lst1[i], Value = lst1[i] });
            }

            ViewBag.ID_MATERIA = new SelectList(lst, "Text", "Value", mats);
            ViewBag.CB_GRADO = new SelectList(lstgrad, "Text", "Value", grads);
            ViewBag.Horario = new SelectList(lsthor, "Text", "Value", Horario);
            horario_seleccionado = Horario;
            grad_seleccionado = grads;
            mat_seleccionado = mats;
            ViewBag.fecha = DateTime.Now.ToString();
            return View("AsistenciasProf");
        }

        //Carga de datos
        public List<bool> Validar(List<ASISTENCIA> asis_val_aux)
        {
            List<bool> datos_conf = new List<bool>();
            bool aux = false;
            for (int i = 0; i < asis_val_aux.Count; i++)
            {
                if (asis_val_aux[i].ASIS_CONF == "SI")
                {
                    aux = true;
                }
                else
                {
                    aux = false;
                }
                datos_conf.Add(aux);
            }
            return datos_conf;
        }

        public static DateTime fechamat;
        public static bool confirmacion = false;
        public static List<ASISTENCIA> asis_val_aux;

        [HttpPost]
        //Consultar
        public ActionResult ConsultarAsistencia(DateTime fecha)
        {
            asis_val_aux = new List<ASISTENCIA>();
            fechamat = fecha;
            confirmacion = false;
            //Creo un nuevo Modelo
            if (grad_seleccionado != grads || mat_seleccionado != mats) { modelo_asis = new List<Modelos.Asistencia>(); }
            if (modelo_asis.Count != 0) { modelo_asis = new List<Modelos.Asistencia>(); }

            //Listar estudiantes del grado seleccionado - De acuerdo al ultimo caracter del nombre de ususario Estudiante
            grad_seleccionado = grads;
            mat_seleccionado = mats;
            est_grado = db.ESTUDIANTE.Where(est => est.EST_USU.Substring(est.EST_USU.Length - 1, 1) == grad_seleccionado).ToList();

            //Consultar existencia de asistencia
            List<int> id_horarios = new List<int>();
            id_horarios = db.HORARIO.Where(mate => mate.ID_MATERIA == idtemp).Select(mate => mate.ID_HORARIO).ToList();


            //Arreglo de booleanos 
            if (id_horarios.Count != 0)
            {
                List<bool> conf = new List<bool>();

                for (int i = 0; i < est_grado.Count; i++)
                {
                    List<ASISTENCIA> aux = new List<ASISTENCIA>();
                    int id_aux = est_grado[i].ID_ESTUDIANTE;
                    int id_horario = id_horarios[0];
                    aux = db.ASISTENCIA.Where(asis_validar => asis_validar.ID_ESTUDIANTE == id_aux
                  && asis_validar.ASIS_FECHA == fecha && asis_validar.ID_HORARIO == id_horario).ToList();
                    if (aux.Count != 0) { asis_val_aux.Add(aux[0]); }
                }

                //Taer booleanos para check box 
                conf = Validar(asis_val_aux);

                //Existen asistencias
                if (asis_val_aux.Count != 0)
                {
                    for (int i = 0; i < est_grado.Count; i++)
                    {
                        Prueba.Modelos.Asistencia aux = new Prueba.Modelos.Asistencia();
                        aux.ID_ESTUDIANTE = est_grado[i].ID_ESTUDIANTE;
                        aux.EST_NOMBRE = est_grado[i].EST_NOMBRE;
                        aux.EST_APELLIDO = est_grado[i].EST_APELLIDO;
                        aux.ASIS_CONF = conf[i];
                        modelo_asis.Add(aux);
                    }
                    confirmacion = true; // existe asistencia booleano
                    ViewData["Res"] = "Ya existen asistencias registradas de los estudiantes en la fecha seleccionada";
                }
                else
                {
                    for (int i = 0; i < est_grado.Count; i++)
                    {
                        Prueba.Modelos.Asistencia aux = new Prueba.Modelos.Asistencia();
                        aux.ID_ESTUDIANTE = est_grado[i].ID_ESTUDIANTE;
                        aux.EST_NOMBRE = est_grado[i].EST_NOMBRE;
                        aux.EST_APELLIDO = est_grado[i].EST_APELLIDO;
                        modelo_asis.Add(aux);
                    }
                }
            }
            else
            {
                ViewData["Res"] = "Horario no ingresado";
            }
            CargarCombos();
            ViewBag.fecha = fecha.ToString();
            fechamat = fecha;
            return View("AsistenciasProf", modelo_asis);
        }

        [HttpPost]
        public ActionResult CrearAsistencia(string[] asis)
        {
            List<string> vals = new List<string>();
            String[] conf = asis;
            string bol = "";
            int aux = 0;

            for (int i = 0; i < est_grado.Count; i++)
            {
                if (conf[aux] == "true" && conf[aux + 1] == "false")
                {
                    bol = "true";
                    aux = aux + 2;

                }
                else
                {
                    bol = "false";
                    aux = aux + 1;
                }

                vals.Add(bol);
            }
            //Consultar existencia de horarios
            List<int> id_horarios = new List<int>();
            id_horarios = db.HORARIO.Where(mate => mate.ID_MATERIA == idtemp).Select(mate => mate.ID_HORARIO).ToList();

            //Existe asistencia
            if (confirmacion == false)
            {

                List<bool> asis_bool = new List<bool>();
                for (int j = 0; j < id_horarios.Count; j++)
                {
                    bool x3 = false;
                    for (int i = 0; i < est_grado.Count; i++)
                    {
                        //Creo objeto asistencia
                        ASISTENCIA asis_est = new ASISTENCIA();
                        //Id Horario
                        asis_est.ID_HORARIO = id_horarios[j];
                        //Fecha
                        asis_est.ASIS_FECHA = fechamat;
                        //Conf
                        if (vals[i] == "false")
                        {
                            asis_est.ASIS_CONF = "NO";
                            x3 = false;
                        }
                        else
                        {
                            asis_est.ASIS_CONF = "SI";
                            x3 = true;
                        }
                        //Est
                        asis_est.ID_ESTUDIANTE = est_grado[i].ID_ESTUDIANTE;
                        //Creo asistencia
                        db.ASISTENCIA.Add(asis_est);
                        db.SaveChanges();
                        ViewData["Res"] = "Registro ingresado";
                    }
                    asis_bool.Add(x3);
                }
                for (int i = 0; i < est_grado.Count; i++)
                {
                    if (vals[i] == "true")
                    {
                        modelo_asis[i].ASIS_CONF = true;
                    }
                    else
                    {
                        modelo_asis[i].ASIS_CONF = false;
                    }
                }
            }
            else
            {

                //EDIT
                for (int i = 0; i < asis_val_aux.Count; i++)
                {
                    ASISTENCIA asis_temp = db.ASISTENCIA.Find(asis_val_aux[i].ID_ASIS);
                    if (vals[i] == "false")
                    {
                        asis_temp.ASIS_CONF = "NO";
                    }
                    else
                    {
                        asis_temp.ASIS_CONF = "SI";
                    }
                    db.SaveChanges();
                }
                for (int i = 0; i < est_grado.Count; i++)
                {
                    if (vals[i] == "true")
                    {
                        modelo_asis[i].ASIS_CONF = true;
                    }
                    else
                    {
                        modelo_asis[i].ASIS_CONF = false;
                    }
                }
                ViewData["Res"] = "Registro Actualizado con éxito!";
            }
            CargarCombos();
            ViewBag.fecha = fechamat.ToString();
            return View("AsistenciasProf", modelo_asis);
        }

        public void CargarCombos()
        {
            //Llenar combos
            //HORARIOS EN BASE A LA MATERIA INGRESADA
            List<SelectListItem> lsthor = new List<SelectListItem>();
            lsthor.Add(new SelectListItem() { Text = "Seleccionar", Value = "All" });
            List<string> lst3 = db.HORARIO.Where(mate => mate.ID_MATERIA == idtemp).Select(mate => mate.HOR_DIA).Distinct().ToList();
            for (int i = 0; i < lst3.Count; i++)
            {
                lsthor.Add(new SelectListItem() { Text = lst3[i], Value = lst3[i] });
            }


            //Grados en base a materia Ingresada
            List<SelectListItem> lstgrad = new List<SelectListItem>();
            lstgrad.Add(new SelectListItem() { Text = "Seleccionar", Value = "All" });
            List<string> lst2 = db.MATERIA.Where(mate => mate.ID_PROFESOR == prof_conectado && mate.MAT_NOMBRE == mats).Select(mate => mate.MAT_GRADO).ToList();
            for (int i = 0; i < lst2.Count; i++)
            {
                lstgrad.Add(new SelectListItem() { Text = lst2[i], Value = lst2[i] });
            }


            //Llenamos de nuevo el combo de materias
            List<string> lst1 = db.MATERIA.Where(mate => mate.ID_PROFESOR == prof_conectado).Select(mate => mate.MAT_NOMBRE).Distinct().ToList();
            List<SelectListItem> lst = new List<SelectListItem>();
            lst.Add(new SelectListItem() { Text = "Seleccionar", Value = "All" });

            for (int i = 0; i < lst1.Count; i++)
            {
                lst.Add(new SelectListItem() { Text = lst1[i], Value = lst1[i] });
            }

            ViewBag.ID_MATERIA = new SelectList(lst, "Text", "Value", mats);
            ViewBag.CB_GRADO = new SelectList(lstgrad, "Text", "Value", grads);
            ViewBag.Horario = new SelectList(lsthor, "Text", "Value", horario_seleccionado);
        }

        #endregion
        #region LoginAdmin
        public ActionResult LoginAdmin()
        {
            return View();
        }
        //NOE CAMBIOS
        [HttpPost]
        public ActionResult LoginAdmin(string us, string clave)
        {
            List<PROFESOR> prof_temp = new List<PROFESOR>();
            prof_temp = db.PROFESOR.Where(prof => prof.PROF_USU == us && prof.PROF_PASSWORD == clave && prof.ID_TIPOU == 4).ToList();

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

        #endregion
        #region Login
        public ActionResult LoginProf()
        {

            return View();
        }

        [HttpPost]
        public ActionResult LoginProf(string us, string clave)
        {
            List<PROFESOR> prof_temp = new List<PROFESOR>();
            prof_temp = db.PROFESOR.Where(prof => prof.PROF_USU == us && prof.PROF_PASSWORD == clave).ToList();


            if (prof_temp.Count != 0) //Usuario existe
            {
                prof_conectado = prof_temp[0].ID_PROFESOR;
                usu = prof_temp.First().ID_PROFESOR;
                return RedirectToAction("HomeProfesores", "PROFESORs");
            }
            else
            {
                ViewData["Mensaje"] = "Usuario no encontrado/Contraseña Incorrecta";
                return View();
            }

        }
        public ActionResult HomeProfesores()
        {
            PROFESOR prof = db.PROFESOR.Find(usu);
            ViewData["nombre"] = "Bienvenido/a " + prof.PROF_NOMBRE.ToString() + " " + prof.PROF_APELLIDO.ToString();
            return View();
        }
        #endregion
        #region Métodos
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
            ViewBag.ID_TIPOU = new SelectList(db.TIPO_USUARIO, "ID_TIPOU", "TU_DESCRIP",2);
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
                pROFESOR.ID_TIPOU = 2;
                db.PROFESOR.Add(pROFESOR);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

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
                pROFESOR.ID_TIPOU = 2;
                db.Entry(pROFESOR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_TIPOU = new SelectList(db.TIPO_USUARIO, "ID_TIPOU", "TU_DESCRIP", 2);
            ViewBag.PROF_PASSWORD = db.PROFESOR.Find(pROFESOR.ID_PROFESOR).PROF_PASSWORD; 
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
            List<MATERIA> lstmat=db.MATERIA.Where(mt=>mt.ID_PROFESOR==id).ToList();
            if(lstmat.Count == 0)
            {
                db.PROFESOR.Remove(pROFESOR);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Alert = "No puede borrar un registro con dependencias";
            return View(pROFESOR);


        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        #endregion
        public void ExportContentToXls()
        {
            var gv = new GridView
            {
                DataSource = model
            };
            gv.DataBind();

            Response.ClearContent();
            Response.AddHeader("content-disposition",
                                String.Format("attachment;filename=Notas_{0}.xls", DateTime.Now));
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
            return new ActionAsPdf("NotasProf", new { nombre = "NotasGlobal" }) { FileName = nArchivo };
        }
    }
}