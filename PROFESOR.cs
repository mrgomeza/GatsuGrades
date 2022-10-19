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

    public partial class PROFESOR
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PROFESOR()
        {
            this.MATERIA = new HashSet<MATERIA>();
        }
        public int ID_PROFESOR { get; set; }
        [Display(Name = "USUARIO PROFESOR")]
        [StringLength(10, ErrorMessage = "El usuario debe ser de máximo 10 caracteres")]
        [Required(ErrorMessage = "Campo Requerido")]
        public string PROF_USU { get; set; }
        [Display(Name = "ROL")]
        [Required(ErrorMessage = "Campo Requerido")]
        public int ID_TIPOU { get; set; }
        [Display(Name = "NOMBRE PROFESOR")]
        [StringLength(15, ErrorMessage = "El nombre debe ser de máximo 15 caracteres")]
        [Required(ErrorMessage = "Campo Requerido")]
        public string PROF_NOMBRE { get; set; }
        [Display(Name = "APELLIDO PROFESOR")]
        [StringLength(15, ErrorMessage = "El apellido debe ser de máximo 15 caracteres")]
        [Required(ErrorMessage = "Campo Requerido")]
        public string PROF_APELLIDO { get; set; }

        [Display(Name = "CÉDULA")]
        [Required(ErrorMessage = "Campo Requerido")]
        public string PROF_CEDULA { get; set; }
        [Display(Name = "DIRECCIÓN")]
        [StringLength(30, ErrorMessage = "La dirección debe ser de máximo 30 caracteres")]
        [Required(ErrorMessage = "Campo Requerido")]
        public string PROF_DIRECCION { get; set; }
        [Display(Name = "TELÉFONO")]
        [Required(ErrorMessage = "Campo Requerido")]
        [RegularExpression("^[0-9,$]*$",
            ErrorMessage = "Teléfono inválido")]
        public string PROF_TELF { get; set; }
        [Display(Name = "CONTRASEÑA")]
        [Required(ErrorMessage = "Campo Requerido")]
        public string PROF_PASSWORD { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MATERIA> MATERIA { get; set; }

        public virtual TIPO_USUARIO TIPO_USUARIO { get; set; }
    }
}
