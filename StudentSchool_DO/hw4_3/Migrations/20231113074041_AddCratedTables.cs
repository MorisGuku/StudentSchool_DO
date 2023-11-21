using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hw_2.Migrations
{
    /// <inheritdoc />
    public partial class AddCratedTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    brandCar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    modelCar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    coastCar = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesOffices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nameSalesOffice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    addressSalesOffice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    addressSalesOffi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesOffices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DbCarDbSalesOffice",
                columns: table => new
                {
                    CarsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SalesOfficesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbCarDbSalesOffice", x => new { x.CarsId, x.SalesOfficesId });
                    table.ForeignKey(
                        name: "FK_DbCarDbSalesOffice_Cars_CarsId",
                        column: x => x.CarsId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DbCarDbSalesOffice_SalesOffices_SalesOfficesId",
                        column: x => x.SalesOfficesId,
                        principalTable: "SalesOffices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DbCarDbSalesOffice_SalesOfficesId",
                table: "DbCarDbSalesOffice",
                column: "SalesOfficesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DbCarDbSalesOffice");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "SalesOffices");
        }
    }
}
