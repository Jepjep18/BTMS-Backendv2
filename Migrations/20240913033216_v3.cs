using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "User",
                newName: "BusinessUnit");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BusinessUnit", "DateCreated", "PasswordHash" },
                values: new object[] { "ABFI Central", new DateTime(2024, 9, 13, 11, 32, 15, 897, DateTimeKind.Local).AddTicks(8929), "$2a$11$igOhUkX/cqQiUW46bSYpp.dZXAPxvC0q9Rikd9nnJQU2Ap1Xx4BVC" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BusinessUnit", "DateCreated", "PasswordHash" },
                values: new object[] { "FAIP", new DateTime(2024, 9, 13, 11, 32, 16, 45, DateTimeKind.Local).AddTicks(3592), "$2a$11$OD34VsEwLdFLv7W2i8T9J.qUyDRWyMeUt3FsrGsQDCixa0o8zDjGu" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BusinessUnit", "DateCreated", "PasswordHash" },
                values: new object[] { "FAIP", new DateTime(2024, 9, 13, 11, 32, 16, 196, DateTimeKind.Local).AddTicks(4648), "$2a$11$Y5fbeRBXZ0t1wFchRSj9/uoxv1sRfTpBlDq7QNgBfghlVCf/syoxm" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BusinessUnit", "DateCreated", "PasswordHash" },
                values: new object[] { "SubZero", new DateTime(2024, 9, 13, 11, 32, 16, 341, DateTimeKind.Local).AddTicks(867), "$2a$11$T8IcRJ4A/1a5CW8WcK1rs.ZRyVyE2B7lo1s35eqhwRMuelkHu1/g2" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BusinessUnit",
                table: "User",
                newName: "Email");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "Email", "PasswordHash" },
                values: new object[] { new DateTime(2024, 9, 11, 9, 25, 46, 678, DateTimeKind.Local).AddTicks(8331), "admin@abfiph.com", "$2a$11$RAUahv8knpsGY/vDfEa6yuVnS9NaNJSC7.swPJAfp0EMEggf9.BRq" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "Email", "PasswordHash" },
                values: new object[] { new DateTime(2024, 9, 11, 9, 25, 46, 824, DateTimeKind.Local).AddTicks(8765), "warehouse@abfiph.com", "$2a$11$9LxgJz.8uuCVrt8Kr2DM6ub9BPVSgoG2sT.bzlBMnImjjuKW0fhQO" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "Email", "PasswordHash" },
                values: new object[] { new DateTime(2024, 9, 11, 9, 25, 46, 971, DateTimeKind.Local).AddTicks(385), "faipAdmin@abfiph.com", "$2a$11$1Ht4cEtVCcGa/jDd9rm/DONqIqD8wJZbL4ii6Mlgf24JLVjC6Inpe" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "Email", "PasswordHash" },
                values: new object[] { new DateTime(2024, 9, 11, 9, 25, 47, 115, DateTimeKind.Local).AddTicks(3556), "businessunit@abfiph.com", "$2a$11$pKEGoEo31EkcCa0ZxbH8E.zx4rBHKac8vpbaSgWrAQnBxr6nhOgAK" });
        }
    }
}
