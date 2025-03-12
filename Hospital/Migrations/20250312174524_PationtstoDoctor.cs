using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.Migrations
{
    /// <inheritdoc />
    public partial class PationtstoDoctor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientDoctor",
                columns: table => new
                {
                    ClientsId = table.Column<int>(type: "int", nullable: false),
                    DoctorsDoctorID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientDoctor", x => new { x.ClientsId, x.DoctorsDoctorID });
                    table.ForeignKey(
                        name: "FK_ClientDoctor_Doctors_DoctorsDoctorID",
                        column: x => x.DoctorsDoctorID,
                        principalTable: "Doctors",
                        principalColumn: "DoctorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientDoctor_Patients_ClientsId",
                        column: x => x.ClientsId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientDoctor_DoctorsDoctorID",
                table: "ClientDoctor",
                column: "DoctorsDoctorID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientDoctor");
        }
    }
}
