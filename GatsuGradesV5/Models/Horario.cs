using System;
using System.Collections.Generic;

namespace GatsuGradesV5.Models
{
    public partial class Horario
    {
        public Horario()
        {
            Asistencia = new HashSet<Asistencium>();
        }

        public int IdHorario { get; set; }
        public int IdMateria { get; set; }
        public string HorDia { get; set; } = null!;
        public DateTime HorHora { get; set; }

        public virtual Materium IdMateriaNavigation { get; set; } = null!;
        public virtual ICollection<Asistencium> Asistencia { get; set; }
    }
}
