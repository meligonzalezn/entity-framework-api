using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace minimal_api_ef.Migrations
{
    /// <inheritdoc />
    public partial class ColumnPointCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Point",
                table: "Category",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Point",
                table: "Category");
        }
    }
}
