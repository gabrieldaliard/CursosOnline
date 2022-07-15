using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CursoApp.Shared.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    IdEstado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.IdEstado);
                });

            migrationBuilder.CreateTable(
                name: "InfoAcademia",
                columns: table => new
                {
                    IdAcademia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfoAcademia", x => x.IdAcademia);
                });

            migrationBuilder.CreateTable(
                name: "Paises",
                columns: table => new
                {
                    IdPais = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paises", x => x.IdPais);
                });

            migrationBuilder.CreateTable(
                name: "PreguntasFreqs",
                columns: table => new
                {
                    IdPregunta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pregunta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Respuesta = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreguntasFreqs", x => x.IdPregunta);
                });

            migrationBuilder.CreateTable(
                name: "Instructores",
                columns: table => new
                {
                    IdInstructor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdPais = table.Column<int>(type: "int", nullable: false),
                    IdPaisNavigationIdPais = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructores", x => x.IdInstructor);
                    table.ForeignKey(
                        name: "FK_Instructores_Paises_IdPaisNavigationIdPais",
                        column: x => x.IdPaisNavigationIdPais,
                        principalTable: "Paises",
                        principalColumn: "IdPais");
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaInscripcion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    UltimoAcceso = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdPais = table.Column<int>(type: "int", nullable: false),
                    Contraseña = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdPaisNavigationIdPais = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_Paises_IdPaisNavigationIdPais",
                        column: x => x.IdPaisNavigationIdPais,
                        principalTable: "Paises",
                        principalColumn: "IdPais");
                });

            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    IdCurso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    FechaModificacion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Interesados = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    Estudiantes = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    Destacado = table.Column<bool>(type: "bit", nullable: false),
                    IdEstado = table.Column<int>(type: "int", nullable: false),
                    idInstructor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.IdCurso);
                    table.ForeignKey(
                        name: "FK_Cursos_Estados_IdEstado",
                        column: x => x.IdEstado,
                        principalTable: "Estados",
                        principalColumn: "IdEstado",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cursos_Instructores_idInstructor",
                        column: x => x.idInstructor,
                        principalTable: "Instructores",
                        principalColumn: "IdInstructor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuariosCursos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCurso = table.Column<int>(type: "int", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    IdCursoNavigationIdCurso = table.Column<int>(type: "int", nullable: true),
                    IdUsuarioNavigationIdUsuario = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuariosCursos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuariosCursos_Cursos_IdCursoNavigationIdCurso",
                        column: x => x.IdCursoNavigationIdCurso,
                        principalTable: "Cursos",
                        principalColumn: "IdCurso");
                    table.ForeignKey(
                        name: "FK_UsuariosCursos_Usuarios_IdUsuarioNavigationIdUsuario",
                        column: x => x.IdUsuarioNavigationIdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario");
                });

            migrationBuilder.InsertData(
                table: "Estados",
                columns: new[] { "IdEstado", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Nuevo" },
                    { 2, "Activo" },
                    { 3, "Inactivo" },
                    { 4, "Suspendido" },
                    { 5, "Baja" }
                });

            migrationBuilder.InsertData(
                table: "Instructores",
                columns: new[] { "IdInstructor", "Apellido", "Descripcion", "IdPais", "IdPaisNavigationIdPais", "Nombre" },
                values: new object[,]
                {
                    { 1, "Diaz", "Florcita", 1, null, "Florencia" },
                    { 2, "Dummy", "DescripcionDummy", 6, null, "Test" }
                });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "IdPais", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Argentina" },
                    { 2, "Germany" },
                    { 3, "Netherlands" },
                    { 4, "USA" },
                    { 5, "Japan" },
                    { 6, "China" },
                    { 7, "UK" },
                    { 8, "France" },
                    { 9, "Brazil" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cursos_IdEstado",
                table: "Cursos",
                column: "IdEstado");

            migrationBuilder.CreateIndex(
                name: "IX_Cursos_idInstructor",
                table: "Cursos",
                column: "idInstructor");

            migrationBuilder.CreateIndex(
                name: "IX_Instructores_IdPaisNavigationIdPais",
                table: "Instructores",
                column: "IdPaisNavigationIdPais");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_IdPaisNavigationIdPais",
                table: "Usuarios",
                column: "IdPaisNavigationIdPais");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosCursos_IdCursoNavigationIdCurso",
                table: "UsuariosCursos",
                column: "IdCursoNavigationIdCurso");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosCursos_IdUsuarioNavigationIdUsuario",
                table: "UsuariosCursos",
                column: "IdUsuarioNavigationIdUsuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InfoAcademia");

            migrationBuilder.DropTable(
                name: "PreguntasFreqs");

            migrationBuilder.DropTable(
                name: "UsuariosCursos");

            migrationBuilder.DropTable(
                name: "Cursos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Estados");

            migrationBuilder.DropTable(
                name: "Instructores");

            migrationBuilder.DropTable(
                name: "Paises");
        }
    }
}
