﻿// <auto-generated />
using System;
using CursoApp.Shared.DataBaseModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CursoApp.Shared.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220704011414_initial2")]
    partial class initial2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CursoApp.Shared.DataBaseModels.Cursos", b =>
                {
                    b.Property<int>("IdCurso")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Destacado")
                        .HasColumnType("bit");

                    b.Property<int?>("Estudiantes")
                        .HasColumnType("int");

                    b.Property<DateTime?>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaModificacion")
                        .HasColumnType("datetime2");

                    b.Property<int?>("IdEstado1")
                        .HasColumnType("int");

                    b.Property<int?>("Interesados")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<int>("idInstructor")
                        .HasColumnType("int");

                    b.Property<int?>("idInstructorNavigationIdInstructor")
                        .HasColumnType("int");

                    b.HasKey("IdCurso");

                    b.HasIndex("IdEstado1");

                    b.HasIndex("idInstructorNavigationIdInstructor");

                    b.ToTable("Cursos");
                });

            modelBuilder.Entity("CursoApp.Shared.DataBaseModels.Estados", b =>
                {
                    b.Property<int>("IdEstado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
                            Descripcion = "Activo"
                        },
                        new
                        {
                            IdEstado = 2,
                            Descripcion = "Inactivo"
                        },
                        new
                        {
                            IdEstado = 3,
                            Descripcion = "Suspendido"
                        },
                        new
                        {
                            IdEstado = 4,
                            Descripcion = "Baja"
                        });
                });

            modelBuilder.Entity("CursoApp.Shared.DataBaseModels.InfoAcademia", b =>
                {
                    b.Property<int>("IdAcademia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("IdAcademia");

                    b.ToTable("InfoAcademia");
                });

            modelBuilder.Entity("CursoApp.Shared.DataBaseModels.Instructores", b =>
                {
                    b.Property<int>("IdInstructor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripción")
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
                });

            modelBuilder.Entity("CursoApp.Shared.DataBaseModels.Paises", b =>
                {
                    b.Property<int>("IdPais")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPais");

                    b.ToTable("Paises");

                    b.HasData(
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
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contraseña")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("FechaInscripcion")
                        .HasColumnType("datetime2");

                    b.Property<int?>("IdPais")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("IdPaisNavigationIdPais")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UltimoAcceso")
                        .HasColumnType("datetime2");

                    b.HasKey("IdUsuario");

                    b.HasIndex("IdPaisNavigationIdPais");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("CursoApp.Shared.DataBaseModels.UsuariosCursos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
                    b.HasOne("CursoApp.Shared.DataBaseModels.Estados", "IdEstado")
                        .WithMany()
                        .HasForeignKey("IdEstado1");

                    b.HasOne("CursoApp.Shared.DataBaseModels.Instructores", "idInstructorNavigation")
                        .WithMany("Cursos")
                        .HasForeignKey("idInstructorNavigationIdInstructor");

                    b.Navigation("IdEstado");

                    b.Navigation("idInstructorNavigation");
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
