using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hw_2.Migrations
{
    /// <inheritdoc />
    public partial class DropAttribute : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "addressSalesOffi",
                table: "SalesOffices");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "addressSalesOffi",
                table: "SalesOffices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
