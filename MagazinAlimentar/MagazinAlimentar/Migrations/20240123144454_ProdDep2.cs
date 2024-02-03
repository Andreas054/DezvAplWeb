using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagazinAlimentar.Migrations
{
    /// <inheritdoc />
    public partial class ProdDep2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AgeRestriction",
                table: "Products");

            migrationBuilder.AddColumn<double>(
                name: "Pret",
                table: "Products",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<bool>(
                name: "AgeRestriction",
                table: "Departments",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pret",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "AgeRestriction",
                table: "Departments");

            migrationBuilder.AddColumn<bool>(
                name: "AgeRestriction",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
