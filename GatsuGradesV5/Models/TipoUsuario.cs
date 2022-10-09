using System;
using System.Collections.Generic;

namespace GatsuGradesV5.Models
{
    public partial class TipoUsuario
    {
        public TipoUsuario()
        {
            Estudiantes = new HashSet<Estudiante>();
            Profesors = new List<Profesor>();
            Representantes = new HashSet<Representante>();
        }

        public int IdTipou { get; set; }
        public string TuDescrip { get; set; } = null!;

        public virtual ICollection<Estudiante> Estudiantes { get; set; }
        public virtual List<Profesor> Profesors { get; set; }
        public virtual ICollection<Representante> Representantes { get; set; }
    }
}
