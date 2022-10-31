using System;
using System.Collections.Generic;  

namespace GatsuGradesV5.Models
{
    public partial class AnoLectivo
    {
        public AnoLectivo()
        {
            Nota = new HashSet<Notum>();
        }

        public int IdAno { get; set; }
        public string AnoDescrip { get; set; } = null!;

        public virtual ICollection<Notum> Nota { get; set; }
    }
}
