//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1
{
    using System;
    using System.Collections.Generic;
    
    public partial class HORARIO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HORARIO()
        {
            this.ASISTENCIA = new HashSet<ASISTENCIA>();
        }
    
        public int ID_HORARIO { get; set; }
        public string ID_MATERIA { get; set; }
        public string HOR_DIA { get; set; }
        public string HOR_HORA { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ASISTENCIA> ASISTENCIA { get; set; }
        public virtual MATERIA MATERIA { get; set; }
    }
}
