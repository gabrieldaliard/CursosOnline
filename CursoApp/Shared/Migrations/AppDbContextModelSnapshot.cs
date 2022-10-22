﻿// <auto-generated />
using System;
using CursoApp.Shared.DataBaseModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CursoApp.Shared.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CursoApp.Shared.DataBaseModels.Cursos", b =>
                {
                    b.Property<int>("IdCurso")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCurso"), 1L, 1);

                    b.Property<bool>("Destacado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValueSql("((0))");

                    b.Property<int?>("Estudiantes")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("((0))");

                    b.Property<DateTime?>("FechaCreacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<DateTime?>("FechaModificacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int>("IdEstado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("((1))");

                    b.Property<int?>("Interesados")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("((0))");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<int>("idInstructor")
                        .HasColumnType("int");

                    b.Property<int>("idUsuario")
                        .HasColumnType("int");

                    b.HasKey("IdCurso");

                    b.HasIndex("IdEstado");

                    b.HasIndex("idInstructor");

                    b.ToTable("Cursos");

                    b.HasData(
                        new
                        {
                            IdCurso = 1,
                            Destacado = false,
                            IdEstado = 1,
                            Titulo = "Curso de Pan Dulce",
                            idInstructor = 1,
                            idUsuario = 0
                        },
                        new
                        {
                            IdCurso = 2,
                            Destacado = false,
                            IdEstado = 1,
                            Titulo = "Curso de Pan Salado",
                            idInstructor = 2,
                            idUsuario = 0
                        });
                });

            modelBuilder.Entity("CursoApp.Shared.DataBaseModels.Estados", b =>
                {
                    b.Property<int>("IdEstado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEstado"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<int>("IdCurso")
                        .HasColumnType("int");

                    b.Property<int>("IdInstructor")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.HasKey("IdEstado");

                    b.ToTable("Estados");

                    b.HasData(
                        new
                        {
                            IdEstado = 1,
                            Descripcion = "Nuevo",
                            IdCurso = 0,
                            IdInstructor = 0,
                            IdUsuario = 0
                        },
                        new
                        {
                            IdEstado = 2,
                            Descripcion = "Activo",
                            IdCurso = 0,
                            IdInstructor = 0,
                            IdUsuario = 0
                        },
                        new
                        {
                            IdEstado = 3,
                            Descripcion = "Inactivo",
                            IdCurso = 0,
                            IdInstructor = 0,
                            IdUsuario = 0
                        },
                        new
                        {
                            IdEstado = 4,
                            Descripcion = "Suspendido",
                            IdCurso = 0,
                            IdInstructor = 0,
                            IdUsuario = 0
                        },
                        new
                        {
                            IdEstado = 5,
                            Descripcion = "Baja",
                            IdCurso = 0,
                            IdInstructor = 0,
                            IdUsuario = 0
                        });
                });

            modelBuilder.Entity("CursoApp.Shared.DataBaseModels.InfoAcademia", b =>
                {
                    b.Property<int>("IdAcademia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdAcademia"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.HasKey("IdAcademia");

                    b.ToTable("InfoAcademia");
                });

            modelBuilder.Entity("CursoApp.Shared.DataBaseModels.Instructores", b =>
                {
                    b.Property<int>("IdInstructor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Apellido")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("IdCurso")
                        .HasColumnType("int");

                    b.Property<int>("IdEstado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("((1))");

                    b.Property<int>("IdPais")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("((1))");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdInstructor");

                    b.ToTable("Instructores");

                    b.HasData(
                        new
                        {
                            IdInstructor = 1,
                            Apellido = "Diaz",
                            Descripcion = "Florcita",
                            IdCurso = 0,
                            IdEstado = 0,
                            IdPais = 1,
                            Nombre = "Florencia"
                        },
                        new
                        {
                            IdInstructor = 2,
                            Apellido = "DummyApellido1",
                            Descripcion = "DummyDescripcion1",
                            IdCurso = 0,
                            IdEstado = 0,
                            IdPais = 1,
                            Nombre = "DummyNombre1"
                        },
                        new
                        {
                            IdInstructor = 3,
                            Apellido = "DummyApellido2",
                            Descripcion = "DummyDescripcion2",
                            IdCurso = 0,
                            IdEstado = 0,
                            IdPais = 2,
                            Nombre = "DummyNombre2"
                        },
                        new
                        {
                            IdInstructor = 4,
                            Apellido = "DummyApellido3",
                            Descripcion = "DummyDescripcion3",
                            IdCurso = 0,
                            IdEstado = 0,
                            IdPais = 2,
                            Nombre = "DummyNombre3"
                        });
                });

            modelBuilder.Entity("CursoApp.Shared.DataBaseModels.Paises", b =>
                {
                    b.Property<int>("IdPais")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPais"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdInstructor")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.HasKey("IdPais");

                    b.ToTable("Paises");

                    b.HasData(
                        new
                        {
                            IdPais = 1,
                            Descripcion = "Argentina",
                            IdInstructor = 0,
                            IdUsuario = 0
                        },
                        new
                        {
                            IdPais = 2,
                            Descripcion = "Germany",
                            IdInstructor = 0,
                            IdUsuario = 0
                        },
                        new
                        {
                            IdPais = 3,
                            Descripcion = "Netherlands",
                            IdInstructor = 0,
                            IdUsuario = 0
                        },
                        new
                        {
                            IdPais = 4,
                            Descripcion = "USA",
                            IdInstructor = 0,
                            IdUsuario = 0
                        },
                        new
                        {
                            IdPais = 5,
                            Descripcion = "Japan",
                            IdInstructor = 0,
                            IdUsuario = 0
                        },
                        new
                        {
                            IdPais = 6,
                            Descripcion = "China",
                            IdInstructor = 0,
                            IdUsuario = 0
                        },
                        new
                        {
                            IdPais = 7,
                            Descripcion = "UK",
                            IdInstructor = 0,
                            IdUsuario = 0
                        },
                        new
                        {
                            IdPais = 8,
                            Descripcion = "France",
                            IdInstructor = 0,
                            IdUsuario = 0
                        },
                        new
                        {
                            IdPais = 9,
                            Descripcion = "Brazil",
                            IdInstructor = 0,
                            IdUsuario = 0
                        });
                });

            modelBuilder.Entity("CursoApp.Shared.DataBaseModels.PreguntasFreq", b =>
                {
                    b.Property<int>("IdPregunta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPregunta"), 1L, 1);

                    b.Property<string>("Pregunta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Respuesta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPregunta");

                    b.ToTable("PreguntasFreqs");
                });

            modelBuilder.Entity("CursoApp.Shared.DataBaseModels.Usuarios", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contraseña")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("FechaInscripcion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int>("IdCursos")
                        .HasColumnType("int");

                    b.Property<int>("IdEstado")
                        .HasColumnType("int");

                    b.Property<int>("IdPais")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UltimoAcceso")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.HasKey("IdUsuario");

                    b.HasIndex("IdPais");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            IdUsuario = 1,
                            Apellido = "DummyApellido1",
                            Email = "DummyNombre1.DummyApellido1@false.com.ar",
                            IdCursos = 0,
                            IdEstado = 0,
                            IdPais = 1,
                            Nombre = "DummyNombre1"
                        },
                        new
                        {
                            IdUsuario = 2,
                            Apellido = "DummyApellido2",
                            Email = "DummyNombre1@false.com.ar",
                            IdCursos = 0,
                            IdEstado = 0,
                            IdPais = 1
                        });
                });

            modelBuilder.Entity("UsuariosCursos", b =>
                {
                    b.Property<int>("CursosIdCurso")
                        .HasColumnType("int");

                    b.Property<int>("UsuariosIdUsuario")
                        .HasColumnType("int");

                    b.HasKey("CursosIdCurso", "UsuariosIdUsuario");

                    b.HasIndex("UsuariosIdUsuario");

                    b.ToTable("UsuariosCursos");
                });

            modelBuilder.Entity("CursoApp.Shared.DataBaseModels.Cursos", b =>
                {
                    b.HasOne("CursoApp.Shared.DataBaseModels.Estados", "Estados")
                        .WithMany("Cursos")
                        .HasForeignKey("IdEstado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CursoApp.Shared.DataBaseModels.Instructores", "Instructores")
                        .WithMany("Cursos")
                        .HasForeignKey("idInstructor")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Estados");

                    b.Navigation("Instructores");
                });

            modelBuilder.Entity("CursoApp.Shared.DataBaseModels.Instructores", b =>
                {
                    b.HasOne("CursoApp.Shared.DataBaseModels.Estados", "Estados")
                        .WithMany("Instructores")
                        .HasForeignKey("IdInstructor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CursoApp.Shared.DataBaseModels.Paises", "Paises")
                        .WithMany("Instructores")
                        .HasForeignKey("IdInstructor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estados");

                    b.Navigation("Paises");
                });

            modelBuilder.Entity("CursoApp.Shared.DataBaseModels.Usuarios", b =>
                {
                    b.HasOne("CursoApp.Shared.DataBaseModels.Paises", "Paises")
                        .WithMany("Usuarios")
                        .HasForeignKey("IdPais")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("CursoApp.Shared.DataBaseModels.Estados", "Estados")
                        .WithMany("Usuarios")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estados");

                    b.Navigation("Paises");
                });

            modelBuilder.Entity("UsuariosCursos", b =>
                {
                    b.HasOne("CursoApp.Shared.DataBaseModels.Cursos", null)
                        .WithMany()
                        .HasForeignKey("CursosIdCurso")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("CursoApp.Shared.DataBaseModels.Usuarios", null)
                        .WithMany()
                        .HasForeignKey("UsuariosIdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CursoApp.Shared.DataBaseModels.Estados", b =>
                {
                    b.Navigation("Cursos");

                    b.Navigation("Instructores");

                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("CursoApp.Shared.DataBaseModels.Instructores", b =>
                {
                    b.Navigation("Cursos");
                });

            modelBuilder.Entity("CursoApp.Shared.DataBaseModels.Paises", b =>
                {
                    b.Navigation("Instructores");

                    b.Navigation("Usuarios");
                });
#pragma warning restore 612, 618
        }
    }
}
