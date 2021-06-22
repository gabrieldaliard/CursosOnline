using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CursoApp.Shared.DataBaseModels
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cursos> Cursos { get; set; }
        public virtual DbSet<InfoAcademia> InfoAcademia { get; set; }
        public virtual DbSet<Instructores> Instructores { get; set; }
        public virtual DbSet<Paises> Paises { get; set; }
        public virtual DbSet<PreguntasFreq> PreguntasFreqs { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<UsuariosCursos> UsuariosCursos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=DefaultConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Cursos>(entity =>
            {
                entity.HasKey(e => e.IdCurso)
                    .HasName("PK__Cursos__085F27D65BF44E5D");

                entity.Property(e => e.Estudiantes).HasDefaultValueSql("((0))");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdEstado).HasDefaultValueSql("((1))");

                entity.Property(e => e.Interesados).HasDefaultValueSql("((0))");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.idInstructorNavigation)
                    .WithMany(p => p.Cursos)
                    .HasForeignKey(d => d.idInstructor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cursos_Instructores");
            });
                        

            modelBuilder.Entity<InfoAcademia>(entity =>
            {
                entity.HasKey(e => e.IdAcademia)
                    .HasName("PK__InfoAcad__A68DEE39E9D66049");
            });

            modelBuilder.Entity<Instructores>(entity =>
            {
                entity.HasKey(e => e.IdInstructor)
                    .HasName("PK__Instruct__10850044525376D5");

                entity.Property(e => e.Apellido).HasMaxLength(50);

                entity.Property(e => e.Descripción).IsRequired();

                entity.Property(e => e.Nombre).HasMaxLength(50);

                entity.HasOne(d => d.IdPaisNavigation)
                    .WithMany(p => p.Instructores)
                    .HasForeignKey(d => d.IdPais)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Instructores_Pais");
            });

            modelBuilder.Entity<Paises>(entity =>
            {
                entity.HasKey(e => e.IdPais)
                    .HasName("PK__Paises__FC850A7BF6A97F59");

                entity.Property(e => e.Descripcion).HasMaxLength(50);
            });

            modelBuilder.Entity<PreguntasFreq>(entity =>
            {
                entity.HasKey(e => e.IdPregunta)
                    .HasName("PK__Pregunta__754EC09EA6B9C81B");

                entity.ToTable("PreguntasFreq");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuarios__5B65BF9788D26F19");

                entity.Property(e => e.Apellido).HasMaxLength(50);

                entity.Property(e => e.Contraseña)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FechaInscripcion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Nombre).HasMaxLength(50);

                entity.Property(e => e.UltimoAcceso).HasColumnType("datetime");

                entity.HasOne(d => d.IdPaisNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdPais)
                    .HasConstraintName("FK_Usuarios_Pais");
            });

            modelBuilder.Entity<UsuariosCursos>(entity =>
            {
                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.UsuariosCursos)
                    .HasForeignKey(d => d.IdCurso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsuariosCursos_Curso");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.UsuariosCursos)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsuariosCursos_Usuario");
            });



            //seed categories
            modelBuilder.Entity<Paises>().HasData(new Paises { IdPais = 2, Descripcion = "Germany" });
            modelBuilder.Entity<Paises>().HasData(new Paises { IdPais = 3, Descripcion = "Netherlands" });
            modelBuilder.Entity<Paises>().HasData(new Paises { IdPais = 4, Descripcion = "USA" });
            modelBuilder.Entity<Paises>().HasData(new Paises { IdPais = 5, Descripcion = "Japan" });
            modelBuilder.Entity<Paises>().HasData(new Paises { IdPais = 6, Descripcion = "China" });
            modelBuilder.Entity<Paises>().HasData(new Paises { IdPais = 7, Descripcion = "UK" });
            modelBuilder.Entity<Paises>().HasData(new Paises { IdPais = 8, Descripcion = "France" });
            modelBuilder.Entity<Paises>().HasData(new Paises { IdPais = 9, Descripcion = "Brazil" });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
