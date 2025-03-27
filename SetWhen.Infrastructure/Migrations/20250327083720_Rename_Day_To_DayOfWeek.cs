using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SetWhen.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Rename_Day_To_DayOfWeek : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Day",
                table: "StaffAvailabilities",
                newName: "DayOfWeek");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ServiceId",
                table: "Reservations",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_StaffId",
                table: "Reservations",
                column: "StaffId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Services_ServiceId",
                table: "Reservations",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Users_StaffId",
                table: "Reservations",
                column: "StaffId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Services_ServiceId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Users_StaffId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_ServiceId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_StaffId",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "DayOfWeek",
                table: "StaffAvailabilities",
                newName: "Day");
        }
    }
}
