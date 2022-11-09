using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prueba.Modelos
{
    public class Asistencia
    {
        public int ID_ESTUDIANTE { get; set; }
        public string EST_NOMBRE { get; set; }
        public string EST_APELLIDO { get; set; }
        public bool ASIS_CONF { get; set; }
    }
}