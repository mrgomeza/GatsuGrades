using System;
using System.Collections.Generic;

namespace GatsuGradesV6.Models
{
    public partial class Materium
    {
        public Materium()
        {
            Horarios = new HashSet<Horario>();
            Nota = new HashSet<Notum>();
        }

        public int IdMateria { get; set; }
        public string MatCod { get; set; } = null!;
        public int IdProfesor { get; set; }
        public string MatNombre { get; set; } = null!;
        public string MatGrado { get; set; } = null!;
        public string MatParalelo { get; set; } = null!;

        public virtual Profesor IdProfesorNavigation { get; set; } = null!;
        public virtual ICollection<Horario> Horarios { get; set; }
        public virtual ICollection<Notum> Nota { get; set; }
    }
}
