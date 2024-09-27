using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BatteryReceiving",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateReceived = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Receivedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DrsiNo = table.Column<int>(type: "int", nullable: true),
                    PoNo = table.Column<int>(type: "int", nullable: true),
                    ItemCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Supplier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    Unitofmeasurement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Batteryserial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DebossedNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemCategory = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BatteryReceiving", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BusinessUnit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessunitName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessunitDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessLocation = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessUnit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TireReceiving",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateReceived = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Receivedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DrciNo = table.Column<int>(type: "int", nullable: true),
                    PoNo = table.Column<int>(type: "int", nullable: true),
                    Supplier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    Unitofmeasurement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tiresize = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tirebrand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TireSerial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DebossedNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TireType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemCategory = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TireReceiving", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BatteryReleasing",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Imjno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Receivedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserplateNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BatteryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BatteryReleasing", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BatteryReleasing_BatteryReceiving_BatteryId",
                        column: x => x.BatteryId,
                        principalTable: "BatteryReceiving",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BatteryReturn",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceivedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Endorsedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BatteryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BatteryReturn", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BatteryReturn_BatteryReceiving_BatteryId",
                        column: x => x.BatteryId,
                        principalTable: "BatteryReceiving",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TireReleasing",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Imjno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Driver = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlateNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Abfiserialno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Receivedby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TireId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TireReleasing", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TireReleasing_TireReceiving_TireId",
                        column: x => x.TireId,
                        principalTable: "TireReceiving",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TireReturn",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceivedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndorsedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Purpose = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TireId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TireReturn", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TireReturn_TireReceiving_TireId",
                        column: x => x.TireId,
                        principalTable: "TireReceiving",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BatteryTransfer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransferDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BusinessUnitFrom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessUnitTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlateNoFrom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlateNoTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReleasingId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BatteryTransfer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BatteryTransfer_BatteryReleasing_ReleasingId",
                        column: x => x.ReleasingId,
                        principalTable: "BatteryReleasing",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TireTransfer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransferDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BusinessUnitFrom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessUnitTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlateNoFrom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlateNoTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReleasingId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TireTransfer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TireTransfer_TireReleasing_ReleasingId",
                        column: x => x.ReleasingId,
                        principalTable: "TireReleasing",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TireDisposal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DisposalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndorsedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TireReturnId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TireDisposal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TireDisposal_TireReturn_TireReturnId",
                        column: x => x.TireReturnId,
                        principalTable: "TireReturn",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TireRecap",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecappedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndorsedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TireReturnId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TireRecap", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TireRecap_TireReturn_TireReturnId",
                        column: x => x.TireReturnId,
                        principalTable: "TireReturn",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BusinessUnit",
                columns: new[] { "Id", "BusinessLocation", "BusinessunitDescription", "BusinessunitName" },
                values: new object[,]
                {
                    { 1, "Binugao, Toril, Davao City", "Ana's Breeders Farm Central Office", "ABFI Central" },
                    { 2, "Binugao, Toril, Davao City", "SouthMin FeedMill Unit", "SFC" },
                    { 3, "Davao City", "GSII Unit", "GSII" },
                    { 4, "Binugao, Toril, Davao City", "SubZero Unit", "SubZero" },
                    { 5, "Dumoy, Toril, Davao City", "JPPI Unit", "JPPI" },
                    { 6, "Lanang, Davao City", "QPMI Unit", "QPMI" },
                    { 7, "FAIP Complex, Biao, Tugbok District, Davao City", "FAIP Unit", "FAIP" }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Admin role for FAIP", "FAIPadmin" },
                    { 2, "Warehouse role for FAIP", "FAIPwarehouse" },
                    { 3, "Business Unit role", "BusinessUnit" },
                    { 4, "Super Admin Role", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "DateCreated", "Email", "FirstName", "LastName", "MiddleName", "PasswordHash", "Role", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 10, 21, 30, 18, 496, DateTimeKind.Local).AddTicks(6462), "admin@abfiph.com", "Admin", "User", "Admin", "$2a$11$rjMdjmJqh83g3Jm8CBCHo.w8HpEs2vSoBlvzFW.fPNceGAAjrBKFy", "Admin", "000-001" },
                    { 2, new DateTime(2024, 9, 10, 21, 30, 18, 659, DateTimeKind.Local).AddTicks(7468), "warehouse@abfiph.com", "Warehouse", "User", "Test", "$2a$11$SxAQpLDbiF.ag0DgkTPP3uK0cz53GN6L3PEnORBBFsuBi1LjqU5YS", "FAIPwarehouse", "000-002" },
                    { 3, new DateTime(2024, 9, 10, 21, 30, 18, 819, DateTimeKind.Local).AddTicks(5526), "faipAdmin@abfiph.com", "FAIP", "User", "Admin", "$2a$11$BWik4O3gOuwYgHGbgFrRzutrL/2J6Hf4wHzJ64uaF5jYHIB1smOtC", "FAIPadmin", "000-003" },
                    { 4, new DateTime(2024, 9, 10, 21, 30, 18, 986, DateTimeKind.Local).AddTicks(5050), "businessunit@abfiph.com", "Business", "User", "Unit", "$2a$11$.pDOV762yVHPSd41PEkB0Oc4eVKmS76xRigEx6lcNzKU2HQXsajBS", "BusinessUnit", "000-004" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BatteryReleasing_BatteryId",
                table: "BatteryReleasing",
                column: "BatteryId",
                unique: true,
                filter: "[BatteryId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BatteryReturn_BatteryId",
                table: "BatteryReturn",
                column: "BatteryId",
                unique: true,
                filter: "[BatteryId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BatteryTransfer_ReleasingId",
                table: "BatteryTransfer",
                column: "ReleasingId");

            migrationBuilder.CreateIndex(
                name: "IX_TireDisposal_TireReturnId",
                table: "TireDisposal",
                column: "TireReturnId",
                unique: true,
                filter: "[TireReturnId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TireRecap_TireReturnId",
                table: "TireRecap",
                column: "TireReturnId",
                unique: true,
                filter: "[TireReturnId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TireReleasing_TireId",
                table: "TireReleasing",
                column: "TireId",
                unique: true,
                filter: "[TireId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TireReturn_TireId",
                table: "TireReturn",
                column: "TireId",
                unique: true,
                filter: "[TireId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TireTransfer_ReleasingId",
                table: "TireTransfer",
                column: "ReleasingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BatteryReturn");

            migrationBuilder.DropTable(
                name: "BatteryTransfer");

            migrationBuilder.DropTable(
                name: "BusinessUnit");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "TireDisposal");

            migrationBuilder.DropTable(
                name: "TireRecap");

            migrationBuilder.DropTable(
                name: "TireTransfer");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "BatteryReleasing");

            migrationBuilder.DropTable(
                name: "TireReturn");

            migrationBuilder.DropTable(
                name: "TireReleasing");

            migrationBuilder.DropTable(
                name: "BatteryReceiving");

            migrationBuilder.DropTable(
                name: "TireReceiving");
        }
    }
}
