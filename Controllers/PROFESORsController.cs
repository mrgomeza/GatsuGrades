using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MoreLinq;
using Prueba;

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
        public static int horario_seleccionado = 0;
        public static int mat_id = 0;
        public static int usu = 0;
        public static string cel = "";
        public static int idtemp = 0;
        public static string mats = "";
        public static string grads = "";
        public static MATGRAD model2 = new MATGRAD();

        // GET: PROFESORs
        public ActionResult Index()
        {
            var pROFESOR = db.PROFESOR.Include(p => p.TIPO_USUARIO);
            return View(pROFESOR.ToList());
        }
        public ActionResult CrearNota(float[] NP1, float[] NP2, float[] EQ1, float[] Q1, float[] NP3, float[] NP4, float[] EQ2, float[] Q2, float[] FINAL)
        {
            List<int> mat = db.MATERIA.Where(mate => mats == mate.MAT_NOMBRE && mate.MAT_GRADO == grad_seleccionado).Select(mate => mate.ID_MATERIA).ToList();

            //Instancia NOTA
            NOTA nota = new NOTA();

            //Crear Nota
            int id_anio = 2022;
            int mat_id = mat[0];

            for (int i = 0; i < est_grado.Count; i++)
            {
            }


            //Ingresar datos al modelo
            List<NotasModel> model = new List<NotasModel>();
            for (int i = 0; i < est_grado.Count; i++)
            {
                NotasModel aux = new NotasModel();
                aux.ID_ESTUDIANTE = est_grado[i].ID_ESTUDIANTE;
                aux.EST_NOMBRE = est_grado[i].EST_NOMBRE;
                aux.EST_APELLIDO = est_grado[i].EST_APELLIDO;
                aux.NP1 = 0;
                model.Add(aux);
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
        [HttpPost]
        public ActionResult CargarDatos()
        {
            //Listar estudiantes del grado seleccionado - De acuerdo al ultimo caracter del nombre de ususario Estudiante
            grad_seleccionado = grads;
            est_grado = db.ESTUDIANTE.Where(est => est.EST_USU.Substring(est.EST_USU.Length - 1, 1) == grad_seleccionado).ToList();

            //Ingresar datos al modelo
            List<Prueba.NotasModel> model = new List<NotasModel>();
            for (int i = 0; i < est_grado.Count; i++)
            {
                NotasModel aux = new NotasModel();
                aux.ID_ESTUDIANTE = est_grado[i].ID_ESTUDIANTE;
                aux.EST_NOMBRE = est_grado[i].EST_NOMBRE;
                aux.EST_APELLIDO = est_grado[i].EST_APELLIDO;
                aux.NP1 = 0;
                model.Add(aux);
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
        //GESTIÓN ASISTENCIAS
        [HttpPost]
        public ActionResult DesplegarGrados1(string ID_MATERIA)
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

            lst.Add(new SelectListItem() { Text = "Seleccionar", Value = "All" });
            lst2.Add(new SelectListItem() { Text = "Seleccionar", Value = "All" });

            for (int i = 0; i < lst1.Count; i++)
            {
                lst.Add(new SelectListItem() { Text = lst1[i], Value = lst1[i] });
            }

            ViewBag.ID_MATERIA = lst;
            ViewBag.CB_GRADO = lst2;


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
            //horario_seleccionado = Horario;
            return View();
        }
        //GESTIÓN ASISTENCIAS
        [HttpPost]
        public ActionResult DesplegarGrados(string ID_MATERIA)
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
            return View("AsistenciasProf");
        }
        [HttpPost]
        public ActionResult ObtenerDatos(string CB_GRADO)
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

            return View("AsistenciasProf");
        }




        [HttpPost]
        public ActionResult CargarHorario()
        {
            grad_seleccionado = grads;
            List<MATERIA> materias_prof = new List<MATERIA>();
            est_grado = new List<ESTUDIANTE>();


            //Listar Materias que da Profesor
            materias_prof = db.MATERIA.Where(mat => mat.MAT_NOMBRE == mats && mat.MAT_GRADO == grad_seleccionado && mat.ID_PROFESOR == prof_conectado).ToList();

            if (materias_prof.Count != 0)
            {

                //Listar horarios de la materia seleccionada
                mat_id = materias_prof[0].ID_MATERIA;
                horario_mat_grado = db.HORARIO.Where(hor => hor.ID_MATERIA == mat_id).ToList();


                if (horario_mat_grado.Count != 0)
                {
                    ViewData["Mat"] = "Gestión de Asistencias " + materias_prof[0].MAT_NOMBRE + " " + grad_seleccionado + " EGB";
                    var dic_Aut = db.HORARIO.Where(hor => hor.ID_MATERIA == mat_id).ToDictionary(s => s.ID_HORARIO, s => (s.HOR_DIA + " " + s.HOR_HORA.ToString("HH:mm")));
                    ViewBag.Horario = new SelectList(dic_Aut, "Key", "Value");

                    AsistenciasProf();

                    //Grados en base a materia Ingresada
                    List<SelectListItem> lstgrad1 = new List<SelectListItem>();
                    lstgrad1.Add(new SelectListItem() { Text = "Seleccionar", Value = "All" });
                    List<string> lst3 = db.MATERIA.Where(ma => ma.ID_PROFESOR == prof_conectado && ma.MAT_NOMBRE == mats).Select(ma => ma.MAT_GRADO).ToList();
                    for (int k = 0; k < lst3.Count; k++)
                    {
                        lstgrad1.Add(new SelectListItem() { Text = lst3[k], Value = lst3[k] });
                    }


                    //Llenamos de nuevo el combo de materias
                    List<string> lstm1 = db.MATERIA.Where(ma => ma.ID_PROFESOR == prof_conectado && ma.ID_PROFESOR == prof_conectado).Select(ma => ma.MAT_NOMBRE).Distinct().ToList();
                    List<SelectListItem> lst11 = new List<SelectListItem>();

                    lst11.Add(new SelectListItem() { Text = "Seleccionar", Value = "All" });
                    for (int r = 0; r < lstm1.Count; r++)
                    {
                        lst11.Add(new SelectListItem() { Text = lstm1[r], Value = lstm1[r] });
                    }
                    ViewBag.ID_MATERIA = new SelectList(lst11, "Text", "Value", mats);
                    ViewBag.CB_GRADO = new SelectList(lstgrad1, "Text", "Value", grads);



                    //Listar estudiantes del grado seleccionado - De acuerdo al ultimo caracter del nombre de ususario Estudiante
                    est_grado = db.ESTUDIANTE.Where(est => est.EST_USU.Substring(est.EST_USU.Length - 1, 1) == grad_seleccionado).ToList();


                    if (est_grado.Count != 0)
                    {
                        //Colocar una tabla de estudiantes y bool asistencia, de acuerdo al horario filtrado
                        return View("AsistenciasProf", est_grado);
                    }
                }
                else
                {
                    //ViewBag.Horario = new SelectList(db.HORARIO.Where(hor => hor.ID_MATERIA == 0), "ID_HORARIO", "HOR_DIA");
                    ViewBag.Alert = "La Materia " + materias_prof[0].MAT_NOMBRE + " no tiene un horario asignado en " + grad_seleccionado + " EGB";
                    AsistenciasProf();
                }

            }
            else
            {
                //ViewBag.Horario = new SelectList(db.HORARIO.Where(hor => hor.ID_MATERIA == 0), "ID_HORARIO", "HOR_DIA");
                ViewBag.Alert = "El profesor seleccionado no dicta la materia ";
                AsistenciasProf();
            }
            return View("AsistenciasProf");
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
                else
                {
                    aux = "false";
                }
                datos_conf.Add(aux);
            }
            return datos_conf;
        }


        //CREAR ASISTENCIA
        [HttpPost]
        public ActionResult CrearAsistencia(DateTime fecha, string[] asis, int Horario)
        {
            DateTime fechaaux = fecha;
            String[] conf = asis;
            List<string> vals=new List<string>();
            List<ASISTENCIA> asis_val_aux = new List<ASISTENCIA>();
            string aux_conf = "";
            string bol = "";
            int aux=0;
            horario_seleccionado = Horario;

            for(int i = 0; i < est_grado.Count; i++)
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
                && asis_validar.ASIS_FECHA == fechaaux && asis_validar.ID_HORARIO == horario_seleccionado).ToList();

                if (asis_val.Count != 0)
                {
                    asis_val_aux.Add(asis_val[0]);
                }
            }

            //Ya existen asistencias en esa fecha, hora, dia
            if (asis_val_aux.Count == est_grado.Count)
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

            var dic_Aut = db.HORARIO.Where(hor => hor.ID_MATERIA == mat_id).ToDictionary(s => s.ID_HORARIO, s => (s.HOR_DIA + " " + s.HOR_HORA.ToString("HH:mm")));
            ViewBag.Horario = new SelectList(dic_Aut, "Key", "Value");
            return View("AsistenciasProf", est_grado);
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

    }
}