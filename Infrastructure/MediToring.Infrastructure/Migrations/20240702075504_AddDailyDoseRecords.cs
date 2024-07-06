using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MediToring.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDailyDoseRecords : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsTaken",
                table: "MedicationSchedules");

            migrationBuilder.CreateTable(
                name: "DailyDoseRecords",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MedicationScheduleId = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsTaken = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyDoseRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyDoseRecords_MedicationSchedules_MedicationScheduleId",
                        column: x => x.MedicationScheduleId,
                        principalTable: "MedicationSchedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DailyDoseRecords_MedicationScheduleId",
                table: "DailyDoseRecords",
                column: "MedicationScheduleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DailyDoseRecords");

            migrationBuilder.AddColumn<bool>(
                name: "IsTaken",
                table: "MedicationSchedules",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
