using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace minimal_api_ef.Migrations
{
    /// <inheritdoc />
    public partial class ColumnStatusTask : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Task",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Task");
        }
    }
}
