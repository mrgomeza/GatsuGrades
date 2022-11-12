using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Prueba.Modelos
{
    public class Asistencia { 
    
        [Display(Name = "ID")]
        public int ID_ESTUDIANTE { get; set; }
        [Display(Name = "NOMBRE")]
        public string EST_NOMBRE { get; set; }
        [Display(Name = "APELLIDO")]
        public string EST_APELLIDO { get; set; }
        [Display(Name = "ASISTENCIA")]
        public bool ASIS_CONF { get; set; }
    }
}