using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class v6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BatteryReturn_BatteryReceiving_BatteryId",
                table: "BatteryReturn");

            migrationBuilder.DropIndex(
                name: "IX_BatteryReturn_BatteryId",
                table: "BatteryReturn");

            migrationBuilder.RenameColumn(
                name: "BatteryId",
                table: "BatteryReturn",
                newName: "BatteryReleasingId");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "PasswordHash" },
                values: new object[] { new DateTime(2024, 9, 30, 14, 31, 11, 700, DateTimeKind.Local).AddTicks(5666), "$2a$11$UowM8huLMa3ljaEkG2io1eEh0/p4.JHhj/t.jNhmRujl9X0/3JZeW" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "PasswordHash" },
                values: new object[] { new DateTime(2024, 9, 30, 14, 31, 11, 846, DateTimeKind.Local).AddTicks(4952), "$2a$11$WGrHProE9pBtl1oZqIHX6.H3xBd3XEvbaow6nAX8fAYvmF6qlMCSW" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "PasswordHash" },
                values: new object[] { new DateTime(2024, 9, 30, 14, 31, 11, 995, DateTimeKind.Local).AddTicks(348), "$2a$11$SFr6P1pmrFB96ag3/uWlu.JpNignsEtUBhOnKqawb3yHketMY2uWy" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "PasswordHash" },
                values: new object[] { new DateTime(2024, 9, 30, 14, 31, 12, 140, DateTimeKind.Local).AddTicks(6327), "$2a$11$NRl8u8dJr/BoON7PxePDWeRmlKMMdvcpq9RT4WKSlyGyAr3.wFD5K" });

            migrationBuilder.CreateIndex(
                name: "IX_BatteryReturn_BatteryReleasingId",
                table: "BatteryReturn",
                column: "BatteryReleasingId");

            migrationBuilder.AddForeignKey(
                name: "FK_BatteryReturn_BatteryReleasing_BatteryReleasingId",
                table: "BatteryReturn",
                column: "BatteryReleasingId",
                principalTable: "BatteryReleasing",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BatteryReturn_BatteryReleasing_BatteryReleasingId",
                table: "BatteryReturn");

            migrationBuilder.DropIndex(
                name: "IX_BatteryReturn_BatteryReleasingId",
                table: "BatteryReturn");

            migrationBuilder.RenameColumn(
                name: "BatteryReleasingId",
                table: "BatteryReturn",
                newName: "BatteryId");

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
                name: "IX_BatteryReturn_BatteryId",
                table: "BatteryReturn",
                column: "BatteryId",
                unique: true,
                filter: "[BatteryId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_BatteryReturn_BatteryReceiving_BatteryId",
                table: "BatteryReturn",
                column: "BatteryId",
                principalTable: "BatteryReceiving",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
