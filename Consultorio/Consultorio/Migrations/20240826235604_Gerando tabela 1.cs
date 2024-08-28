using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Consultorio.Migrations
{
    /// <inheritdoc />
    public partial class Gerandotabela1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Agendamentos",
                table: "Agendamentos");

            migrationBuilder.RenameTable(
                name: "Agendamentos",
                newName: "tb_agendamento");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_agendamento",
                table: "tb_agendamento",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_agendamento",
                table: "tb_agendamento");

            migrationBuilder.RenameTable(
                name: "tb_agendamento",
                newName: "Agendamentos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Agendamentos",
                table: "Agendamentos",
                column: "Id");
        }
    }
}
