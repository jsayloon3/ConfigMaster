using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConfigMaster.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePathInfoSeeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PathInfo",
                keyColumn: "Id",
                keyValue: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PathInfo",
                columns: new[] { "Id", "CreatedAt", "Path", "UpdatedAt" },
                values: new object[] { 1, new DateTime(2025, 1, 22, 13, 12, 39, 385, DateTimeKind.Local).AddTicks(3807), "C:\\BarterCX", new DateTime(2025, 1, 22, 13, 12, 39, 387, DateTimeKind.Local).AddTicks(2751) });
        }
    }
}
