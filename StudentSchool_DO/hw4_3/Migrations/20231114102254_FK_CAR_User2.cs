using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hw_2.Migrations
{
    /// <inheritdoc />
    public partial class FK_CAR_User2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Users_DbUserUserId",
                table: "Cars");

            migrationBuilder.AlterColumn<Guid>(
                name: "DbUserUserId",
                table: "Cars",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Users_DbUserUserId",
                table: "Cars",
                column: "DbUserUserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Users_DbUserUserId",
                table: "Cars");

            migrationBuilder.AlterColumn<Guid>(
                name: "DbUserUserId",
                table: "Cars",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Users_DbUserUserId",
                table: "Cars",
                column: "DbUserUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
