using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class v4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NewTireSerial",
                table: "TireReceiving");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "PasswordHash" },
                values: new object[] { new DateTime(2024, 9, 13, 11, 32, 15, 897, DateTimeKind.Local).AddTicks(8929), "$2a$11$igOhUkX/cqQiUW46bSYpp.dZXAPxvC0q9Rikd9nnJQU2Ap1Xx4BVC" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "PasswordHash" },
                values: new object[] { new DateTime(2024, 9, 13, 11, 32, 16, 45, DateTimeKind.Local).AddTicks(3592), "$2a$11$OD34VsEwLdFLv7W2i8T9J.qUyDRWyMeUt3FsrGsQDCixa0o8zDjGu" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "PasswordHash" },
                values: new object[] { new DateTime(2024, 9, 13, 11, 32, 16, 196, DateTimeKind.Local).AddTicks(4648), "$2a$11$Y5fbeRBXZ0t1wFchRSj9/uoxv1sRfTpBlDq7QNgBfghlVCf/syoxm" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "PasswordHash" },
                values: new object[] { new DateTime(2024, 9, 13, 11, 32, 16, 341, DateTimeKind.Local).AddTicks(867), "$2a$11$T8IcRJ4A/1a5CW8WcK1rs.ZRyVyE2B7lo1s35eqhwRMuelkHu1/g2" });
        }
    }
}
