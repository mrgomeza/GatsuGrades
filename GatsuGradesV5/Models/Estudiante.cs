using System;
using System.Collections.Generic;

namespace GatsuGradesV5.Models
{
    public partial class Estudiante
    {
        public Estudiante()
        {
            Asistencia = new HashSet<Asistencium>();
            Nota = new HashSet<Notum>();
        }

        public int IdEstudiante { get; set; }
        public string EstUsu { get; set; } = null!;
        public int IdRep { get; set; }
        public int IdTipou { get; set; }
        public string EstNombre { get; set; } = null!;
        public string EstApellido { get; set; } = null!;
        public string EstCedula { get; set; } = null!;
        public DateTime EstFechanac { get; set; }
        public string EstPassword { get; set; } = null!;

        public virtual Representante IdRepNavigation { get; set; } = null!;
        public virtual TipoUsuario IdTipouNavigation { get; set; } = null!;
        public virtual ICollection<Asistencium> Asistencia { get; set; }
        public virtual ICollection<Notum> Nota { get; set; }
    }
}
