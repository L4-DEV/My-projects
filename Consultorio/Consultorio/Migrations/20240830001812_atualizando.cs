using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Consultorio.Migrations
{
    /// <inheritdoc />
    public partial class atualizando : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_agendamento");

            migrationBuilder.CreateTable(
                name: "tb_consulta",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    data_horario = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    preco = table.Column<decimal>(type: "decimal(7,2)", precision: 7, scale: 2, nullable: false),
                    PacientId = table.Column<int>(type: "int", nullable: false),
                    Paciente = table.Column<int>(type: "int", nullable: false),
                    EspecialidadeId = table.Column<int>(type: "int", nullable: false),
                    ProfissionalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_consulta", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_consulta");

            migrationBuilder.CreateTable(
                name: "tb_agendamento",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    horario = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Idade = table.Column<int>(type: "int", nullable: false),
                    nome_paciente = table.Column<string>(type: "varchar(100)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_agendamento", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
