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
            migrationBuilder.UpdateData(
                table: "BusinessUnit",
                keyColumn: "Id",
                keyValue: 16,
                column: "BusinessunitName",
                value: "Research and Development");

            migrationBuilder.UpdateData(
                table: "BusinessUnit",
                keyColumn: "Id",
                keyValue: 17,
                column: "BusinessunitName",
                value: "GSII - Blown Film");

            migrationBuilder.UpdateData(
                table: "BusinessUnit",
                keyColumn: "Id",
                keyValue: 18,
                column: "BusinessunitName",
                value: "GSII - Recycling");

            migrationBuilder.UpdateData(
                table: "BusinessUnit",
                keyColumn: "Id",
                keyValue: 19,
                column: "BusinessunitName",
                value: "GSII - CHB/Ula");

            migrationBuilder.UpdateData(
                table: "BusinessUnit",
                keyColumn: "Id",
                keyValue: 20,
                column: "BusinessunitName",
                value: "HR FAIP");

            migrationBuilder.UpdateData(
                table: "BusinessUnit",
                keyColumn: "Id",
                keyValue: 21,
                column: "BusinessunitName",
                value: "FAIP Admin");

            migrationBuilder.UpdateData(
                table: "BusinessUnit",
                keyColumn: "Id",
                keyValue: 22,
                column: "BusinessunitName",
                value: "Dressing Plant");

            migrationBuilder.UpdateData(
                table: "BusinessUnit",
                keyColumn: "Id",
                keyValue: 23,
                column: "BusinessunitName",
                value: "QA Department");

            migrationBuilder.UpdateData(
                table: "BusinessUnit",
                keyColumn: "Id",
                keyValue: 24,
                column: "BusinessunitName",
                value: "Procurement");

            migrationBuilder.UpdateData(
                table: "BusinessUnit",
                keyColumn: "Id",
                keyValue: 25,
                column: "BusinessunitName",
                value: "Logistics and Warehouse");

            migrationBuilder.UpdateData(
                table: "BusinessUnit",
                keyColumn: "Id",
                keyValue: 26,
                column: "BusinessunitName",
                value: "Motor Pool");

            migrationBuilder.InsertData(
                table: "BusinessUnit",
                columns: new[] { "Id", "BusinessLocation", "BusinessunitDescription", "BusinessunitName" },
                values: new object[] { 27, "To be added", "To be added", "SCC" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "PasswordHash" },
                values: new object[] { new DateTime(2024, 9, 27, 14, 47, 21, 644, DateTimeKind.Local).AddTicks(1444), "$2a$11$vhruT9iYxD.GeKmeTriRmOjP80T5V5QQ6Y6nbMni5JoUJYk6Ip25C" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "PasswordHash" },
                values: new object[] { new DateTime(2024, 9, 27, 14, 47, 21, 822, DateTimeKind.Local).AddTicks(353), "$2a$11$oeIQmb8kb3RP9zxASxmfwO2Ecw8q3DEPBUqD.cO1R68dQZfjvuEjy" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "PasswordHash" },
                values: new object[] { new DateTime(2024, 9, 27, 14, 47, 22, 5, DateTimeKind.Local).AddTicks(8641), "$2a$11$42dvQNWT.Yj/DT9UZQ7jsuhpLZJxhScjAcRIiN67igQ4z7OeHjS0C" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "PasswordHash" },
                values: new object[] { new DateTime(2024, 9, 27, 14, 47, 22, 183, DateTimeKind.Local).AddTicks(7253), "$2a$11$D/QseoAVYEMJpqrY763tguocjTtec9pSwIIgC.dkbofDZOumJPmf." });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BusinessUnit",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.UpdateData(
                table: "BusinessUnit",
                keyColumn: "Id",
                keyValue: 16,
                column: "BusinessunitName",
                value: "GSII - Blown Film");

            migrationBuilder.UpdateData(
                table: "BusinessUnit",
                keyColumn: "Id",
                keyValue: 17,
                column: "BusinessunitName",
                value: "GSII - Recycling");

            migrationBuilder.UpdateData(
                table: "BusinessUnit",
                keyColumn: "Id",
                keyValue: 18,
                column: "BusinessunitName",
                value: "GSII - CHB/Ula");

            migrationBuilder.UpdateData(
                table: "BusinessUnit",
                keyColumn: "Id",
                keyValue: 19,
                column: "BusinessunitName",
                value: "HR FAIP");

            migrationBuilder.UpdateData(
                table: "BusinessUnit",
                keyColumn: "Id",
                keyValue: 20,
                column: "BusinessunitName",
                value: "FAIP Admin");

            migrationBuilder.UpdateData(
                table: "BusinessUnit",
                keyColumn: "Id",
                keyValue: 21,
                column: "BusinessunitName",
                value: "Dressing Plant");

            migrationBuilder.UpdateData(
                table: "BusinessUnit",
                keyColumn: "Id",
                keyValue: 22,
                column: "BusinessunitName",
                value: "QA Department");

            migrationBuilder.UpdateData(
                table: "BusinessUnit",
                keyColumn: "Id",
                keyValue: 23,
                column: "BusinessunitName",
                value: "Procurement");

            migrationBuilder.UpdateData(
                table: "BusinessUnit",
                keyColumn: "Id",
                keyValue: 24,
                column: "BusinessunitName",
                value: "Logistics and Warehouse");

            migrationBuilder.UpdateData(
                table: "BusinessUnit",
                keyColumn: "Id",
                keyValue: 25,
                column: "BusinessunitName",
                value: "Motor Pool");

            migrationBuilder.UpdateData(
                table: "BusinessUnit",
                keyColumn: "Id",
                keyValue: 26,
                column: "BusinessunitName",
                value: "SCC");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "PasswordHash" },
                values: new object[] { new DateTime(2024, 9, 27, 14, 32, 14, 134, DateTimeKind.Local).AddTicks(7603), "$2a$11$6j1OccVdIOGzXbH9sAcMGewRZbDWEWyJzV6I.NpnvJHRWSUQKc4JG" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "PasswordHash" },
                values: new object[] { new DateTime(2024, 9, 27, 14, 32, 14, 318, DateTimeKind.Local).AddTicks(2146), "$2a$11$Z67yI2V5oAmZ1j6YWOVob.jX4.nEV2nsPI60YI34.C6TWbjte9UIi" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateCreated", "PasswordHash" },
                values: new object[] { new DateTime(2024, 9, 27, 14, 32, 14, 497, DateTimeKind.Local).AddTicks(9194), "$2a$11$r2jahbmMM1HBX.5uYp7VM.bwCuE3so.OhvpAcMRUUzHPdv1iOtM9m" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DateCreated", "PasswordHash" },
                values: new object[] { new DateTime(2024, 9, 27, 14, 32, 14, 675, DateTimeKind.Local).AddTicks(9272), "$2a$11$VVYTSzgu3Lx6eTyQW9X13OOCs0muTNjbEMqnjbuAIXFOnTVbvil7O" });
        }
    }
}
