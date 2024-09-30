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
                    { 16, "To be added", "To be added", "Research and Development" },
                    { 17, "To be added", "To be added", "GSII - Blown Film" },
                    { 18, "To be added", "To be added", "GSII - Recycling" },
                    { 19, "To be added", "To be added", "GSII - CHB/Ula" },
                    { 20, "To be added", "To be added", "HR FAIP" },
                    { 21, "To be added", "To be added", "FAIP Admin" },
                    { 22, "To be added", "To be added", "Dressing Plant" },
                    { 23, "To be added", "To be added", "QA Department" },
                    { 24, "To be added", "To be added", "Procurement" },
                    { 25, "To be added", "To be added", "Logistics and Warehouse" },
                    { 26, "To be added", "To be added", "Motor Pool" },
                    { 27, "To be added", "To be added", "SCC" }
                });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BusinessUnit", "DateCreated", "PasswordHash" },
                values: new object[] { "Cisdevo", new DateTime(2024, 9, 30, 8, 46, 9, 563, DateTimeKind.Local).AddTicks(5078), "$2a$11$yYRsZXiWru9iq9et35P2le4NUU8HOonzhaqQpPP9ObvM4BjX2QXnO" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BusinessUnit", "DateCreated", "PasswordHash" },
                values: new object[] { "Logistics and Warehouse", new DateTime(2024, 9, 30, 8, 46, 9, 736, DateTimeKind.Local).AddTicks(9002), "$2a$11$MJiwNjG9A9tA2.5E5psYwemOO0IOISHiJd0he10xf4Ps346zw26Ou" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BusinessUnit", "DateCreated", "PasswordHash" },
                values: new object[] { "FAIP Admin", new DateTime(2024, 9, 30, 8, 46, 9, 908, DateTimeKind.Local).AddTicks(5112), "$2a$11$cw3gPSiIIy1OyAdlkxDg8eiSKuoP2EFlgV5Zgs7kqdRXviVaSdPDC" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BusinessUnit", "DateCreated", "PasswordHash" },
                values: new object[] { "Subzero", new DateTime(2024, 9, 30, 8, 46, 10, 78, DateTimeKind.Local).AddTicks(388), "$2a$11$ObpbRWWqYstluKKH4s8vTOTrZvBcRdliov6b2TUq6xf2.oWjfX/RW" });
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

            migrationBuilder.DeleteData(
                table: "BusinessUnit",
                keyColumn: "Id",
                keyValue: 27);

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
    }
}
