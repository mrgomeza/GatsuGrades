using System;
using System.Collections.Generic;

namespace GatsuGradesV5.Models
{
    public partial class Notum
    {
        public int IdNota { get; set; }
        public int IdMateria { get; set; }
        public int IdEstudiante { get; set; }
        public int IdAno { get; set; }
        public float? Np1 { get; set; }
        public float? Np2 { get; set; }
        public float? Np3 { get; set; }
        public float? Eq1 { get; set; }
        public float? Q1 { get; set; }
        public float? Np4 { get; set; }
        public float? Np5 { get; set; }
        public float? Np6 { get; set; }
        public float? Eq2 { get; set; }
        public float? Q2 { get; set; }
        public float? Final { get; set; }

        public virtual AnoLectivo IdAnoNavigation { get; set; } = null!;
        public virtual Estudiante IdEstudianteNavigation { get; set; } = null!;
        public virtual Materium IdMateriaNavigation { get; set; } = null!;
    }
}
