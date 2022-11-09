using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MoreLinq;
using Prueba;

namespace Prueba.Controllers
{
    public class HORARIOsController : Controller
    {
        private GatsuGradesv8Entities db = new GatsuGradesv8Entities();
        public static int idtemp = 0;
        public static string mats="";
        public static string grads ="";
        public static MATGRAD model2=new MATGRAD();

        public static string nomdt = "";
        public static string graddt = "";
        public static string matdt = "";


        #region Pintar horario
        [HttpPost]
        private void Pintar(List<HORARIO> hora)
        {
            for (int i = 0; i < hora.Count; i++)
            {
                string color = "#F1CD64";
                string dia = hora[i].HOR_DIA;
                if (hora[i].HOR_DIA == "Lunes" && hora[i].HOR_HORA == DateTime.Parse("2022-10-16 7:40:00.000"))
                {
                    ViewData["Confc1"] = color;
                }
                if (hora[i].HOR_DIA == "Martes" && hora[i].HOR_HORA == DateTime.Parse("2022-10-16 7:40:00.000"))
                {
                    ViewData["Confc2"] = color;
                }
                if (hora[i].HOR_DIA == "Miércoles" && hora[i].HOR_HORA == DateTime.Parse("2022-10-16 7:40:00.000"))
                {
                    ViewData["Confc3"] = color;
                }
                if (hora[i].HOR_DIA == "Jueves" && hora[i].HOR_HORA == DateTime.Parse("2022-10-16 7:40:00.000"))
                {
                    ViewData["Confc4"] = color;
                }
                if (hora[i].HOR_DIA == "Viernes" && hora[i].HOR_HORA == DateTime.Parse("2022-10-16 7:40:00.000"))
                {
                    ViewData["Confc5"] = color;
                }
                if (hora[i].HOR_DIA == "Lunes" && hora[i].HOR_HORA == DateTime.Parse("2022-10-16 8:20:00.000"))
                {
                    ViewData["Confc6"] = color;
                }
                if (hora[i].HOR_DIA == "Martes" && hora[i].HOR_HORA == DateTime.Parse("2022-10-16 8:20:00.000"))
                {
                    ViewData["Confc7"] = color;
                }
                if (hora[i].HOR_DIA == "Miércoles" && hora[i].HOR_HORA == DateTime.Parse("2022-10-16 8:20:00.000"))
                {
                    ViewData["Confc8"] = color;
                }
                if (hora[i].HOR_DIA == "Jueves" && hora[i].HOR_HORA == DateTime.Parse("2022-10-16 8:20:00.000"))
                {
                    ViewData["Confc9"] = color;
                }
                if (hora[i].HOR_DIA == "Viernes" && hora[i].HOR_HORA == DateTime.Parse("2022-10-16 8:20:00.000"))
                {
                    ViewData["Confc10"] = color;
                }
                if (hora[i].HOR_DIA == "Lunes" && hora[i].HOR_HORA == DateTime.Parse("2022-10-16 9:00:00.000"))
                {
                    ViewData["Confc11"] = color;
                }
                if (hora[i].HOR_DIA == "Martes" && hora[i].HOR_HORA == DateTime.Parse("2022-10-16 9:00:00.000"))
                {
                    ViewData["Confc12"] = color;
                }
                if (hora[i].HOR_DIA == "Miércoles" && hora[i].HOR_HORA == DateTime.Parse("2022-10-16 9:00:00.000"))
                {
                    ViewData["Confc13"] = color;
                }
                if (hora[i].HOR_DIA == "Jueves" && hora[i].HOR_HORA == DateTime.Parse("2022-10-16 9:00:00.000"))
                {
                    ViewData["Confc14"] = color;
                }
                if (hora[i].HOR_DIA == "Viernes" && hora[i].HOR_HORA == DateTime.Parse("2022-10-16 9:00:00.000"))
                {
                    ViewData["Confc15"] = color;
                }
                if (hora[i].HOR_DIA == "Lunes" && hora[i].HOR_HORA == DateTime.Parse("2022-10-16 10:10:00.000"))
                {
                    ViewData["Confc16"] = color;
                }
                if (hora[i].HOR_DIA == "Martes" && hora[i].HOR_HORA == DateTime.Parse("2022-10-16 10:10:00.000"))
                {
                    ViewData["Confc17"] = color;
                }
                if (hora[i].HOR_DIA == "Miércoles" && hora[i].HOR_HORA == DateTime.Parse("2022-10-16 10:10:00.000"))
                {
                    ViewData["Confc18"] = color;
                }
                if (hora[i].HOR_DIA == "Jueves" && hora[i].HOR_HORA == DateTime.Parse("2022-10-16 10:10:00.000"))
                {
                    ViewData["Confc19"] = color;
                }
                if (hora[i].HOR_DIA == "Viernes" && hora[i].HOR_HORA == DateTime.Parse("2022-10-16 10:10:00.000"))
                {
                    ViewData["Confc20"] = color;
                }
                if (hora[i].HOR_DIA == "Lunes" && hora[i].HOR_HORA == DateTime.Parse("2022-10-16 10:50:00.000"))
                {
                    ViewData["Confc21"] = color;
                }
                if (hora[i].HOR_DIA == "Martes" && hora[i].HOR_HORA == DateTime.Parse("2022-10-16 10:50:00.000"))
                {
                    ViewData["Confc22"] = color;
                }
                if (hora[i].HOR_DIA == "Miércoles" && hora[i].HOR_HORA == DateTime.Parse("2022-10-16 10:50:00.000"))
                {
                    ViewData["Confc23"] = color;
                }
                if (hora[i].HOR_DIA == "Jueves" && hora[i].HOR_HORA == DateTime.Parse("2022-10-16 10:50:00.000"))
                {
                    ViewData["Confc24"] = color;
                }
                if (hora[i].HOR_DIA == "Viernes" && hora[i].HOR_HORA == DateTime.Parse("2022-10-16 10:50:00.000"))
                {
                    ViewData["Confc25"] = color;
                }
                if (hora[i].HOR_DIA == "Lunes" && hora[i].HOR_HORA == DateTime.Parse("2022-10-16 11:50:00.000"))
                {
                    ViewData["Confc26"] = color;
                }
                if (hora[i].HOR_DIA == "Martes" && hora[i].HOR_HORA == DateTime.Parse("2022-10-16 11:50:00.000"))
                {
                    ViewData["Confc27"] = color;
                }
                if (hora[i].HOR_DIA == "Miércoles" && hora[i].HOR_HORA == DateTime.Parse("2022-10-16 11:50:00.000"))
                {
                    ViewData["Confc28"] = color;
                }
                if (hora[i].HOR_DIA == "Jueves" && hora[i].HOR_HORA == DateTime.Parse("2022-10-16 11:50:00.000"))
                {
                    ViewData["Confc29"] = color;
                }
                if (hora[i].HOR_DIA == "Viernes" && hora[i].HOR_HORA == DateTime.Parse("2022-10-16 11:50:00.000"))
                {
                    ViewData["Confc30"] = color;
                }
                if (hora[i].HOR_DIA == "Lunes" && hora[i].HOR_HORA == DateTime.Parse("2022-10-16 12:30:00.000"))
                {
                    ViewData["Confc31"] = color;
                }
                if (hora[i].HOR_DIA == "Martes" && hora[i].HOR_HORA == DateTime.Parse("2022-10-16 12:30:00.000"))
                {
                    ViewData["Confc32"] = color;
                }
                if (hora[i].HOR_DIA == "Miércoles" && hora[i].HOR_HORA == DateTime.Parse("2022-10-16 12:30:00.000"))
                {
                    ViewData["Confc33"] = color;
                }
                if (hora[i].HOR_DIA == "Jueves" && hora[i].HOR_HORA == DateTime.Parse("2022-10-16 12:30:00.000"))
                {
                    ViewData["Confc34"] = color;
                }
                if (hora[i].HOR_DIA == "Viernes" && hora[i].HOR_HORA == DateTime.Parse("2022-10-16 12:30:00.000"))
                {
                    ViewData["Confc35"] = color;
                }
            }
        }
        #endregion
        public ActionResult HorarioDesp()
        {
            List<string> lst1 = db.MATERIA.Select(mat => mat.MAT_NOMBRE).Distinct().ToList();

            List<SelectListItem> lst = new List<SelectListItem>();
            List<SelectListItem> lst2 = new List<SelectListItem>();

            for (int i = 0; i < lst1.Count; i++)
            {
                lst.Add(new SelectListItem() { Text = lst1[i], Value = lst1[i] });
            }

            ViewBag.ID_MATERIA = lst;
            ViewBag.CB_GRADO = lst2;

                return View();
        }

        [HttpPost]
        public ActionResult DesplegarGrados(string ID_MATERIA)
        {
            //Grados en base a materia Ingresada
            List<SelectListItem> lstgrad = new List<SelectListItem>();
            List<string> lst2 = db.MATERIA.Where(mate => mate.MAT_NOMBRE == ID_MATERIA).Select(mate => mate.MAT_GRADO).ToList();
            for (int i = 0; i < lst2.Count; i++)
            {
                lstgrad.Add(new SelectListItem() { Text = lst2[i], Value = lst2[i] });
            }
            List<string> lst1 = db.MATERIA.Select(mat => mat.MAT_NOMBRE).Distinct().ToList();

            //Llenamos de nuevo el combo de materias
            List<SelectListItem> lst = new List<SelectListItem>();


            for (int i = 0; i < lst1.Count; i++)
            {
                lst.Add(new SelectListItem() { Text = lst1[i], Value = lst1[i] });
            }
            ViewBag.ID_MATERIA = lst;
            ViewBag.CB_GRADO = lstgrad;

            MATGRAD model = new MATGRAD()
            {
                matList = new SelectList(lst, "MAT_NOMBRE", "MAT_NOMBRE"),
                matNombre =ID_MATERIA,
                gradList= new SelectList(lstgrad, "MAT_GRADO", "MAT_GRADO")
            };
            mats = ID_MATERIA;
            model2 = model;
            return View("HorarioDesp",model);
        }
        public ActionResult ObtenerDatos(string CB_GRADO)
        {
            List<MATERIA> mat = db.MATERIA.Where(ma => ma.MAT_NOMBRE == mats && ma.MAT_GRADO == CB_GRADO).ToList();

            PROFESOR prof = db.PROFESOR.Find(mat.First().ID_PROFESOR);

            idtemp = mat.First().ID_MATERIA;
            List<HORARIO> hora = db.HORARIO.Where(hor => hor.ID_MATERIA == idtemp).ToList();

            //Seleccionar todos los horarios de la materia
            List<MATERIA> mat2 = db.MATERIA.Where( ma=>ma.MAT_GRADO == CB_GRADO).ToList();
            List<HORARIO> hora2 = new List<HORARIO>();
            for (int i = 0; i < mat2.Count; i++)
            {
                int aux = mat2[i].ID_MATERIA;
                List<HORARIO> horaux = db.HORARIO.Where(hor => hor.ID_MATERIA == aux ).ToList();
                for( int j = 0; j < horaux.Count; j++)
                {
                    hora2.Add(horaux[j]);
                }
            }
            


            nomdt = "Nombre Profesor: " + prof.PROF_NOMBRE.ToString() + " " + prof.PROF_APELLIDO.ToString();
            matdt= "Materia: " + mat.First().MAT_NOMBRE.ToString();
            graddt= "Grado: " + mat.First().MAT_GRADO.ToString();

            ViewData["ProfNombre"] = nomdt;
            ViewData["Mat"] = matdt;
            ViewData["Grado"] = graddt;

            Pintar(hora2);


            //Grados en base a materia Ingresada
            List<SelectListItem> lstgrad = new List<SelectListItem>();
            List<string> lst2 = db.MATERIA.Where(mate => mate.MAT_NOMBRE == mats).Select(mate => mate.MAT_GRADO).ToList();
            for (int i = 0; i < lst2.Count; i++)
            {
                lstgrad.Add(new SelectListItem() { Text = lst2[i], Value = lst2[i] });
            }


            //Llenamos de nuevo el combo de materias
            List<string> lst1 = db.MATERIA.Select(mate => mate.MAT_NOMBRE).Distinct().ToList();
            List<SelectListItem> lst = new List<SelectListItem>();


            for (int i = 0; i < lst1.Count; i++)
            {
                lst.Add(new SelectListItem() { Text = lst1[i], Value = lst1[i] });
            }
            ViewBag.ID_MATERIA = new SelectList(lst,"Text","Value",mats);
            ViewBag.CB_GRADO = lstgrad;
            grads = CB_GRADO;

            return View("HorarioDesp");
        }
        
        //Horario DESP
        
        
        #region Botones Horas
        [HttpPost]
        public ActionResult PresionaBotonL1(string L1)
        {
            
            string auxdia = "Lunes";
            DateTime auxhora= DateTime.Parse("2022-10-16 7:40:00.000");
            return PresionaBotondef1(auxdia, auxhora,"Conf","Confc1");
        }

        [HttpPost]
        public ActionResult PresionaBotonM1(string M1)
        {

            string auxdia = "Martes";
            DateTime auxhora = DateTime.Parse("2022-10-16 7:40:00.000");
            return PresionaBotondef1(auxdia, auxhora, "Conf2", "Confc2");
        }
        [HttpPost]
        public ActionResult PresionaBotonMI1(string MI1)
        {

            string auxdia = "Miércoles";
            DateTime auxhora = DateTime.Parse("2022-10-16 7:40:00.000");
            return PresionaBotondef1(auxdia, auxhora, "Conf3", "Confc3");
        }
        [HttpPost]
        public ActionResult PresionaBotonJ1(string J1)
        {

            string auxdia = "Jueves";
            DateTime auxhora = DateTime.Parse("2022-10-16 7:40:00.000");
            return PresionaBotondef1(auxdia, auxhora, "Conf4", "Confc4");
        }
        [HttpPost]
        public ActionResult PresionaBotonV1(string V1)
        {

            string auxdia = "Viernes";
            DateTime auxhora = DateTime.Parse("2022-10-16 7:40:00.000");
            return PresionaBotondef1(auxdia, auxhora, "Conf5", "Confc5");
        }
        [HttpPost]
        public ActionResult PresionaBotonL2(string L2)
        {

            string auxdia = "Lunes";
            DateTime auxhora = DateTime.Parse("2022-10-16 8:20:00.000");
            return PresionaBotondef1(auxdia, auxhora, "Conf6", "Confc6");
        }

        [HttpPost]
        public ActionResult PresionaBotonM2(string M2)
        {

            string auxdia = "Martes";
            DateTime auxhora = DateTime.Parse("2022-10-16 8:20:00.000");
            return PresionaBotondef1(auxdia, auxhora, "Conf7", "Confc7");
        }
        [HttpPost]
        public ActionResult PresionaBotonMI2(string MI2)
        {

            string auxdia = "Miércoles";
            DateTime auxhora = DateTime.Parse("2022-10-16 8:20:00.000");
            return PresionaBotondef1(auxdia, auxhora, "Conf8", "Confc8");
        }
        [HttpPost]
        public ActionResult PresionaBotonJ2(string J2)
        {

            string auxdia = "Jueves";
            DateTime auxhora = DateTime.Parse("2022-10-16 8:20:00.000");
            return PresionaBotondef1(auxdia, auxhora, "Conf9", "Confc9");
        }
        [HttpPost]
        public ActionResult PresionaBotonV2(string V2)
        {

            string auxdia = "Viernes";
            DateTime auxhora = DateTime.Parse("2022-10-16 8:20:00.000");
            return PresionaBotondef1(auxdia, auxhora, "Conf10", "Confc10");
        }
        [HttpPost]
        public ActionResult PresionaBotonL3(string L3)
        {

            string auxdia = "Lunes";
            DateTime auxhora = DateTime.Parse("2022-10-16 9:00:00.000");
            return PresionaBotondef1(auxdia, auxhora, "Conf11", "Confc11");
        }

        [HttpPost]
        public ActionResult PresionaBotonM3(string M3)
        {

            string auxdia = "Martes";
            DateTime auxhora = DateTime.Parse("2022-10-16 9:00:00.000");
            return PresionaBotondef1(auxdia, auxhora, "Conf12", "Confc12");
        }
        [HttpPost]
        public ActionResult PresionaBotonMI3(string MI3)
        {

            string auxdia = "Miércoles";
            DateTime auxhora = DateTime.Parse("2022-10-16 9:00:00.000");
            return PresionaBotondef1(auxdia, auxhora, "Conf13", "Confc13");
        }
        [HttpPost]
        public ActionResult PresionaBotonJ3(string J3)
        {

            string auxdia = "Jueves";
            DateTime auxhora = DateTime.Parse("2022-10-16 9:00:00.000");
            return PresionaBotondef1(auxdia, auxhora, "Conf14", "Confc14");
        }
        [HttpPost]
        public ActionResult PresionaBotonV3(string V3)
        {

            string auxdia = "Viernes";
            DateTime auxhora = DateTime.Parse("2022-10-16 9:00:00.000");
            return PresionaBotondef1(auxdia, auxhora, "Conf15", "Confc15");
        }
        [HttpPost]
        public ActionResult PresionaBotonL4(string L4)
        {

            string auxdia = "Lunes";
            DateTime auxhora = DateTime.Parse("2022-10-16 10:10:00.000");
            return PresionaBotondef1(auxdia, auxhora, "Conf16", "Confc16");
        }

        [HttpPost]
        public ActionResult PresionaBotonM4(string M4)
        {

            string auxdia = "Martes";
            DateTime auxhora = DateTime.Parse("2022-10-16 10:10:00.000");
            return PresionaBotondef1(auxdia, auxhora, "Conf17", "Confc17");
        }
        [HttpPost]
        public ActionResult PresionaBotonMI4(string MI4)
        {

            string auxdia = "Miércoles";
            DateTime auxhora = DateTime.Parse("2022-10-16 10:10:00.000");
            return PresionaBotondef1(auxdia, auxhora, "Conf18", "Confc18");
        }
        [HttpPost]
        public ActionResult PresionaBotonJ4(string J4)
        {

            string auxdia = "Jueves";
            DateTime auxhora = DateTime.Parse("2022-10-16 10:10:00.000");
            return PresionaBotondef1(auxdia, auxhora, "Conf19", "Confc19");
        }
        [HttpPost]
        public ActionResult PresionaBotonV4(string V4)
        {

            string auxdia = "Viernes";
            DateTime auxhora = DateTime.Parse("2022-10-16 10:10:00.000");
            return PresionaBotondef1(auxdia, auxhora, "Conf20", "Confc20");
        }
        [HttpPost]
        public ActionResult PresionaBotonL5(string L5)
        {

            string auxdia = "Lunes";
            DateTime auxhora = DateTime.Parse("2022-10-16 10:50:00.000");
            return PresionaBotondef1(auxdia, auxhora, "Conf21", "Confc21");
        }

        [HttpPost]
        public ActionResult PresionaBotonM5(string M5)
        {

            string auxdia = "Martes";
            DateTime auxhora = DateTime.Parse("2022-10-16 10:50:00.000");
            return PresionaBotondef1(auxdia, auxhora, "Conf22", "Confc22");
        }
        [HttpPost]
        public ActionResult PresionaBotonMI5(string MI5)
        {

            string auxdia = "Miércoles";
            DateTime auxhora = DateTime.Parse("2022-10-16 10:50:00.000");
            return PresionaBotondef1(auxdia, auxhora, "Conf23", "Confc23");
        }
        [HttpPost]
        public ActionResult PresionaBotonJ5(string J5)
        {

            string auxdia = "Jueves";
            DateTime auxhora = DateTime.Parse("2022-10-16 10:50:00.000");
            return PresionaBotondef1(auxdia, auxhora, "Conf24", "Confc24");
        }
        [HttpPost]
        public ActionResult PresionaBotonV5(string V5)
        {

            string auxdia = "Viernes";
            DateTime auxhora = DateTime.Parse("2022-10-16 10:50:00.000");
            return PresionaBotondef1(auxdia, auxhora, "Conf25", "Confc25");
        }
        [HttpPost]
        public ActionResult PresionaBotonL6(string L6)
        {

            string auxdia = "Lunes";
            DateTime auxhora = DateTime.Parse("2022-10-16 11:50:00.000");
            return PresionaBotondef1(auxdia, auxhora, "Conf26", "Confc26");
        }

        [HttpPost]
        public ActionResult PresionaBotonM6(string M6)
        {

            string auxdia = "Martes";
            DateTime auxhora = DateTime.Parse("2022-10-16 11:50:00.000");
            return PresionaBotondef1(auxdia, auxhora, "Conf27", "Confc27");
        }
        [HttpPost]
        public ActionResult PresionaBotonMI6(string MI6)
        {

            string auxdia = "Miércoles";
            DateTime auxhora = DateTime.Parse("2022-10-16 11:50:00.000");
            return PresionaBotondef1(auxdia, auxhora, "Conf28", "Confc28");
        }
        [HttpPost]
        public ActionResult PresionaBotonJ6(string J6)
        {

            string auxdia = "Jueves";
            DateTime auxhora = DateTime.Parse("2022-10-16 11:50:00.000");
            return PresionaBotondef1(auxdia, auxhora, "Conf29", "Confc29");
        }
        [HttpPost]
        public ActionResult PresionaBotonV6(string V6)
        {

            string auxdia = "Viernes";
            DateTime auxhora = DateTime.Parse("2022-10-16 11:50:00.000");
            return PresionaBotondef1(auxdia, auxhora, "Conf30", "Confc30");
        }
        [HttpPost]
        public ActionResult PresionaBotonL7(string L7)
        {

            string auxdia = "Lunes";
            DateTime auxhora = DateTime.Parse("2022-10-16 12:30:00.000");
            return PresionaBotondef1(auxdia, auxhora, "Conf31", "Confc31");
        }

        [HttpPost]
        public ActionResult PresionaBotonM7(string M7)
        {

            string auxdia = "Martes";
            DateTime auxhora = DateTime.Parse("2022-10-16 12:30:00.000");
            return PresionaBotondef1(auxdia, auxhora, "Conf32", "Confc32");
        }
        [HttpPost]
        public ActionResult PresionaBotonMI7(string MI7)
        {

            string auxdia = "Miércoles";
            DateTime auxhora = DateTime.Parse("2022-10-16 12:30:00.000");
            return PresionaBotondef1(auxdia, auxhora, "Conf33", "Confc33");
        }
        [HttpPost]
        public ActionResult PresionaBotonJ7(string J7)
        {

            string auxdia = "Jueves";
            DateTime auxhora = DateTime.Parse("2022-10-16 12:30:00.000");
            return PresionaBotondef1(auxdia, auxhora, "Conf34", "Confc34");
        }
        [HttpPost]
        public ActionResult PresionaBotonV7(string V7)
        {

            string auxdia = "Viernes";
            DateTime auxhora = DateTime.Parse("2022-10-16 12:30:00.000");
            return PresionaBotondef1(auxdia, auxhora, "Conf35", "Confc35");
        }
        #endregion
        #region PresionaBotonDef
        [HttpPost]
        private ActionResult PresionaBotondef(string dia, DateTime hora,string dat)
        {
            //Validacion

            List<HORARIO> lsth= db.HORARIO.ToList();
            List<MATERIA> lstm = db.MATERIA.ToList();

            List<MATERIA> mate = new List<MATERIA>();
            List<int> matid = new List<int>();
            List<HORARIO> lsthemp = new List<HORARIO>();
            List<MATERIA> lstmprof = new List<MATERIA>();
            List<HORARIO> lstmproftemp = new List<HORARIO>();

            PROFESOR proftemp = new PROFESOR();
            HORARIO hortemp = new HORARIO();
            HORARIO hortemp2 = new HORARIO();
            List<HORARIO> lsthemp2 = new List<HORARIO>();
            //Materia ingresada en el combo
            MATERIA matemp= db.MATERIA.Find(idtemp);
            
            string auxdia = dia;
            DateTime auxhora = hora;
            bool val = false;

            
            for (int i = 0; i < lstm.Count(); i++)
            {
                if (lstm[i].MAT_GRADO ==matemp.MAT_GRADO && lstm[i].ID_MATERIA!=matemp.ID_MATERIA)
                {
                    val = true;

                    //La materia tiene dia y hora disponible
                    string grad = lstm[i].MAT_GRADO;
                    mate = db.MATERIA.Where(mat => mat.MAT_GRADO == grad).ToList();
                    matid= mate.Select(mat => mat.ID_MATERIA).ToList();
                    lsthemp = db.HORARIO.Where(hor => matid.Contains(hor.ID_MATERIA) && hor.HOR_DIA == auxdia && hor.HOR_HORA == auxhora).ToList();


                    int idprof = matemp.ID_PROFESOR;
                    var materiap = db.MATERIA.Where(mat => mat.ID_PROFESOR == idprof).ToList();
                    var matpid = materiap.Select(mat => mat.ID_MATERIA).ToList();

                    lstmproftemp = db.HORARIO.Where(hor => matpid.Contains(hor.ID_MATERIA) && hor.HOR_DIA == auxdia && hor.HOR_HORA == auxhora).ToList();
                    if (lstmproftemp.Count == 0 && lsthemp.Count==0)
                    {
                        hortemp.ID_MATERIA = matemp.ID_MATERIA;
                        hortemp.HOR_DIA = auxdia;
                        hortemp.HOR_HORA = auxhora;
                        db.HORARIO.Add(hortemp);
                        db.SaveChanges();
                        ViewData[dat] = "Se ingreso la materia";
                        ViewBag.ID_MATERIA = new SelectList(db.MATERIA, "ID_MATERIA", "MAT_COD", matemp.ID_MATERIA);
                        return View("HorarioDesp");
                    }

                }
                
            }
            if (val == false)//Si la materia es nueva
            {
                int idprof = matemp.ID_PROFESOR;
                var materiap = db.MATERIA.Where(mat => mat.ID_PROFESOR == idprof).ToList();
                var matpid = materiap.Select(mat => mat.ID_MATERIA).ToList();

                lstmproftemp = db.HORARIO.Where(hor => matpid.Contains(hor.ID_MATERIA) && hor.HOR_DIA == auxdia && hor.HOR_HORA == auxhora).ToList();
                    if (lstmproftemp.Count == 0)
                    {
                        hortemp.ID_MATERIA = matemp.ID_MATERIA;
                        hortemp.HOR_DIA = auxdia;
                        hortemp.HOR_HORA = auxhora;
                        db.HORARIO.Add(hortemp);
                        db.SaveChanges();
                        ViewData[dat] = "Se ingreso la materia";
                        ViewBag.ID_MATERIA = new SelectList(db.MATERIA, "ID_MATERIA", "MAT_COD", matemp.ID_MATERIA);
                        return View("HorarioDesp");
                    }
            }
            //ViewBag.Alert = "Lo sentimos, esta solicitud no existe.";
            ViewData[dat] = "No se pudo ingresar";
            ViewBag.ID_MATERIA = new SelectList(db.MATERIA, "ID_MATERIA", "MAT_COD", matemp.ID_MATERIA);
            return View("HorarioDesp");

        }
        #endregion

        private ActionResult PresionaBotondef1(string dia, DateTime hora, string dat,string dat1)
        {
            //Validacion

            List<HORARIO> lsth = db.HORARIO.ToList();
            List<MATERIA> lstm = db.MATERIA.ToList();

            List<MATERIA> mate = new List<MATERIA>();
            List<int> matid = new List<int>();
            List<HORARIO> lsthemp = new List<HORARIO>();
            List<MATERIA> lstmprof = new List<MATERIA>();
            List<HORARIO> lstmproftemp = new List<HORARIO>();

            PROFESOR proftemp = new PROFESOR();
            HORARIO hortemp = new HORARIO();
            HORARIO hortemp2 = new HORARIO();
            List<HORARIO> lsthemp2 = new List<HORARIO>();

            List<HORARIO> horasp=new List<HORARIO>();
            //Materia ingresada en el combo
            MATERIA matemp = db.MATERIA.Find(idtemp);

            string auxdia = dia;
            DateTime auxhora = hora;
            bool val = false;


            for (int i = 0; i < lstm.Count(); i++)
            {
                if (lstm[i].MAT_GRADO == matemp.MAT_GRADO && lstm[i].ID_MATERIA != matemp.ID_MATERIA)
                {
                    val = true;

                    //La materia tiene dia y hora disponible
                    string grad = lstm[i].MAT_GRADO;
                    mate = db.MATERIA.Where(mat => mat.MAT_GRADO == grad).ToList();
                    matid = mate.Select(mat => mat.ID_MATERIA).ToList();
                    lsthemp = db.HORARIO.Where(hor => matid.Contains(hor.ID_MATERIA) && hor.HOR_DIA == auxdia && hor.HOR_HORA == auxhora).ToList();


                    int idprof = matemp.ID_PROFESOR;
                    var materiap = db.MATERIA.Where(mat => mat.ID_PROFESOR == idprof).ToList();
                    var matpid = materiap.Select(mat => mat.ID_MATERIA).ToList();

                    lstmproftemp = db.HORARIO.Where(hor => matpid.Contains(hor.ID_MATERIA) && hor.HOR_DIA == auxdia && hor.HOR_HORA == auxhora).ToList();
                    if (lstmproftemp.Count == 0 && lsthemp.Count == 0)
                    {
                        hortemp.ID_MATERIA = matemp.ID_MATERIA;
                        hortemp.HOR_DIA = auxdia;
                        hortemp.HOR_HORA = auxhora;
                        db.HORARIO.Add(hortemp);
                        db.SaveChanges();
                        ViewData[dat] = "Se ingreso la materia";
                        ViewData[dat1] = "blue";
                        //horasp = db.HORARIO.Where(hor => hor.ID_MATERIA == idtemp).ToList();
                        //Llenar horas completadas
                        List<MATERIA> mat3 = db.MATERIA.Where(ma => ma.MAT_GRADO ==grads).ToList();
                        List<HORARIO> hora3 = new List<HORARIO>();
                        for (int x = 0; x < mat3.Count; x++)
                        {
                            int aux = mat3[x].ID_MATERIA;
                            List<HORARIO> horaux = db.HORARIO.Where(hor => hor.ID_MATERIA == aux).ToList();
                            for (int j = 0; j < horaux.Count; j++)
                            {
                                hora3.Add(horaux[j]);
                            }
                        }
                        Pintar(hora3);
                        //Grados en base a materia Ingresada
                        List<SelectListItem> lstgrad = new List<SelectListItem>();
                        List<string> lst2 = db.MATERIA.Where(ma => ma.MAT_NOMBRE == mats).Select(ma => ma.MAT_GRADO).ToList();
                        for (int k = 0; k < lst2.Count; k++)
                        {
                            lstgrad.Add(new SelectListItem() { Text = lst2[k], Value = lst2[k] });
                        }


                        //Llenamos de nuevo el combo de materias
                        List<string> lst1 = db.MATERIA.Select(ma => ma.MAT_NOMBRE).Distinct().ToList();
                        List<SelectListItem> lst = new List<SelectListItem>();


                        for (int r = 0; r < lst1.Count; r++)
                        {
                            lst.Add(new SelectListItem() { Text = lst1[r], Value = lst1[r] });
                        }
                        ViewBag.ID_MATERIA = new SelectList(lst, "Text", "Value", mats);
                        ViewBag.CB_GRADO = new SelectList(lstgrad, "Text", "Value", grads);
                        //Mantener detalles del profesor
                        if (nomdt != "" && graddt != "" && matdt != "")
                        {
                            ViewData["ProfNombre"] = nomdt;
                            ViewData["Mat"] = matdt;
                            ViewData["Grado"] = graddt;
                        }
                        return View("HorarioDesp");
                    }

                }

            }
            if (val == false)//Si la materia es nueva
            {
                int idprof = matemp.ID_PROFESOR;
                var materiap = db.MATERIA.Where(mat => mat.ID_PROFESOR == idprof).ToList();
                var matpid = materiap.Select(mat => mat.ID_MATERIA).ToList();

                lstmproftemp = db.HORARIO.Where(hor => matpid.Contains(hor.ID_MATERIA) && hor.HOR_DIA == auxdia && hor.HOR_HORA == auxhora).ToList();
                if (lstmproftemp.Count == 0)
                {
                    hortemp.ID_MATERIA = matemp.ID_MATERIA;
                    hortemp.HOR_DIA = auxdia;
                    hortemp.HOR_HORA = auxhora;
                    db.HORARIO.Add(hortemp);
                    db.SaveChanges();
                    ViewData[dat] = "Se ingreso la materia";
                    ViewData[dat1] = "blue";
                    //horasp = db.HORARIO.Where(hor => hor.ID_MATERIA == idtemp).ToList();
                    //Llenar horas de todos los horarios
                    List<MATERIA> mat4 = db.MATERIA.Where(ma => ma.MAT_GRADO == grads).ToList();
                    List<HORARIO> hora4 = new List<HORARIO>();
                    for (int x = 0; x < mat4.Count; x++)
                    {
                        int aux = mat4[x].ID_MATERIA;
                        List<HORARIO> horaux = db.HORARIO.Where(hor => hor.ID_MATERIA == aux).ToList();
                        for (int j = 0; j < horaux.Count; j++)
                        {
                            hora4.Add(horaux[j]);
                        }
                    }
                    Pintar(hora4);
                    //Grados en base a materia Ingresada
                    List<SelectListItem> lstgrad = new List<SelectListItem>();
                    List<string> lst2 = db.MATERIA.Where(ma => ma.MAT_NOMBRE == mats).Select(ma => ma.MAT_GRADO).ToList();
                    for (int k = 0; k < lst2.Count; k++)
                    {
                        lstgrad.Add(new SelectListItem() { Text = lst2[k], Value = lst2[k] });
                    }


                    //Llenamos de nuevo el combo de materias
                    List<string> lst1 = db.MATERIA.Select(ma => ma.MAT_NOMBRE).Distinct().ToList();
                    List<SelectListItem> lst = new List<SelectListItem>();


                    for (int r = 0; r < lst1.Count; r++)
                    {
                        lst.Add(new SelectListItem() { Text = lst1[r], Value = lst1[r] });
                    }
                    ViewBag.ID_MATERIA = new SelectList(lst, "Text", "Value", mats);
                    ViewBag.CB_GRADO = new SelectList(lstgrad, "Text", "Value", grads);
                    //Mantener detalles del profesor
                    if (nomdt != "" && graddt != "" && matdt != "")
                    {
                        ViewData["ProfNombre"] = nomdt;
                        ViewData["Mat"] = matdt;
                        ViewData["Grado"] = graddt;
                    }
                    return View("HorarioDesp");
                }
            }
            //ViewBag.Alert = "Lo sentimos, esta solicitud no existe.";
            ViewData[dat] = "No se pudo ingresar";
            ViewData[dat1] = "orange";
            //horasp = db.HORARIO.Where(hor => hor.ID_MATERIA == idtemp).ToList();
            List<MATERIA> mat2 = db.MATERIA.Where(ma => ma.MAT_GRADO == grads).ToList();
            List<HORARIO> hora2 = new List<HORARIO>();
            for (int x = 0; x < mat2.Count; x++)
            {
                int aux = mat2[x].ID_MATERIA;
                List<HORARIO> horaux = db.HORARIO.Where(hor => hor.ID_MATERIA == aux).ToList();
                for (int j = 0; j < horaux.Count; j++)
                {
                    hora2.Add(horaux[j]);
                }
            }
            Pintar(hora2);
            //Grados en base a materia Ingresada
            List<SelectListItem> lstgrad1 = new List<SelectListItem>();
            List<string> lst3 = db.MATERIA.Where(ma => ma.MAT_NOMBRE == mats).Select(ma => ma.MAT_GRADO).ToList();
            for (int k = 0; k < lst3.Count; k++)
            {
                lstgrad1.Add(new SelectListItem() { Text = lst3[k], Value = lst3[k] });
            }


            //Llenamos de nuevo el combo de materias
            List<string> lstm1 = db.MATERIA.Select(ma => ma.MAT_NOMBRE).Distinct().ToList();
            List<SelectListItem> lst11 = new List<SelectListItem>();


            for (int r = 0; r < lstm1.Count; r++)
            {
                lst11.Add(new SelectListItem() { Text = lstm1[r], Value = lstm1[r] });
            }
            ViewBag.ID_MATERIA = new SelectList(lst11, "Text", "Value", mats);
            ViewBag.CB_GRADO = new SelectList(lstgrad1, "Text", "Value", grads);
            //Mantener detalles del profesor
            if (nomdt != "" && graddt != "" && matdt != "")
            {
                ViewData["ProfNombre"] = nomdt;
                ViewData["Mat"] = matdt;
                ViewData["Grado"] = graddt;
            }
            return View("HorarioDesp");

        }

        // GET: HORARIOs
        public ActionResult Index()
        {
            var hORARIO = db.HORARIO.Include(h => h.MATERIA);
            return View(hORARIO.ToList());
        }

        // GET: HORARIOs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HORARIO hORARIO = db.HORARIO.Find(id);
            if (hORARIO == null)
            {
                return HttpNotFound();
            }
            return View(hORARIO);
        }

        // GET: HORARIOs/Create
        public ActionResult Create()
        {
            ViewBag.ID_MATERIA = new SelectList(db.MATERIA, "ID_MATERIA", "MAT_COD");
            return View();
        }

        // POST: HORARIOs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create([Bind(Include = "ID_HORARIO,ID_MATERIA,HOR_DIA,HOR_HORA")] HORARIO hORARIO)
        {
            
            if (ModelState.IsValid)
            {
                db.HORARIO.Add(hORARIO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_MATERIA = new SelectList(db.MATERIA, "ID_MATERIA", "MAT_COD", hORARIO.ID_MATERIA);
            return View(hORARIO);
        }

        // GET: HORARIOs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HORARIO hORARIO = db.HORARIO.Find(id);
            if (hORARIO == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_MATERIA = new SelectList(db.MATERIA, "ID_MATERIA", "MAT_COD", hORARIO.ID_MATERIA);
            return View(hORARIO);
        }

        // POST: HORARIOs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_HORARIO,ID_MATERIA,HOR_DIA,HOR_HORA")] HORARIO hORARIO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hORARIO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_MATERIA = new SelectList(db.MATERIA, "ID_MATERIA", "MAT_COD", hORARIO.ID_MATERIA);
            return View(hORARIO);
        }

        // GET: HORARIOs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HORARIO hORARIO = db.HORARIO.Find(id);
            if (hORARIO == null)
            {
                return HttpNotFound();
            }
            return View(hORARIO);
        }

        // POST: HORARIOs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HORARIO hORARIO = db.HORARIO.Find(id);
            db.HORARIO.Remove(hORARIO);
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
