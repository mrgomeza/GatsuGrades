using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GatsuGradesV5.Models
{
    public partial class GatsuGradesv6Context : DbContext
    {
        public GatsuGradesv6Context()
        {
        }

        public GatsuGradesv6Context(DbContextOptions<GatsuGradesv6Context> options)
            : base(options)
        {
        }

        public virtual DbSet<AnoLectivo> AnoLectivos { get; set; } = null!;
        public virtual DbSet<Asistencium> Asistencia { get; set; } = null!;
        public virtual DbSet<Estudiante> Estudiantes { get; set; } = null!;
        public virtual DbSet<Horario> Horarios { get; set; } = null!;
        public virtual DbSet<Materium> Materia { get; set; } = null!;
        public virtual DbSet<Notum> Nota { get; set; } = null!;
        public virtual DbSet<Profesor> Profesors { get; set; } = null!;
        public virtual DbSet<Representante> Representantes { get; set; } = null!;
        public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-7E26GCB9\\SQLSERVER_NQ;Database=GatsuGradesv6;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnoLectivo>(entity =>
            {
                entity.HasKey(e => e.IdAno)
                    .IsClustered(false);

                entity.ToTable("ANO_LECTIVO");

                entity.Property(e => e.IdAno)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_ANO");

                entity.Property(e => e.AnoDescrip)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("ANO_DESCRIP");
            });

            modelBuilder.Entity<Asistencium>(entity =>
            {
                entity.HasKey(e => e.IdAsis)
                    .IsClustered(false);

                entity.ToTable("ASISTENCIA");

                entity.HasIndex(e => e.IdEstudiante, "EST_ASIS_FK");

                entity.HasIndex(e => e.IdHorario, "HOR_ASIS_FK");

                entity.Property(e => e.IdAsis).HasColumnName("ID_ASIS");

                entity.Property(e => e.AsisConf)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("ASIS_CONF");

                entity.Property(e => e.AsisFecha)
                    .HasColumnType("datetime")
                    .HasColumnName("ASIS_FECHA");

                entity.Property(e => e.IdEstudiante).HasColumnName("ID_ESTUDIANTE");

                entity.Property(e => e.IdHorario).HasColumnName("ID_HORARIO");

                entity.HasOne(d => d.IdEstudianteNavigation)
                    .WithMany(p => p.Asistencia)
                    .HasForeignKey(d => d.IdEstudiante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ASISTENC_EST_ASIS_ESTUDIAN");

                entity.HasOne(d => d.IdHorarioNavigation)
                    .WithMany(p => p.Asistencia)
                    .HasForeignKey(d => d.IdHorario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ASISTENC_HOR_ASIS_HORARIO");
            });

            modelBuilder.Entity<Estudiante>(entity =>
            {
                entity.HasKey(e => e.IdEstudiante)
                    .IsClustered(false);

                entity.ToTable("ESTUDIANTE");

                entity.HasIndex(e => e.IdRep, "REP_EST_FK");

                entity.HasIndex(e => e.IdTipou, "US_EST_FK");

                entity.Property(e => e.IdEstudiante).HasColumnName("ID_ESTUDIANTE");

                entity.Property(e => e.EstApellido)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EST_APELLIDO");

                entity.Property(e => e.EstCedula)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("EST_CEDULA");

                entity.Property(e => e.EstFechanac)
                    .HasColumnType("datetime")
                    .HasColumnName("EST_FECHANAC");

                entity.Property(e => e.EstNombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EST_NOMBRE");

                entity.Property(e => e.EstPassword)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("EST_PASSWORD");

                entity.Property(e => e.EstUsu)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("EST_USU");

                entity.Property(e => e.IdRep).HasColumnName("ID_REP");

                entity.Property(e => e.IdTipou).HasColumnName("ID_TIPOU");

                entity.HasOne(d => d.IdRepNavigation)
                    .WithMany(p => p.Estudiantes)
                    .HasForeignKey(d => d.IdRep)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ESTUDIAN_REP_EST_REPRESEN");

                entity.HasOne(d => d.IdTipouNavigation)
                    .WithMany(p => p.Estudiantes)
                    .HasForeignKey(d => d.IdTipou)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ESTUDIAN_US_EST_TIPO_USU");
            });

            modelBuilder.Entity<Horario>(entity =>
            {
                entity.HasKey(e => e.IdHorario)
                    .IsClustered(false);

                entity.ToTable("HORARIO");

                entity.HasIndex(e => e.IdMateria, "MAT_HOR_FK");

                entity.Property(e => e.IdHorario).HasColumnName("ID_HORARIO");

                entity.Property(e => e.HorDia)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("HOR_DIA");

                entity.Property(e => e.HorHora)
                    .HasColumnType("datetime")
                    .HasColumnName("HOR_HORA");

                entity.Property(e => e.IdMateria).HasColumnName("ID_MATERIA");

                entity.HasOne(d => d.IdMateriaNavigation)
                    .WithMany(p => p.Horarios)
                    .HasForeignKey(d => d.IdMateria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HORARIO_MAT_HOR_MATERIA");
            });

            modelBuilder.Entity<Materium>(entity =>
            {
                entity.HasKey(e => e.IdMateria)
                    .IsClustered(false);

                entity.ToTable("MATERIA");

                entity.HasIndex(e => e.IdProfesor, "PROF_MATERIA_FK");

                entity.Property(e => e.IdMateria)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_MATERIA");

                entity.Property(e => e.IdProfesor).HasColumnName("ID_PROFESOR");

                entity.Property(e => e.MatCod)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("MAT_COD");

                entity.Property(e => e.MatGrado)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("MAT_GRADO");

                entity.Property(e => e.MatNombre)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MAT_NOMBRE");

                entity.Property(e => e.MatParalelo)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("MAT_PARALELO");

                entity.HasOne(d => d.IdProfesorNavigation)
                    .WithMany(p => p.Materia)
                    .HasForeignKey(d => d.IdProfesor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MATERIA_PROF_MATE_PROFESOR");
            });

            modelBuilder.Entity<Notum>(entity =>
            {
                entity.HasKey(e => e.IdNota)
                    .IsClustered(false);

                entity.ToTable("NOTA");

                entity.HasIndex(e => e.IdAno, "ANO_ESCOLAR_NOT_FK");

                entity.HasIndex(e => e.IdMateria, "MATERIA_NOTA_FK");

                entity.HasIndex(e => e.IdEstudiante, "NOTA_ESTUD_FK");

                entity.Property(e => e.IdNota).HasColumnName("ID_NOTA");

                entity.Property(e => e.Eq1).HasColumnName("EQ1");

                entity.Property(e => e.Eq2).HasColumnName("EQ2");

                entity.Property(e => e.Final).HasColumnName("FINAL");

                entity.Property(e => e.IdAno).HasColumnName("ID_ANO");

                entity.Property(e => e.IdEstudiante).HasColumnName("ID_ESTUDIANTE");

                entity.Property(e => e.IdMateria).HasColumnName("ID_MATERIA");

                entity.Property(e => e.Np1).HasColumnName("NP1");

                entity.Property(e => e.Np2).HasColumnName("NP2");

                entity.Property(e => e.Np3).HasColumnName("NP3");

                entity.Property(e => e.Np4).HasColumnName("NP4");

                entity.Property(e => e.Np5).HasColumnName("NP5");

                entity.Property(e => e.Np6).HasColumnName("NP6");

                entity.HasOne(d => d.IdAnoNavigation)
                    .WithMany(p => p.Nota)
                    .HasForeignKey(d => d.IdAno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NOTA_ANO_ESCOL_ANO_LECT");

                entity.HasOne(d => d.IdEstudianteNavigation)
                    .WithMany(p => p.Nota)
                    .HasForeignKey(d => d.IdEstudiante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NOTA_NOTA_ESTU_ESTUDIAN");

                entity.HasOne(d => d.IdMateriaNavigation)
                    .WithMany(p => p.Nota)
                    .HasForeignKey(d => d.IdMateria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NOTA_MATERIA_N_MATERIA");
            });

            modelBuilder.Entity<Profesor>(entity =>
            {
                entity.HasKey(e => e.IdProfesor)
                    .IsClustered(false);

                entity.ToTable("PROFESOR");

                entity.HasIndex(e => e.IdTipou, "US_PROF_FK");

                entity.Property(e => e.IdProfesor).HasColumnName("ID_PROFESOR");

                entity.Property(e => e.IdTipou).HasColumnName("ID_TIPOU");

                entity.Property(e => e.ProfApellido)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PROF_APELLIDO");

                entity.Property(e => e.ProfCedula)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PROF_CEDULA");

                entity.Property(e => e.ProfDireccion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PROF_DIRECCION");

                entity.Property(e => e.ProfNombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PROF_NOMBRE");

                entity.Property(e => e.ProfPassword)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("PROF_PASSWORD");

                entity.Property(e => e.ProfTelf)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PROF_TELF");

                entity.Property(e => e.ProfUsu)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PROF_USU");

                entity.HasOne(d => d.IdTipouNavigation)
                    .WithMany(p => p.Profesors)
                    .HasForeignKey(d => d.IdTipou)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PROFESOR_US_PROF_TIPO_USU");
            });

            modelBuilder.Entity<Representante>(entity =>
            {
                entity.HasKey(e => e.IdRep)
                    .IsClustered(false);

                entity.ToTable("REPRESENTANTE");

                entity.HasIndex(e => e.IdTipou, "US_REP_FK");

                entity.Property(e => e.IdRep).HasColumnName("ID_REP");

                entity.Property(e => e.IdTipou).HasColumnName("ID_TIPOU");

                entity.Property(e => e.RepApellido)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("REP_APELLIDO");

                entity.Property(e => e.RepCedula)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("REP_CEDULA");

                entity.Property(e => e.RepDireccion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("REP_DIRECCION");

                entity.Property(e => e.RepNombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("REP_NOMBRE");

                entity.Property(e => e.RepPassword)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("REP_PASSWORD");

                entity.Property(e => e.RepTelefono)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("REP_TELEFONO");

                entity.Property(e => e.RepUsu)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("REP_USU");

                entity.HasOne(d => d.IdTipouNavigation)
                    .WithMany(p => p.Representantes)
                    .HasForeignKey(d => d.IdTipou)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_REPRESEN_US_REP_TIPO_USU");
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipou)
                    .IsClustered(false);

                entity.ToTable("TIPO_USUARIO");

                entity.Property(e => e.IdTipou)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_TIPOU");

                entity.Property(e => e.TuDescrip)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("TU_DESCRIP");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
