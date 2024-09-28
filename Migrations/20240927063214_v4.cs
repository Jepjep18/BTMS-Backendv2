using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class v4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BusinessUnit",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BusinessLocation", "BusinessunitDescription", "BusinessunitName" },
                values: new object[] { "To be added", "Executive Office Ana's Breeders Farm Central Office", "Executive" });

            migrationBuilder.UpdateData(
                table: "BusinessUnit",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BusinessLocation", "BusinessunitDescription", "BusinessunitName" },
                values: new object[] { "To be added", "To be added", "FEM" });

            migrationBuilder.UpdateData(
                table: "BusinessUnit",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BusinessLocation", "BusinessunitDescription", "BusinessunitName" },
                values: new object[] { "To be added", "To be added", "PO - Cenlo" });

            migrationBuilder.UpdateData(
                table: "BusinessUnit",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BusinessLocation", "BusinessunitDescription", "BusinessunitName" },
                values: new object[] { "To be added", "To be added", "PO - Broiler" });

            migrationBuilder.UpdateData(
                table: "BusinessUnit",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "BusinessLocation", "BusinessunitDescription", "BusinessunitName" },
                values: new object[] { "To be added", "To be added", "PO - Breeder" });

            migrationBuilder.UpdateData(
                table: "BusinessUnit",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "BusinessLocation", "BusinessunitDescription", "BusinessunitName" },
                values: new object[] { "To be added", "To be added", "PO - Hatchery" });

            migrationBuilder.UpdateData(
                table: "BusinessUnit",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "BusinessLocation", "BusinessunitDescription", "BusinessunitName" },
                values: new object[] { "To be added", "To be added", "CAO" });

            migrationBuilder.InsertData(
                table: "BusinessUnit",
                columns: new[] { "Id", "BusinessLocation", "BusinessunitDescription", "BusinessunitName" },
                values: new object[,]
                {
                    { 8, "To be added", "To be added", "Cisdevo" },
                    { 9, "To be added", "To be added", "Subzero" },
                    { 10, "To be added", "To be added", "Sales - ABFI" },
                    { 11, "To be added", "To be added", "PED - Planning" },
                    { 12, "To be added", "To be added", "PED - Project" },
                    { 13, "To be added", "To be added", "SFC" },
                    { 14, "To be added", "To be added", "Sales - QP/SCC" },
                    { 15, "To be added", "To be added", "JPPI" },
                    { 16, "To be added", "To be added", "GSII - Blown Film" },
                    { 17, "To be added", "To be added", "GSII - Recycling" },
                    { 18, "To be added", "To be added", "GSII - CHB/Ula" },
                    { 19, "To be added", "To be added", "HR FAIP" },
                    { 20, "To be added", "To be added", "FAIP Admin" },
                    { 21, "To be added", "To be added", "Dressing Plant" },
                    { 22, "To be added", "To be added", "QA Department" },
                    { 23, "To be added", "To be added", "Procurement" },
                    { 24, "To be added", "To be added", "Logistics and Warehouse" },
                    { 25, "To be added", "To be added", "Motor Pool" },
                    { 26, "To be added", "To be added", "SCC" }
                });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BusinessUnit", "DateCreated", "PasswordHash" },
                values: new object[] { "Cisdevo", new DateTime(2024, 9, 27, 14, 32, 14, 134, DateTimeKind.Local).AddTicks(7603), "$2a$11$6j1OccVdIOGzXbH9sAcMGewRZbDWEWyJzV6I.NpnvJHRWSUQKc4JG" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BusinessUnit", "DateCreated", "PasswordHash" },
                values: new object[] { "Logistics and Warehouse", new DateTime(2024, 9, 27, 14, 32, 14, 318, DateTimeKind.Local).AddTicks(2146), "$2a$11$Z67yI2V5oAmZ1j6YWOVob.jX4.nEV2nsPI60YI34.C6TWbjte9UIi" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BusinessUnit", "DateCreated", "PasswordHash" },
                values: new object[] { "FAIP Admin", new DateTime(2024, 9, 27, 14, 32, 14, 497, DateTimeKind.Local).AddTicks(9194), "$2a$11$r2jahbmMM1HBX.5uYp7VM.bwCuE3so.OhvpAcMRUUzHPdv1iOtM9m" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BusinessUnit", "DateCreated", "PasswordHash" },
                values: new object[] { "Subzero", new DateTime(2024, 9, 27, 14, 32, 14, 675, DateTimeKind.Local).AddTicks(9272), "$2a$11$VVYTSzgu3Lx6eTyQW9X13OOCs0muTNjbEMqnjbuAIXFOnTVbvil7O" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BusinessUnit",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "BusinessUnit",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "BusinessUnit",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "BusinessUnit",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "BusinessUnit",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "BusinessUnit",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "BusinessUnit",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "BusinessUnit",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "BusinessUnit",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "BusinessUnit",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "BusinessUnit",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "BusinessUnit",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "BusinessUnit",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "BusinessUnit",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "BusinessUnit",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "BusinessUnit",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "BusinessUnit",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "BusinessUnit",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "BusinessUnit",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.UpdateData(
                table: "BusinessUnit",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BusinessLocation", "BusinessunitDescription", "BusinessunitName" },
                values: new object[] { "Binugao, Toril, Davao City", "Ana's Breeders Farm Central Office", "ABFI Central" });

            migrationBuilder.UpdateData(
                table: "BusinessUnit",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BusinessLocation", "BusinessunitDescription", "BusinessunitName" },
                values: new object[] { "Binugao, Toril, Davao City", "SouthMin FeedMill Unit", "SFC" });

            migrationBuilder.UpdateData(
                table: "BusinessUnit",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BusinessLocation", "BusinessunitDescription", "BusinessunitName" },
                values: new object[] { "Davao City", "GSII Unit", "GSII" });

            migrationBuilder.UpdateData(
                table: "BusinessUnit",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BusinessLocation", "BusinessunitDescription", "BusinessunitName" },
                values: new object[] { "Binugao, Toril, Davao City", "SubZero Unit", "SubZero" });

            migrationBuilder.UpdateData(
                table: "BusinessUnit",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "BusinessLocation", "BusinessunitDescription", "BusinessunitName" },
                values: new object[] { "Dumoy, Toril, Davao City", "JPPI Unit", "JPPI" });

            migrationBuilder.UpdateData(
                table: "BusinessUnit",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "BusinessLocation", "BusinessunitDescription", "BusinessunitName" },
                values: new object[] { "Lanang, Davao City", "QPMI Unit", "QPMI" });

            migrationBuilder.UpdateData(
                table: "BusinessUnit",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "BusinessLocation", "BusinessunitDescription", "BusinessunitName" },
                values: new object[] { "FAIP Complex, Biao, Tugbok District, Davao City", "FAIP Unit", "FAIP" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BusinessUnit", "DateCreated", "PasswordHash" },
                values: new object[] { "ABFI Central", new DateTime(2024, 9, 27, 13, 47, 54, 868, DateTimeKind.Local).AddTicks(6338), "$2a$11$kAWylAyBx.MPkOFZ411AROuncH7BgVV9Oz9ggX51LQdidhcdmnZny" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BusinessUnit", "DateCreated", "PasswordHash" },
                values: new object[] { "FAIP", new DateTime(2024, 9, 27, 13, 47, 55, 53, DateTimeKind.Local).AddTicks(4310), "$2a$11$qoBE5BJuOgi2vR35WWfDg.aWwaUMv9sG0zMOowQYLUNCspXNMDT.a" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BusinessUnit", "DateCreated", "PasswordHash" },
                values: new object[] { "FAIP", new DateTime(2024, 9, 27, 13, 47, 55, 231, DateTimeKind.Local).AddTicks(9356), "$2a$11$fBkLBQBixtqWEtmE/Ru97ObiojW2RWhy35UTWp1wlzVj69ILj1xeW" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BusinessUnit", "DateCreated", "PasswordHash" },
                values: new object[] { "SubZero", new DateTime(2024, 9, 27, 13, 47, 55, 417, DateTimeKind.Local).AddTicks(1789), "$2a$11$afzrC12/ZGzeJ5TZ5xV0/uahfz2kpEUQ8KqV8v2LBH9tYiKJR.aqa" });
        }
    }
}
