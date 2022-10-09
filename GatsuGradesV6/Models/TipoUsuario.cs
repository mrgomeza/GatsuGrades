using System;
using System.Collections.Generic;

namespace GatsuGradesV6.Models
{
    public partial class TipoUsuario
    {
        public TipoUsuario()
        {
            Estudiantes = new HashSet<Estudiante>();
            Profesors = new HashSet<Profesor>();
            Representantes = new HashSet<Representante>();
        }

        public int IdTipou { get; set; }
        public string TuDescrip { get; set; } = null!;

        public virtual ICollection<Estudiante> Estudiantes { get; set; }
        public virtual ICollection<Profesor> Profesors { get; set; }
        public virtual ICollection<Representante> Representantes { get; set; }
    }
}
