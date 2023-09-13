using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LauraModasAPI.Migrations
{
    /// <inheritdoc />
    public partial class RemainingValue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "RemainingValue",
                table: "Installments",
                type: "double",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RemainingValue",
                table: "Installments");
        }
    }
}
