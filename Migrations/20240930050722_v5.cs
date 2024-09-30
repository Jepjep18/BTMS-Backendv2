using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class v5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TireReturn_TireReceiving_TireId",
                table: "TireReturn");

            migrationBuilder.DropIndex(
                name: "IX_TireReturn_TireId",
                table: "TireReturn");

            migrationBuilder.DropColumn(
                name: "NewTireSerial",
                table: "TireReceiving");

            migrationBuilder.RenameColumn(
                name: "TireId",
                table: "TireReturn",
                newName: "TireReleasingId");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "PasswordHash" },
                values: new object[] { new DateTime(2024, 9, 30, 13, 7, 21, 916, DateTimeKind.Local).AddTicks(3826), "$2a$11$O4OIk.5xbAF5w1MzOwRO7uCETjCdQ2v.d6hqFoaTUIGMNchn5Z0om" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "PasswordHash" },
                values: new object[] { new DateTime(2024, 9, 30, 13, 7, 22, 60, DateTimeKind.Local).AddTicks(7099), "$2a$11$TmZ8WFcflBWQHI9Vs74GA.zfDY3JlI36exDjWaETPfY/UbDhDL58K" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "PasswordHash" },
                values: new object[] { new DateTime(2024, 9, 30, 13, 7, 22, 203, DateTimeKind.Local).AddTicks(4004), "$2a$11$esB322LspwqqBJtYPIsw0.DeN.ZD6yhkVpQdcnIDNWprU7iXU1ZVK" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "PasswordHash" },
                values: new object[] { new DateTime(2024, 9, 30, 13, 7, 22, 344, DateTimeKind.Local).AddTicks(8086), "$2a$11$nkbGdurk8AXEsXZ.Zw/EYu7Udkj337PRbIVEMpxkGurG50Uw8yTEO" });

            migrationBuilder.CreateIndex(
                name: "IX_TireReturn_TireReleasingId",
                table: "TireReturn",
                column: "TireReleasingId",
                unique: true,
                filter: "[TireReleasingId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_TireReturn_TireReleasing_TireReleasingId",
                table: "TireReturn",
                column: "TireReleasingId",
                principalTable: "TireReleasing",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TireReturn_TireReleasing_TireReleasingId",
                table: "TireReturn");

            migrationBuilder.DropIndex(
                name: "IX_TireReturn_TireReleasingId",
                table: "TireReturn");

            migrationBuilder.RenameColumn(
                name: "TireReleasingId",
                table: "TireReturn",
                newName: "TireId");

            migrationBuilder.AddColumn<string>(
                name: "NewTireSerial",
                table: "TireReceiving",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "PasswordHash" },
                values: new object[] { new DateTime(2024, 9, 30, 9, 13, 0, 677, DateTimeKind.Local).AddTicks(6878), "$2a$11$BIxwpWFDzYxOLaCkQRonNuic6CWt4s3XMR9DsEPBKj36mR7RAtTqS" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "PasswordHash" },
                values: new object[] { new DateTime(2024, 9, 30, 9, 13, 0, 824, DateTimeKind.Local).AddTicks(771), "$2a$11$1ZVsfOYIgttcmszW9XR/Hu9wm7iCE9ByIjVKBAyx3zL7w3V5iGsSa" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "PasswordHash" },
                values: new object[] { new DateTime(2024, 9, 30, 9, 13, 0, 970, DateTimeKind.Local).AddTicks(4138), "$2a$11$I4iNto8v7vje2RI2xzSCAOM53Wk/y6QOJrZ8mNRUbtPpGJsbt6eGi" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "PasswordHash" },
                values: new object[] { new DateTime(2024, 9, 30, 9, 13, 1, 120, DateTimeKind.Local).AddTicks(6842), "$2a$11$hQY/Mx7qjRmGO8tt1dEHKu9Ag.FRjr6hb/SoY8r2DqRRqGlBluhpK" });

            migrationBuilder.CreateIndex(
                name: "IX_TireReturn_TireId",
                table: "TireReturn",
                column: "TireId",
                unique: true,
                filter: "[TireId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_TireReturn_TireReceiving_TireId",
                table: "TireReturn",
                column: "TireId",
                principalTable: "TireReceiving",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
