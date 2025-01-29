using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaMedico.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDoctorRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    ApellidoP = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    ApellidoM = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    Especialidad = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DoctorPaciente",
                columns: table => new
                {
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    PacienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorPaciente", x => new { x.DoctorId, x.PacienteId });
                    table.ForeignKey(
                        name: "FK_DoctorPaciente_Doctor_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorPaciente_Paciente_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Paciente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoctorPaciente_PacienteId",
                table: "DoctorPaciente",
                column: "PacienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoctorPaciente");

            migrationBuilder.DropTable(
                name: "Doctor");
        }
    }
}
