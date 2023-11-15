using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hw_2.Migrations
{
    /// <inheritdoc />
    public partial class FK_CAR_User : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Users_DbUserId",
                table: "Cars");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "DbUserId",
                table: "Cars",
                newName: "DbUserUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Cars_DbUserId",
                table: "Cars",
                newName: "IX_Cars_DbUserUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Users_DbUserUserId",
                table: "Cars",
                column: "DbUserUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Users_DbUserUserId",
                table: "Cars");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "DbUserUserId",
                table: "Cars",
                newName: "DbUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Cars_DbUserUserId",
                table: "Cars",
                newName: "IX_Cars_DbUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Users_DbUserId",
                table: "Cars",
                column: "DbUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
