//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Prueba
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class HORARIO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HORARIO()
        {
            this.ASISTENCIA = new HashSet<ASISTENCIA>();
        }

        [Display(Name = "Id Horario")]
        public int ID_HORARIO { get; set; }
        [Display(Name = "Materia")]
        public int ID_MATERIA { get; set; }
        [Display(Name = "DIA")]
        public string HOR_DIA { get; set; }
        [Display(Name = "Hora")]
        public System.DateTime HOR_HORA { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ASISTENCIA> ASISTENCIA { get; set; }
        public virtual MATERIA MATERIA { get; set; }
    }
}
