﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class GatsuGradesv6Entities : DbContext
    {
        public GatsuGradesv6Entities()
            : base("name=GatsuGradesv6Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ANO_LECTIVO> ANO_LECTIVO { get; set; }
        public virtual DbSet<ASISTENCIA> ASISTENCIA { get; set; }
        public virtual DbSet<ESTUDIANTE> ESTUDIANTE { get; set; }
        public virtual DbSet<HORARIO> HORARIO { get; set; }
        public virtual DbSet<MATERIA> MATERIA { get; set; }
        public virtual DbSet<NOTA> NOTA { get; set; }
        public virtual DbSet<PROFESOR> PROFESOR { get; set; }
        public virtual DbSet<REPRESENTANTE> REPRESENTANTE { get; set; }
        public virtual DbSet<TIPO_USUARIO> TIPO_USUARIO { get; set; }
    
        public virtual int sp_RegistrarEstudiante(Nullable<int> iD_EST, string eST_USU, Nullable<int> iD_REP, Nullable<int> iD_TIPOU, string eST_NOMBRE, string eST_APELLIDO, string eST_CEDULA, Nullable<System.DateTime> eST_FECHANAC, string eST_PASSWORD, ObjectParameter rEGISTRADO, ObjectParameter mENSAJE)
        {
            var iD_ESTParameter = iD_EST.HasValue ?
                new ObjectParameter("ID_EST", iD_EST) :
                new ObjectParameter("ID_EST", typeof(int));
    
            var eST_USUParameter = eST_USU != null ?
                new ObjectParameter("EST_USU", eST_USU) :
                new ObjectParameter("EST_USU", typeof(string));
    
            var iD_REPParameter = iD_REP.HasValue ?
                new ObjectParameter("ID_REP", iD_REP) :
                new ObjectParameter("ID_REP", typeof(int));
    
            var iD_TIPOUParameter = iD_TIPOU.HasValue ?
                new ObjectParameter("ID_TIPOU", iD_TIPOU) :
                new ObjectParameter("ID_TIPOU", typeof(int));
    
            var eST_NOMBREParameter = eST_NOMBRE != null ?
                new ObjectParameter("EST_NOMBRE", eST_NOMBRE) :
                new ObjectParameter("EST_NOMBRE", typeof(string));
    
            var eST_APELLIDOParameter = eST_APELLIDO != null ?
                new ObjectParameter("EST_APELLIDO", eST_APELLIDO) :
                new ObjectParameter("EST_APELLIDO", typeof(string));
    
            var eST_CEDULAParameter = eST_CEDULA != null ?
                new ObjectParameter("EST_CEDULA", eST_CEDULA) :
                new ObjectParameter("EST_CEDULA", typeof(string));
    
            var eST_FECHANACParameter = eST_FECHANAC.HasValue ?
                new ObjectParameter("EST_FECHANAC", eST_FECHANAC) :
                new ObjectParameter("EST_FECHANAC", typeof(System.DateTime));
    
            var eST_PASSWORDParameter = eST_PASSWORD != null ?
                new ObjectParameter("EST_PASSWORD", eST_PASSWORD) :
                new ObjectParameter("EST_PASSWORD", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_RegistrarEstudiante", iD_ESTParameter, eST_USUParameter, iD_REPParameter, iD_TIPOUParameter, eST_NOMBREParameter, eST_APELLIDOParameter, eST_CEDULAParameter, eST_FECHANACParameter, eST_PASSWORDParameter, rEGISTRADO, mENSAJE);
        }
    
        public virtual ObjectResult<Nullable<int>> sp_ValidarEstudiante(string eST_USU, string eST_PASSWORD, ObjectParameter rEGISTRADO, ObjectParameter mENSAJE)
        {
            var eST_USUParameter = eST_USU != null ?
                new ObjectParameter("EST_USU", eST_USU) :
                new ObjectParameter("EST_USU", typeof(string));
    
            var eST_PASSWORDParameter = eST_PASSWORD != null ?
                new ObjectParameter("EST_PASSWORD", eST_PASSWORD) :
                new ObjectParameter("EST_PASSWORD", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("sp_ValidarEstudiante", eST_USUParameter, eST_PASSWORDParameter, rEGISTRADO, mENSAJE);
        }
    
        public virtual ObjectResult<Nullable<int>> ValidarEstudiante_SP(string eST_USU, string eST_PASSWORD)
        {
            var eST_USUParameter = eST_USU != null ?
                new ObjectParameter("EST_USU", eST_USU) :
                new ObjectParameter("EST_USU", typeof(string));
    
            var eST_PASSWORDParameter = eST_PASSWORD != null ?
                new ObjectParameter("EST_PASSWORD", eST_PASSWORD) :
                new ObjectParameter("EST_PASSWORD", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("ValidarEstudiante_SP", eST_USUParameter, eST_PASSWORDParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> ValidarEstudiante(string eST_USU, string eST_PASSWORD)
        {
            var eST_USUParameter = eST_USU != null ?
                new ObjectParameter("EST_USU", eST_USU) :
                new ObjectParameter("EST_USU", typeof(string));
    
            var eST_PASSWORDParameter = eST_PASSWORD != null ?
                new ObjectParameter("EST_PASSWORD", eST_PASSWORD) :
                new ObjectParameter("EST_PASSWORD", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("ValidarEstudiante", eST_USUParameter, eST_PASSWORDParameter);
        }
    }
}
