using Microsoft.EntityFrameworkCore.Migrations;

namespace CursoApp.Shared.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdEstado",
                table: "Cursos");

            migrationBuilder.AddColumn<int>(
                name: "IdEstado1",
                table: "Cursos",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Estados",
                columns: new[] { "IdEstado", "Descripcion" },
                values: new object[,]
                {
                    { 1, "Activo" },
                    { 2, "Inactivo" },
                    { 3, "Suspendido" },
                    { 4, "Baja" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cursos_IdEstado1",
                table: "Cursos",
                column: "IdEstado1");

            migrationBuilder.AddForeignKey(
                name: "FK_Cursos_Estados_IdEstado1",
                table: "Cursos",
                column: "IdEstado1",
                principalTable: "Estados",
                principalColumn: "IdEstado",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cursos_Estados_IdEstado1",
                table: "Cursos");

            migrationBuilder.DropIndex(
                name: "IX_Cursos_IdEstado1",
                table: "Cursos");

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "IdEstado",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "IdEstado",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "IdEstado",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Estados",
                keyColumn: "IdEstado",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "IdEstado1",
                table: "Cursos");

            migrationBuilder.AddColumn<bool>(
                name: "IdEstado",
                table: "Cursos",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
