using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hw_2.Migrations
{
    /// <inheritdoc />
    public partial class FK_CAR : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "nameSalesOffice",
                table: "SalesOffices",
                newName: "NameSalesOffice");

            migrationBuilder.RenameColumn(
                name: "addressSalesOffice",
                table: "SalesOffices",
                newName: "AddressSalesOffice");

            migrationBuilder.RenameColumn(
                name: "modelCar",
                table: "Cars",
                newName: "ModelCar");

            migrationBuilder.RenameColumn(
                name: "coastCar",
                table: "Cars",
                newName: "CoastCar");

            migrationBuilder.RenameColumn(
                name: "brandCar",
                table: "Cars",
                newName: "BrandCar");

            migrationBuilder.AlterColumn<string>(
                name: "NameSalesOffice",
                table: "SalesOffices",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "AddressSalesOffice",
                table: "SalesOffices",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ModelCar",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "BrandCar",
                table: "Cars",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<Guid>(
                name: "DbUserId",
                table: "Cars",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_DbUserId",
                table: "Cars",
                column: "DbUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Users_DbUserId",
                table: "Cars",
                column: "DbUserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Users_DbUserId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_DbUserId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "DbUserId",
                table: "Cars");

            migrationBuilder.RenameColumn(
                name: "NameSalesOffice",
                table: "SalesOffices",
                newName: "nameSalesOffice");

            migrationBuilder.RenameColumn(
                name: "AddressSalesOffice",
                table: "SalesOffices",
                newName: "addressSalesOffice");

            migrationBuilder.RenameColumn(
                name: "ModelCar",
                table: "Cars",
                newName: "modelCar");

            migrationBuilder.RenameColumn(
                name: "CoastCar",
                table: "Cars",
                newName: "coastCar");

            migrationBuilder.RenameColumn(
                name: "BrandCar",
                table: "Cars",
                newName: "brandCar");

            migrationBuilder.AlterColumn<string>(
                name: "nameSalesOffice",
                table: "SalesOffices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "addressSalesOffice",
                table: "SalesOffices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "modelCar",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "brandCar",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true);
        }
    }
}
