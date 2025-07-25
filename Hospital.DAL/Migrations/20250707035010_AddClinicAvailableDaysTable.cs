using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddClinicAvailableDaysTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "doctorslist",
                table: "Clinics");

            migrationBuilder.CreateTable(
                name: "ClinicAvailableDays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClinicId = table.Column<int>(type: "int", nullable: false),
                    DayOfWeek = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClinicAvailableDays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClinicAvailableDays_Clinics_ClinicId",
                        column: x => x.ClinicId,
                        principalTable: "Clinics",
                        principalColumn: "clinicId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClinicAvailableDays_ClinicId",
                table: "ClinicAvailableDays",
                column: "ClinicId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClinicAvailableDays");

            migrationBuilder.AddColumn<string>(
                name: "doctorslist",
                table: "Clinics",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
