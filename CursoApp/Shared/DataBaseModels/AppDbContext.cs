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

            modelBuilder.Entity<Cursos>().ToTable("Cursos"); 

            base.OnModelCreating(modelBuilder);
            //modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");


            modelBuilder.Entity<Cursos>(entity =>
            {

                //entity.HasOne(d => d.IdEstadoNavigation)
                //    .WithOne(p => p.Cursos)
                //    .HasForeignKey(d => d.IdEstado)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_Cursos_Estados");

                entity.Property(e => e.Estudiantes).HasDefaultValueSql("((0))");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                //entity.Property(e => e.IdEstado).HasDefaultValueSql("((1))");

                entity.Property(e => e.Interesados).HasDefaultValueSql("((0))");

            });


            modelBuilder.Entity<Usuarios>(entity =>
            {

                entity.Property(e => e.FechaInscripcion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
               
                entity.Property(e => e.UltimoAcceso)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });


            modelBuilder.Entity<Estados>(entity =>
            {
                modelBuilder.Entity<Estados>().HasData(new Estados { IdEstado = 1, Descripcion = "Nuevo" });
                modelBuilder.Entity<Estados>().HasData(new Estados { IdEstado = 2, Descripcion = "Activo" });
                modelBuilder.Entity<Estados>().HasData(new Estados { IdEstado = 3, Descripcion = "Inactivo" });
                modelBuilder.Entity<Estados>().HasData(new Estados { IdEstado = 4, Descripcion = "Suspendido" });
                modelBuilder.Entity<Estados>().HasData(new Estados { IdEstado = 5, Descripcion = "Baja" });
            });

            modelBuilder.Entity<Instructores>(entity =>
            {
                modelBuilder.Entity<Instructores>().HasData(new Instructores { IdInstructor = 1, Nombre = "Florencia", Apellido = "Diaz", IdPais = 1, Descripcion = "Florcita" });
                modelBuilder.Entity<Instructores>().HasData(new Instructores { IdInstructor = 2, Nombre = "Test", Apellido = "Dummy", IdPais = 6, Descripcion = "DescripcionDummy" });
            });

            //seed categories
            modelBuilder.Entity<Paises>().HasData(new Paises { IdPais = 1, Descripcion = "Argentina" });
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
