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
    
    public partial class MATERIA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MATERIA()
        {
            this.HORARIO = new HashSet<HORARIO>();
            this.NOTA = new HashSet<NOTA>();
        }
    
        public int ID_MATERIA { get; set; }
        public string MAT_COD { get; set; }
        public int ID_PROFESOR { get; set; }
        public string MAT_NOMBRE { get; set; }
        public string MAT_GRADO { get; set; }
        public string MAT_PARALELO { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HORARIO> HORARIO { get; set; }
        public virtual PROFESOR PROFESOR { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NOTA> NOTA { get; set; }
    }
}
