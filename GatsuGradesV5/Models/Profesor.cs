using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace GatsuGradesV5.Models
{
    public partial class Profesor
    {
        public Profesor()
        {
            Materia = new List<Materium>();
        }

        public int IdProfesor { get; set; }
        public string ProfUsu { get; set; } = null!;
        public int IdTipou { get; set; }
        public string ProfNombre { get; set; } = null!;
        public string ProfApellido { get; set; } = null!;
        public string ProfCedula { get; set; } = null!;
        public string ProfDireccion { get; set; } = null!;
        public string ProfTelf { get; set; } = null!;
        public string ProfPassword { get; set; } = null!;

        
        public virtual List<Materium> Materia { get; set; }
    }
}
