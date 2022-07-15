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
                        .HasColumnType("bit");

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
                        .HasColumnType("int");

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

                    b.HasKey("IdCurso");

                    b.HasIndex("IdEstado");

                    b.HasIndex("idInstructor");

                    b.ToTable("Cursos", (string)null);
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

                    b.HasKey("IdEstado");

                    b.ToTable("Estados");

                    b.HasData(
                        new
                        {
                            IdEstado = 1,
                            Descripcion = "Nuevo"
                        },
                        new
                        {
                            IdEstado = 2,
                            Descripcion = "Activo"
                        },
                        new
                        {
                            IdEstado = 3,
                            Descripcion = "Inactivo"
                        },
                        new
                        {
                            IdEstado = 4,
                            Descripcion = "Suspendido"
                        },
                        new
                        {
                            IdEstado = 5,
                            Descripcion = "Baja"
                        });
                });

            modelBuilder.Entity("CursoApp.Shared.DataBaseModels.InfoAcademia", b =>
                {
                    b.Property<int>("IdAcademia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdAcademia"), 1L, 1);

                    b.HasKey("IdAcademia");

                    b.ToTable("InfoAcademia");
                });

            modelBuilder.Entity("CursoApp.Shared.DataBaseModels.Instructores", b =>
                {
                    b.Property<int>("IdInstructor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdInstructor"), 1L, 1);

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdPais")
                        .HasColumnType("int");

                    b.Property<int?>("IdPaisNavigationIdPais")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdInstructor");

                    b.HasIndex("IdPaisNavigationIdPais");

                    b.ToTable("Instructores");

                    b.HasData(
                        new
                        {
                            IdInstructor = 1,
                            Apellido = "Diaz",
                            Descripcion = "Florcita",
                            IdPais = 1,
                            Nombre = "Florencia"
                        },
                        new
                        {
                            IdInstructor = 2,
                            Apellido = "Dummy",
                            Descripcion = "DescripcionDummy",
                            IdPais = 6,
                            Nombre = "Test"
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

                    b.HasKey("IdPais");

                    b.ToTable("Paises");

                    b.HasData(
                        new
                        {
                            IdPais = 1,
                            Descripcion = "Argentina"
                        },
                        new
                        {
                            IdPais = 2,
                            Descripcion = "Germany"
                        },
                        new
                        {
                            IdPais = 3,
                            Descripcion = "Netherlands"
                        },
                        new
                        {
                            IdPais = 4,
                            Descripcion = "USA"
                        },
                        new
                        {
                            IdPais = 5,
                            Descripcion = "Japan"
                        },
                        new
                        {
                            IdPais = 6,
                            Descripcion = "China"
                        },
                        new
                        {
                            IdPais = 7,
                            Descripcion = "UK"
                        },
                        new
                        {
                            IdPais = 8,
                            Descripcion = "France"
                        },
                        new
                        {
                            IdPais = 9,
                            Descripcion = "Brazil"
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

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUsuario"), 1L, 1);

                    b.Property<string>("Apellido")
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

                    b.Property<int?>("IdPais")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("IdPaisNavigationIdPais")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UltimoAcceso")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.HasKey("IdUsuario");

                    b.HasIndex("IdPaisNavigationIdPais");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("CursoApp.Shared.DataBaseModels.UsuariosCursos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("IdCurso")
                        .HasColumnType("int");

                    b.Property<int?>("IdCursoNavigationIdCurso")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<int?>("IdUsuarioNavigationIdUsuario")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdCursoNavigationIdCurso");

                    b.HasIndex("IdUsuarioNavigationIdUsuario");

                    b.ToTable("UsuariosCursos");
                });

            modelBuilder.Entity("CursoApp.Shared.DataBaseModels.Cursos", b =>
                {
                    b.HasOne("CursoApp.Shared.DataBaseModels.Estados", "Estados")
                        .WithMany()
                        .HasForeignKey("IdEstado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CursoApp.Shared.DataBaseModels.Instructores", "Instructores")
                        .WithMany("Cursos")
                        .HasForeignKey("idInstructor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estados");

                    b.Navigation("Instructores");
                });

            modelBuilder.Entity("CursoApp.Shared.DataBaseModels.Instructores", b =>
                {
                    b.HasOne("CursoApp.Shared.DataBaseModels.Paises", "IdPaisNavigation")
                        .WithMany("Instructores")
                        .HasForeignKey("IdPaisNavigationIdPais");

                    b.Navigation("IdPaisNavigation");
                });

            modelBuilder.Entity("CursoApp.Shared.DataBaseModels.Usuarios", b =>
                {
                    b.HasOne("CursoApp.Shared.DataBaseModels.Paises", "IdPaisNavigation")
                        .WithMany("Usuarios")
                        .HasForeignKey("IdPaisNavigationIdPais");

                    b.Navigation("IdPaisNavigation");
                });

            modelBuilder.Entity("CursoApp.Shared.DataBaseModels.UsuariosCursos", b =>
                {
                    b.HasOne("CursoApp.Shared.DataBaseModels.Cursos", "IdCursoNavigation")
                        .WithMany("UsuariosCursos")
                        .HasForeignKey("IdCursoNavigationIdCurso");

                    b.HasOne("CursoApp.Shared.DataBaseModels.Usuarios", "IdUsuarioNavigation")
                        .WithMany("UsuariosCursos")
                        .HasForeignKey("IdUsuarioNavigationIdUsuario");

                    b.Navigation("IdCursoNavigation");

                    b.Navigation("IdUsuarioNavigation");
                });

            modelBuilder.Entity("CursoApp.Shared.DataBaseModels.Cursos", b =>
                {
                    b.Navigation("UsuariosCursos");
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

            modelBuilder.Entity("CursoApp.Shared.DataBaseModels.Usuarios", b =>
                {
                    b.Navigation("UsuariosCursos");
                });
#pragma warning restore 612, 618
        }
    }
}
