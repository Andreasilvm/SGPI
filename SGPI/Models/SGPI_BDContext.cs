using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SGPI.Models
{
    public partial class SGPI_BDContext : DbContext
    {
        public SGPI_BDContext()
        {
        }

        public SGPI_BDContext(DbContextOptions<SGPI_BDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblAsignatura> TblAsignaturas { get; set; } = null!;
        public virtual DbSet<TblEntrevistum> TblEntrevista { get; set; } = null!;
        public virtual DbSet<TblEstudiante> TblEstudiantes { get; set; } = null!;
        public virtual DbSet<TblGenero> TblGeneros { get; set; } = null!;
        public virtual DbSet<TblHomologacion> TblHomologacions { get; set; } = null!;
        public virtual DbSet<TblPago> TblPagos { get; set; } = null!;
        public virtual DbSet<TblPrograma> TblProgramas { get; set; } = null!;
        public virtual DbSet<TblProgramacion> TblProgramacions { get; set; } = null!;
        public virtual DbSet<TblRol> TblRols { get; set; } = null!;
        public virtual DbSet<TblTipoDocumento> TblTipoDocumentos { get; set; } = null!;
        public virtual DbSet<TblTipoHomolo> TblTipoHomolos { get; set; } = null!;
        public virtual DbSet<TblUsuario> TblUsuarios { get; set; } = null!;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=LAPTOP-K77E1CI5\\SQL;Database=SGPI_BD;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblAsignatura>(entity =>
            {
                entity.HasKey(e => e.Idasignatura)
                    .HasName("PK__tblAsign__2E8CCF3578745307");

                entity.ToTable("tblAsignatura");

                entity.Property(e => e.Idasignatura)
                    .ValueGeneratedNever()
                    .HasColumnName("IDAsignatura");

                entity.Property(e => e.Cod)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("cod");

                entity.Property(e => e.Credito).HasColumnName("credito");

                entity.Property(e => e.Idprograma).HasColumnName("IDPrograma");

                entity.Property(e => e.Nivel).HasColumnName("nivel");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdprogramaNavigation)
                    .WithMany(p => p.TblAsignaturas)
                    .HasForeignKey(d => d.Idprograma)
                    .HasConstraintName("FK_tblAsignatura");
            });

            modelBuilder.Entity<TblEntrevistum>(entity =>
            {
                entity.HasKey(e => e.Identrevista)
                    .HasName("PK__tblEntre__05824BE9CC7709B1");

                entity.ToTable("tblEntrevista");

                entity.Property(e => e.Identrevista)
                    .ValueGeneratedNever()
                    .HasColumnName("IDEntrevista");

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.Idestudiante).HasColumnName("IDEstudiante");

                entity.Property(e => e.Idusuario).HasColumnName("IDUsuario");

                entity.HasOne(d => d.IdestudianteNavigation)
                    .WithMany(p => p.TblEntrevista)
                    .HasForeignKey(d => d.Idestudiante)
                    .HasConstraintName("FK_tblEntrevista_Estudiante");

                entity.HasOne(d => d.IdusuarioNavigation)
                    .WithMany(p => p.TblEntrevista)
                    .HasForeignKey(d => d.Idusuario)
                    .HasConstraintName("FK_tblEntrevista_Usuario");
            });

            modelBuilder.Entity<TblEstudiante>(entity =>
            {
                entity.HasKey(e => e.Idestudiante)
                    .HasName("PK__tblEstud__908672BB84A83358");

                entity.ToTable("tblEstudiante");

                entity.Property(e => e.Idestudiante)
                    .ValueGeneratedNever()
                    .HasColumnName("IDEstudiante");

                entity.Property(e => e.Archivo)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Idpago).HasColumnName("IDpago");

                entity.Property(e => e.Idusuario).HasColumnName("IDUsuario");

                entity.HasOne(d => d.IdpagoNavigation)
                    .WithMany(p => p.TblEstudiantes)
                    .HasForeignKey(d => d.Idpago)
                    .HasConstraintName("FK_tblEstudiante_Pago");

                entity.HasOne(d => d.IdusuarioNavigation)
                    .WithMany(p => p.TblEstudiantes)
                    .HasForeignKey(d => d.Idusuario)
                    .HasConstraintName("FK_tblEstudiante_Usuario");
            });

            modelBuilder.Entity<TblGenero>(entity =>
            {
                entity.HasKey(e => e.Idgenero)
                    .HasName("PK__tblGener__40E9040F31E534A2");

                entity.ToTable("tblGenero");

                entity.Property(e => e.Idgenero).HasColumnName("IDGenero");

                entity.Property(e => e.Genero)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblHomologacion>(entity =>
            {
                entity.HasKey(e => e.Idhomologacion)
                    .HasName("PK__tblHomol__01DC9432E7B3740B");

                entity.ToTable("tblHomologacion");

                entity.Property(e => e.Idhomologacion).HasColumnName("IDHomologacion");

                entity.Property(e => e.CodHomologacion)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Idasignatura).HasColumnName("IDAsignatura");

                entity.Property(e => e.Idestudiante).HasColumnName("IDEstudiante");

                entity.Property(e => e.Idprograma).HasColumnName("IDPrograma");

                entity.Property(e => e.IdtipoHomolo).HasColumnName("IDTipoHomolo");

                entity.Property(e => e.NomAsigHomolo)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PeriodoAcademico)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdasignaturaNavigation)
                    .WithMany(p => p.TblHomologacions)
                    .HasForeignKey(d => d.Idasignatura)
                    .HasConstraintName("FK_tblHomologacion_Asignatura");

                entity.HasOne(d => d.IdestudianteNavigation)
                    .WithMany(p => p.TblHomologacions)
                    .HasForeignKey(d => d.Idestudiante)
                    .HasConstraintName("FK_tblHomologacion_Estudiante");

                entity.HasOne(d => d.IdprogramaNavigation)
                    .WithMany(p => p.TblHomologacions)
                    .HasForeignKey(d => d.Idprograma)
                    .HasConstraintName("FK_tblHomologacion_Programa");

                entity.HasOne(d => d.IdtipoHomoloNavigation)
                    .WithMany(p => p.TblHomologacions)
                    .HasForeignKey(d => d.IdtipoHomolo)
                    .HasConstraintName("FK_tblHomologacion_TipoH");
            });

            modelBuilder.Entity<TblPago>(entity =>
            {
                entity.HasKey(e => e.IdPagos)
                    .HasName("PK__tblPagos__04137C5B773B5EAE");

                entity.ToTable("tblPagos");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.Fecha).HasColumnType("date");
            });

            modelBuilder.Entity<TblPrograma>(entity =>
            {
                entity.HasKey(e => e.Idprograma)
                    .HasName("PK__tblProgr__072DB426B8DB5FC6");

                entity.ToTable("tblPrograma");

                entity.Property(e => e.Idprograma).HasColumnName("IDPrograma");

                entity.Property(e => e.Programa)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblProgramacion>(entity =>
            {
                entity.HasKey(e => e.Idprogramacion)
                    .HasName("PK__tblProgr__E8038DE4F801E5F3");

                entity.ToTable("tblProgramacion");

                entity.Property(e => e.Idprogramacion).HasColumnName("IDProgramacion");

                entity.Property(e => e.Idasignatura).HasColumnName("IDAsignatura");

                entity.Property(e => e.Idprograma).HasColumnName("IDPrograma");

                entity.Property(e => e.Idusuario).HasColumnName("IDUsuario");

                entity.Property(e => e.PeriodoAcademico)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Sala)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdasignaturaNavigation)
                    .WithMany(p => p.TblProgramacions)
                    .HasForeignKey(d => d.Idasignatura)
                    .HasConstraintName("FK_tblProgramacion_Asignatura");

                entity.HasOne(d => d.IdprogramaNavigation)
                    .WithMany(p => p.TblProgramacions)
                    .HasForeignKey(d => d.Idprograma)
                    .HasConstraintName("FK_tblProgramacion_Programa");

                entity.HasOne(d => d.IdusuarioNavigation)
                    .WithMany(p => p.TblProgramacions)
                    .HasForeignKey(d => d.Idusuario)
                    .HasConstraintName("FK_tblProgramacion_Usuario");
            });

            modelBuilder.Entity<TblRol>(entity =>
            {
                entity.HasKey(e => e.Idrol)
                    .HasName("PK__tblRol__A681ACB66500E8AC");

                entity.ToTable("tblRol");

                entity.Property(e => e.Idrol).HasColumnName("IDRol");

                entity.Property(e => e.Rol)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblTipoDocumento>(entity =>
            {
                entity.HasKey(e => e.Iddoc)
                    .HasName("PK__tblTipoD__93E3A42C990A3811");

                entity.ToTable("tblTipoDocumento");

                entity.Property(e => e.Iddoc).HasColumnName("IDDoc");

                entity.Property(e => e.TipoDocumento)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblTipoHomolo>(entity =>
            {
                entity.HasKey(e => e.IdtipoHomolo)
                    .HasName("PK__tblTipoH__89929325BCD763D7");

                entity.ToTable("tblTipoHomolo");

                entity.Property(e => e.IdtipoHomolo).HasColumnName("IDTipoHomolo");

                entity.Property(e => e.TipoHomolo)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblUsuario>(entity =>
            {
                entity.HasKey(e => e.Idusuario)
                    .HasName("PK__tblUsuar__52311169D323A7F3");

                entity.ToTable("tblUsuario");

                entity.Property(e => e.Idusuario).HasColumnName("IDUsuario");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Iddoc).HasColumnName("IDDoc");

                entity.Property(e => e.Idgenero).HasColumnName("IDGenero");

                entity.Property(e => e.Idprograma).HasColumnName("IDPrograma");

                entity.Property(e => e.Idrol).HasColumnName("IDRol");

                entity.Property(e => e.NumeroDocumento)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PrimerApellido)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PrimerNombre)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SegundoApellido)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SegundoNombre)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.VcPassword)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("vcPassword");

                entity.HasOne(d => d.IddocNavigation)
                    .WithMany(p => p.TblUsuarios)
                    .HasForeignKey(d => d.Iddoc)
                    .HasConstraintName("FK_tblUsuario_TipoDoc");

                entity.HasOne(d => d.IdgeneroNavigation)
                    .WithMany(p => p.TblUsuarios)
                    .HasForeignKey(d => d.Idgenero)
                    .HasConstraintName("FK_tblUsuario_Genero");

                entity.HasOne(d => d.IdprogramaNavigation)
                    .WithMany(p => p.TblUsuarios)
                    .HasForeignKey(d => d.Idprograma)
                    .HasConstraintName("FK_tblUsuario_Programa");

                entity.HasOne(d => d.IdrolNavigation)
                    .WithMany(p => p.TblUsuarios)
                    .HasForeignKey(d => d.Idrol)
                    .HasConstraintName("FK_tblUsuario_Rol");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
