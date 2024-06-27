using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace minimal_api_ef.Migrations
{
    /// <inheritdoc />
    public partial class InitialSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("fe2de405-c38e-4c90-ac52-da0540dfb410"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 26, 22, 10, 24, 809, DateTimeKind.Local).AddTicks(6418));

            migrationBuilder.UpdateData(
                table: "Task",
                keyColumn: "TaskId",
                keyValue: new Guid("fe2de405-c38e-4c90-ac52-da0540dfb411"),
                column: "CreationDate",
                value: new DateTime(2024, 6, 26, 22, 10, 24, 809, DateTimeKind.Local).AddTicks(6447));
        }
    }
}
