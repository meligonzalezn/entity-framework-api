using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace minimal_api_ef.Migrations
{
    /// <inheritdoc />
    public partial class RemovedFieldDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Task");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Task",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("fe2de405-c38e-4c90-ac52-da0540dfb410"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 27, 3, 15, 11, 780, DateTimeKind.Utc).AddTicks(6865));

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("fe2de405-c38e-4c90-ac52-da0540dfb411"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 27, 3, 15, 11, 780, DateTimeKind.Utc).AddTicks(6876));
        }
    }
}
