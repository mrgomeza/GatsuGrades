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

    public partial class ESTUDIANTE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ESTUDIANTE()
        {
            this.ASISTENCIA = new HashSet<ASISTENCIA>();
            this.NOTA = new HashSet<NOTA>();
        }

        [DisplayName("ID ESTUDIANTE")]
        public int ID_ESTUDIANTE { get; set; }
        [DisplayName("USUARIO")]
        public string EST_USU { get; set; }
        [DisplayName("ID REPRESENTANTE")]
        public int ID_REP { get; set; }
        [DisplayName("TIPO USUARIO")]
        public int ID_TIPOU { get; set; }
        [DisplayName("NOMBRE")]
        public string EST_NOMBRE { get; set; }
        [DisplayName("APELLIDO")]
        public string EST_APELLIDO { get; set; }
        [DisplayName("CEDULA")]
        public string EST_CEDULA { get; set; }
        [DisplayName("FECHA NACIMIENTO")]
        public System.DateTime EST_FECHANAC { get; set; }
        [DisplayName("CONTRASEÑA")]
        public string EST_PASSWORD { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ASISTENCIA> ASISTENCIA { get; set; }
        public virtual REPRESENTANTE REPRESENTANTE { get; set; }
        public virtual TIPO_USUARIO TIPO_USUARIO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NOTA> NOTA { get; set; }
    }
}
