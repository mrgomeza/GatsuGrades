using System;
using System.Collections.Generic;

namespace GatsuGradesV5.Models
{
    public partial class Asistencium
    {
        public int IdAsis { get; set; }
        public int IdHorario { get; set; }
        public int IdEstudiante { get; set; }
        public DateTime AsisFecha { get; set; }
        public string AsisConf { get; set; } = null!;

        public virtual Estudiante IdEstudianteNavigation { get; set; } = null!;
        public virtual Horario IdHorarioNavigation { get; set; } = null!;
    }
}
