using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "PasswordHash" },
                values: new object[] { new DateTime(2024, 9, 11, 9, 25, 46, 678, DateTimeKind.Local).AddTicks(8331), "$2a$11$RAUahv8knpsGY/vDfEa6yuVnS9NaNJSC7.swPJAfp0EMEggf9.BRq" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "PasswordHash" },
                values: new object[] { new DateTime(2024, 9, 11, 9, 25, 46, 824, DateTimeKind.Local).AddTicks(8765), "$2a$11$9LxgJz.8uuCVrt8Kr2DM6ub9BPVSgoG2sT.bzlBMnImjjuKW0fhQO" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "PasswordHash" },
                values: new object[] { new DateTime(2024, 9, 11, 9, 25, 46, 971, DateTimeKind.Local).AddTicks(385), "$2a$11$1Ht4cEtVCcGa/jDd9rm/DONqIqD8wJZbL4ii6Mlgf24JLVjC6Inpe" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "PasswordHash" },
                values: new object[] { new DateTime(2024, 9, 11, 9, 25, 47, 115, DateTimeKind.Local).AddTicks(3556), "$2a$11$pKEGoEo31EkcCa0ZxbH8E.zx4rBHKac8vpbaSgWrAQnBxr6nhOgAK" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "PasswordHash" },
                values: new object[] { new DateTime(2024, 9, 10, 21, 30, 18, 496, DateTimeKind.Local).AddTicks(6462), "$2a$11$rjMdjmJqh83g3Jm8CBCHo.w8HpEs2vSoBlvzFW.fPNceGAAjrBKFy" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "PasswordHash" },
                values: new object[] { new DateTime(2024, 9, 10, 21, 30, 18, 659, DateTimeKind.Local).AddTicks(7468), "$2a$11$SxAQpLDbiF.ag0DgkTPP3uK0cz53GN6L3PEnORBBFsuBi1LjqU5YS" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "PasswordHash" },
                values: new object[] { new DateTime(2024, 9, 10, 21, 30, 18, 819, DateTimeKind.Local).AddTicks(5526), "$2a$11$BWik4O3gOuwYgHGbgFrRzutrL/2J6Hf4wHzJ64uaF5jYHIB1smOtC" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "PasswordHash" },
                values: new object[] { new DateTime(2024, 9, 10, 21, 30, 18, 986, DateTimeKind.Local).AddTicks(5050), "$2a$11$.pDOV762yVHPSd41PEkB0Oc4eVKmS76xRigEx6lcNzKU2HQXsajBS" });
        }
    }
}
