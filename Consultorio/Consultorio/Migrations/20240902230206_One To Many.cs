using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Consultorio.Migrations
{
    /// <inheritdoc />
    public partial class OneToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PacientId",
                table: "tb_consulta");

            migrationBuilder.RenameColumn(
                name: "Paciente",
                table: "tb_consulta",
                newName: "id_paciente");

            migrationBuilder.CreateTable(
                name: "Paciente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Celular = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CPF = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_tb_consulta_id_paciente",
                table: "tb_consulta",
                column: "id_paciente");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_consulta_Paciente_id_paciente",
                table: "tb_consulta",
                column: "id_paciente",
                principalTable: "Paciente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_consulta_Paciente_id_paciente",
                table: "tb_consulta");

            migrationBuilder.DropTable(
                name: "Paciente");

            migrationBuilder.DropIndex(
                name: "IX_tb_consulta_id_paciente",
                table: "tb_consulta");

            migrationBuilder.RenameColumn(
                name: "id_paciente",
                table: "tb_consulta",
                newName: "Paciente");

            migrationBuilder.AddColumn<int>(
                name: "PacientId",
                table: "tb_consulta",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
