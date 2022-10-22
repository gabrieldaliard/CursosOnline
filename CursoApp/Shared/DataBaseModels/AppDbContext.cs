using System;
using System.Collections.Generic;
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

        
        public virtual DbSet<Estados> Estados { get; set; }
        public virtual DbSet<InfoAcademia> InfoAcademia { get; set; }
        public virtual DbSet<Instructores> Instructores { get; set; }
        public virtual DbSet<Paises> Paises { get; set; }
        public virtual DbSet<PreguntasFreq> PreguntasFreqs { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        //public virtual DbSet<UsuariosCursos> UsuariosCursos { get; set; }
        public virtual DbSet<Cursos> Cursos { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Por default usamos SQl, sino lo que pasemos por parametro en el constructor.
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=DefaultConnection");
                
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<Cursos>().ToTable("Cursito"); //Se realiza para indicar que la tabla Cursos va a pasar a crearse como Cursito en SQL.

            //modelBuilder.Entity<UsuariosCursos>().ToTable("UsuariosCursos");

            base.OnModelCreating(modelBuilder);
            //modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Instructores>(entity =>
            {
                entity.Property(e => e.IdPais).HasDefaultValueSql("((1))");
                entity.Property(e => e.IdEstado).HasDefaultValueSql("((1))");

                modelBuilder.Entity<Instructores>()
                .HasOne<Estados>(s => s.Estados)
                .WithMany(ad => ad.Instructores)
                .HasForeignKey(ad => ad.IdEstado);

                modelBuilder.Entity<Instructores>()
                .HasOne<Paises>(s => s.Paises)
                .WithMany(ad => ad.Instructores)
                .HasForeignKey(ad => ad.IdPais);
                //.OnDelete(DeleteBehavior.NoAction);


                modelBuilder.Entity<Instructores>()
                .HasMany<Cursos>(s => s.Cursos)
                .WithOne(ad => ad.Instructores)
                .HasForeignKey(ad => ad.IdCurso)
                .IsRequired(false);
                
            });

            modelBuilder.Entity<Estados>(entity =>
            {

                modelBuilder.Entity<Estados>()
                .HasMany<Instructores>(s => s.Instructores)
                .WithOne(ad => ad.Estados)
                .HasForeignKey(ad => ad.IdInstructor);

                modelBuilder.Entity<Estados>()
                .HasMany<Cursos>(s => s.Cursos)
                .WithOne(ad => ad.Estados)
                .HasForeignKey(ad => ad.IdCurso);

                modelBuilder.Entity<Estados>()
                .HasMany<Usuarios>(s => s.Usuarios)
                .WithOne(ad => ad.Estados)
                .HasForeignKey(ad => ad.IdUsuario);


            });

            modelBuilder.Entity<Paises>(entity =>
            {

                modelBuilder.Entity<Paises>()
                .HasMany<Instructores>(s => s.Instructores)
                .WithOne(ad => ad.Paises)
                .HasForeignKey(ad => ad.IdInstructor);
                //.OnDelete(DeleteBehavior.NoAction);

                modelBuilder.Entity<Paises>()
                .HasMany<Usuarios>(s => s.Usuarios)
                .WithOne(ad => ad.Paises)
                .HasForeignKey(ad => ad.IdUsuario)
                ;//.OnDelete(DeleteBehavior.NoAction);


            });

            modelBuilder.Entity<Cursos>(entity =>
            {

                entity.Property(e => e.Interesados).HasDefaultValueSql("((0))");
                entity.Property(e => e.Estudiantes).HasDefaultValueSql("((0))");
                entity.Property(e => e.Destacado).HasDefaultValueSql("((0))");


                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaModificacion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                modelBuilder.Entity<Cursos>()
                .HasOne<Estados>(s => s.Estados)
                .WithMany(ad => ad.Cursos)
                .HasForeignKey(ad => ad.IdEstado);

                modelBuilder.Entity<Cursos>()
                .HasOne<Instructores>(s => s.Instructores)
                .WithMany(ad => ad.Cursos)
                .HasForeignKey(ad => ad.idInstructor)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);
                ;

                modelBuilder.Entity<Cursos>()
                .HasMany<Usuarios>(s => s.Usuarios)
                .WithMany(ad => ad.Cursos)
                 .UsingEntity<Dictionary<string, object>>(
                "UsuariosCursos",
                j => j.HasOne<Usuarios>().WithMany().OnDelete(DeleteBehavior.Cascade),
                j => j.HasOne<Cursos>().WithMany().OnDelete(DeleteBehavior.ClientCascade)
            );

                //.OnDelete(DeleteBehavior.NoAction)
                //.UsingEntity<UsuariosCursos>(); 
                ;
                
                //entity.Property(e => e.idInstructor).HasDefaultValueSql("((1))");

                entity.Property(e => e.IdEstado).HasDefaultValueSql("((1))");

            });


            modelBuilder.Entity<Usuarios>(entity =>
            {

                entity.Property(e => e.FechaInscripcion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
               
                entity.Property(e => e.UltimoAcceso)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                modelBuilder.Entity<Usuarios>()
                .HasOne<Paises>(s => s.Paises)
                .WithMany(ad => ad.Usuarios)
                .HasForeignKey(ad => ad.IdPais)
                .OnDelete(DeleteBehavior.NoAction);

                //Tengo 1 pais con muchos usuarios donde la fk desde usuarios es IdPais

                //modelBuilder.Entity<Usuarios>()
                //.HasMany<Cursos>(s => s.Cursos)
                //.WithMany(ad => ad.Usuarios)
                //;

                //modelBuilder.Entity<Usuarios>()
                //.HasMany<Cursos>(s => s.Cursos)
                //.WithMany(ad => ad.Usuarios)
                // .UsingEntity<Dictionary<string, object>>(
                //"UsuariosCursos",
                //j => j.HasOne<Cursos>().WithMany().OnDelete(DeleteBehavior.Cascade),
                //j => j.HasOne<Usuarios>().WithMany().OnDelete(DeleteBehavior.ClientCascade)
                //);

            });
            

            modelBuilder.Entity<Estados>().HasData(new Estados { IdEstado = 1, Descripcion = "Nuevo" });
            modelBuilder.Entity<Estados>().HasData(new Estados { IdEstado = 2, Descripcion = "Activo" });
            modelBuilder.Entity<Estados>().HasData(new Estados { IdEstado = 3, Descripcion = "Inactivo" });
            modelBuilder.Entity<Estados>().HasData(new Estados { IdEstado = 4, Descripcion = "Suspendido" });
            modelBuilder.Entity<Estados>().HasData(new Estados { IdEstado = 5, Descripcion = "Baja" });

            modelBuilder.Entity<Paises>().HasData(new Paises { IdPais = 1, Descripcion = "Argentina" });
            modelBuilder.Entity<Paises>().HasData(new Paises { IdPais = 2, Descripcion = "Germany" });
            modelBuilder.Entity<Paises>().HasData(new Paises { IdPais = 3, Descripcion = "Netherlands" });
            modelBuilder.Entity<Paises>().HasData(new Paises { IdPais = 4, Descripcion = "USA" });
            modelBuilder.Entity<Paises>().HasData(new Paises { IdPais = 5, Descripcion = "Japan" });
            modelBuilder.Entity<Paises>().HasData(new Paises { IdPais = 6, Descripcion = "China" });
            modelBuilder.Entity<Paises>().HasData(new Paises { IdPais = 7, Descripcion = "UK" });
            modelBuilder.Entity<Paises>().HasData(new Paises { IdPais = 8, Descripcion = "France" });
            modelBuilder.Entity<Paises>().HasData(new Paises { IdPais = 9, Descripcion = "Brazil" });

            modelBuilder.Entity<Instructores>().HasData(new Instructores { IdInstructor = 1, Nombre = "Florencia", Apellido = "Diaz", IdPais = 1, Descripcion = "Florcita" });
            modelBuilder.Entity<Instructores>().HasData(new Instructores { IdInstructor = 2, Nombre = "DummyNombre1", Apellido = "DummyApellido1", IdPais = 1, Descripcion = "DummyDescripcion1" });
            modelBuilder.Entity<Instructores>().HasData(new Instructores { IdInstructor = 3, Nombre = "DummyNombre2", Apellido = "DummyApellido2", IdPais = 2, Descripcion = "DummyDescripcion2" });
            modelBuilder.Entity<Instructores>().HasData(new Instructores { IdInstructor = 4, Nombre = "DummyNombre3", Apellido = "DummyApellido3", IdPais = 2,  Descripcion = "DummyDescripcion3" });

            modelBuilder.Entity<Usuarios>().HasData(new Usuarios { IdUsuario = 1, Apellido = "DummyApellido1", Nombre = "DummyNombre1", IdPais = 1, Email = "DummyNombre1.DummyApellido1@false.com.ar" });
            modelBuilder.Entity<Usuarios>().HasData(new Usuarios { IdUsuario = 2, Apellido = "DummyApellido2", IdPais = 1, Email = "DummyNombre1@false.com.ar" });

            modelBuilder.Entity<Cursos>().HasData(new Cursos { IdCurso = 1, idInstructor = 1, Titulo = "Curso de Pan Dulce", IdEstado = 1  });
            modelBuilder.Entity<Cursos>().HasData(new Cursos { IdCurso = 2, idInstructor = 2, Titulo = "Curso de Pan Salado", IdEstado = 1 });


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
