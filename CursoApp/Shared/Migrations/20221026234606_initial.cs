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
                    Descripcion = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false),
                    IdCurso = table.Column<int>(type: "int", nullable: false),
                    IdInstructor = table.Column<int>(type: "int", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
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
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: true)
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
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdInstructor = table.Column<int>(type: "int", nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
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
                    IdInstructor = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IdEstado = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((1))"),
                    IdPais = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((1))"),
                    IdCurso = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructores", x => x.IdInstructor);
                    table.ForeignKey(
                        name: "FK_Instructores_Estados_IdInstructor",
                        column: x => x.IdInstructor,
                        principalTable: "Estados",
                        principalColumn: "IdEstado",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Instructores_Paises_IdInstructor",
                        column: x => x.IdInstructor,
                        principalTable: "Paises",
                        principalColumn: "IdPais",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contraseña = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaInscripcion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    UltimoAcceso = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdPais = table.Column<int>(type: "int", nullable: false),
                    IdEstado = table.Column<int>(type: "int", nullable: false),
                    IdCursos = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_Estados_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Estados",
                        principalColumn: "IdEstado",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Usuarios_Paises_IdPais",
                        column: x => x.IdPais,
                        principalTable: "Paises",
                        principalColumn: "IdPais",
                        onDelete: ReferentialAction.Cascade);
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
                    Destacado = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((0))"),
                    idInstructor = table.Column<int>(type: "int", nullable: false),
                    IdEstado = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((1))"),
                    idUsuario = table.Column<int>(type: "int", nullable: false)
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
                        principalColumn: "IdInstructor");
                });

            migrationBuilder.CreateTable(
                name: "UsuariosCursos",
                columns: table => new
                {
                    CursosIdCurso = table.Column<int>(type: "int", nullable: false),
                    UsuariosIdUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuariosCursos", x => new { x.CursosIdCurso, x.UsuariosIdUsuario });
                    table.ForeignKey(
                        name: "FK_UsuariosCursos_Cursos_CursosIdCurso",
                        column: x => x.CursosIdCurso,
                        principalTable: "Cursos",
                        principalColumn: "IdCurso");
                    table.ForeignKey(
                        name: "FK_UsuariosCursos_Usuarios_UsuariosIdUsuario",
                        column: x => x.UsuariosIdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario");
                });

            migrationBuilder.InsertData(
                table: "Estados",
                columns: new[] { "IdEstado", "Descripcion", "IdCurso", "IdInstructor", "IdUsuario" },
                values: new object[,]
                {
                    { 1, "Nuevo", 0, 0, 0 },
                    { 2, "Activo", 0, 0, 0 },
                    { 3, "Inactivo", 0, 0, 0 },
                    { 4, "Suspendido", 0, 0, 0 },
                    { 5, "Baja", 0, 0, 0 }
                });

            migrationBuilder.InsertData(
                table: "Paises",
                columns: new[] { "IdPais", "Descripcion", "IdInstructor", "IdUsuario" },
                values: new object[,]
                {
                    { 1, "Argentina", 0, 0 },
                    { 2, "Germany", 0, 0 },
                    { 3, "Netherlands", 0, 0 },
                    { 4, "USA", 0, 0 },
                    { 5, "Japan", 0, 0 },
                    { 6, "China", 0, 0 },
                    { 7, "UK", 0, 0 },
                    { 8, "France", 0, 0 },
                    { 9, "Brazil", 0, 0 }
                });

            migrationBuilder.InsertData(
                table: "Instructores",
                columns: new[] { "IdInstructor", "Apellido", "Descripcion", "IdCurso", "IdPais", "Nombre" },
                values: new object[,]
                {
                    { 1, "Diaz", "Florcita", 0, 1, "Florencia" },
                    { 2, "DummyApellido1", "DummyDescripcion1", 0, 1, "DummyNombre1" },
                    { 3, "DummyApellido2", "DummyDescripcion2", 0, 2, "DummyNombre2" },
                    { 4, "DummyApellido3", "DummyDescripcion3", 0, 2, "DummyNombre3" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "IdUsuario", "Apellido", "Contraseña", "Email", "IdCursos", "IdEstado", "IdPais", "Nombre" },
                values: new object[,]
                {
                    { 1, "DummyApellido1", null, "DummyNombre1.DummyApellido1@false.com.ar", 0, 0, 1, "DummyNombre1" },
                    { 2, "DummyApellido2", null, "DummyNombre1@false.com.ar", 0, 0, 1, null }
                });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "IdCurso", "IdEstado", "Titulo", "idInstructor", "idUsuario" },
                values: new object[] { 1, 1, "Curso de Pan Dulce", 1, 0 });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "IdCurso", "IdEstado", "Titulo", "idInstructor", "idUsuario" },
                values: new object[] { 2, 1, "Curso de Pan Salado", 2, 0 });

            migrationBuilder.CreateIndex(
                name: "IX_Cursos_IdEstado",
                table: "Cursos",
                column: "IdEstado");

            migrationBuilder.CreateIndex(
                name: "IX_Cursos_idInstructor",
                table: "Cursos",
                column: "idInstructor");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_IdPais",
                table: "Usuarios",
                column: "IdPais");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosCursos_UsuariosIdUsuario",
                table: "UsuariosCursos",
                column: "UsuariosIdUsuario");
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
                name: "Instructores");

            migrationBuilder.DropTable(
                name: "Estados");

            migrationBuilder.DropTable(
                name: "Paises");
        }
    }
}
