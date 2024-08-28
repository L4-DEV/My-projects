using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Consultorio.Migrations
{
    /// <inheritdoc />
    public partial class atualizandonomes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Horario",
                table: "tb_agendamento",
                newName: "horario");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "tb_agendamento",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "NomePaciente",
                table: "tb_agendamento",
                newName: "nome_paciente");

            migrationBuilder.AlterColumn<string>(
                name: "nome_paciente",
                table: "tb_agendamento",
                type: "varchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "horario",
                table: "tb_agendamento",
                newName: "Horario");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "tb_agendamento",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "nome_paciente",
                table: "tb_agendamento",
                newName: "NomePaciente");

            migrationBuilder.AlterColumn<string>(
                name: "NomePaciente",
                table: "tb_agendamento",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
