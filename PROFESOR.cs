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
    using System.ComponentModel;

    public partial class PROFESOR
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PROFESOR()
        {
            this.MATERIA = new HashSet<MATERIA>();
        }


        [DisplayName("ID PROFESOR")]
        public int ID_PROFESOR { get; set; }
        [DisplayName("USUARIO")]
        public string PROF_USU { get; set; }
        [DisplayName("ID TIPO USUARIO")]
        public int ID_TIPOU { get; set; }
        [DisplayName("NOMBRE")]
        public string PROF_NOMBRE { get; set; }
        [DisplayName("APELLIDO")]
        public string PROF_APELLIDO { get; set; }
        [DisplayName("CÉDULA")]
        public string PROF_CEDULA { get; set; }
        [DisplayName("DIRECCIÓN")]
        public string PROF_DIRECCION { get; set; }
        [DisplayName("TELÉFONO")]
        public string PROF_TELF { get; set; }
        [DisplayName("CONTRASEÑA")]
        public string PROF_PASSWORD { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MATERIA> MATERIA { get; set; }
        public virtual TIPO_USUARIO TIPO_USUARIO { get; set; }
    }
}
