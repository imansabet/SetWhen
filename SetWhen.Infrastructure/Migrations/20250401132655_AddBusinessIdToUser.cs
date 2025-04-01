using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SetWhen.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddBusinessIdToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Services_OwnerId",
                table: "Services",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Users_OwnerId",
                table: "Services",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_Users_OwnerId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_OwnerId",
                table: "Services");
        }
    }
}
