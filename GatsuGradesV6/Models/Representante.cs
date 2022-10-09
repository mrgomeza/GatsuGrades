using System;
using System.Collections.Generic;

namespace GatsuGradesV6.Models
{
    public partial class Representante
    {
        public Representante()
        {
            Estudiantes = new HashSet<Estudiante>();
        }

        public int IdRep { get; set; }
        public string RepUsu { get; set; } = null!;
        public int IdTipou { get; set; }
        public string RepNombre { get; set; } = null!;
        public string RepApellido { get; set; } = null!;
        public string RepCedula { get; set; } = null!;
        public string RepDireccion { get; set; } = null!;
        public string RepTelefono { get; set; } = null!;
        public string RepPassword { get; set; } = null!;

        public virtual TipoUsuario IdTipouNavigation { get; set; } = null!;
        public virtual ICollection<Estudiante> Estudiantes { get; set; }
    }
}
