using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hw_2.Migrations
{
    /// <inheritdoc />
    public partial class FK_CAR_User_To_Car : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Users_DbUserUserId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_DbUserUserId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "DbUserUserId",
                table: "Cars");

            migrationBuilder.AddColumn<Guid>(
                name: "CarId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "DbCarDbUser",
                columns: table => new
                {
                    CarsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsersUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbCarDbUser", x => new { x.CarsId, x.UsersUserId });
                    table.ForeignKey(
                        name: "FK_DbCarDbUser_Cars_CarsId",
                        column: x => x.CarsId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DbCarDbUser_Users_UsersUserId",
                        column: x => x.UsersUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DbCarDbUser_UsersUserId",
                table: "DbCarDbUser",
                column: "UsersUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DbCarDbUser");

            migrationBuilder.DropColumn(
                name: "CarId",
                table: "Users");

            migrationBuilder.AddColumn<Guid>(
                name: "DbUserUserId",
                table: "Cars",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_DbUserUserId",
                table: "Cars",
                column: "DbUserUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Users_DbUserUserId",
                table: "Cars",
                column: "DbUserUserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }
    }
}
