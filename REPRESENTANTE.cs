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

    public partial class REPRESENTANTE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public REPRESENTANTE()
        {
            this.ESTUDIANTE = new HashSet<ESTUDIANTE>();
        }

        [Display(Name = "ID Representante")]
        public int ID_REP { get; set; }
        [Display(Name = "Usuario")]
        public string REP_USU { get; set; }
        [Display(Name = "Tipo Usuario")]
        public int ID_TIPOU { get; set; }
        [Display(Name = "Nombre")]
        public string REP_NOMBRE { get; set; }
        [Display(Name = "Apellido")]
        public string REP_APELLIDO { get; set; }
        [Display(Name = "CI")]
        public string REP_CEDULA { get; set; }
        [Display(Name = "Dirección")]
        public string REP_DIRECCION { get; set; }
        [Display(Name = "Teléfono")]
        public string REP_TELEFONO { get; set; }
        [Display(Name = "Contraseña")]
        public string REP_PASSWORD { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ESTUDIANTE> ESTUDIANTE { get; set; }
        public virtual TIPO_USUARIO TIPO_USUARIO { get; set; }
    }
}
