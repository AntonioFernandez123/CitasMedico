using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionCitasMedico.Migrations
{
    /// <inheritdoc />
    public partial class primera : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Diagnostico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    valoracionEspecialista = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    enfermedad = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagnostico", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    numColegiado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    usuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Clave = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medico", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Paciente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NSS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    numTarjeta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    usuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Clave = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cita",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    fechaHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    motivoCita = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    idMedico = table.Column<int>(type: "int", nullable: false),
                    idPaciente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cita", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cita_Diagnostico_Id",
                        column: x => x.Id,
                        principalTable: "Diagnostico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cita_Medico_idMedico",
                        column: x => x.idMedico,
                        principalTable: "Medico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cita_Paciente_idPaciente",
                        column: x => x.idPaciente,
                        principalTable: "Paciente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicoPaciente",
                columns: table => new
                {
                    MedicosId = table.Column<int>(type: "int", nullable: false),
                    PacientesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicoPaciente", x => new { x.MedicosId, x.PacientesId });
                    table.ForeignKey(
                        name: "FK_MedicoPaciente_Medico_MedicosId",
                        column: x => x.MedicosId,
                        principalTable: "Medico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicoPaciente_Paciente_PacientesId",
                        column: x => x.PacientesId,
                        principalTable: "Paciente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cita_idMedico",
                table: "Cita",
                column: "idMedico");

            migrationBuilder.CreateIndex(
                name: "IX_Cita_idPaciente",
                table: "Cita",
                column: "idPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_MedicoPaciente_PacientesId",
                table: "MedicoPaciente",
                column: "PacientesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cita");

            migrationBuilder.DropTable(
                name: "MedicoPaciente");

            migrationBuilder.DropTable(
                name: "Diagnostico");

            migrationBuilder.DropTable(
                name: "Medico");

            migrationBuilder.DropTable(
                name: "Paciente");
        }
    }
}
