using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PISSolution.Server.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PropertyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateOfRegistration = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Ownerships",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PropertyID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContactID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EffectiveFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EffectiveTill = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AcquisitionPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ownerships", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Ownerships_Contacts_ContactID",
                        column: x => x.ContactID,
                        principalTable: "Contacts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ownerships_Properties_PropertyID",
                        column: x => x.PropertyID,
                        principalTable: "Properties",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PriceHistories",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PropertyID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceHistories", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PriceHistories_Properties_PropertyID",
                        column: x => x.PropertyID,
                        principalTable: "Properties",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ID", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("8e64ff31-f402-448d-9740-26cb97df4e2d"), "Brandon.Grech@gmail.com", "Brandon", "Grech", "79312905" },
                    { new Guid("a9b2b5de-3382-4c9a-bf68-6a0a3c8a8d2f"), "emily.scerri@gmail.com", "Emily", "Scerri", "79312999" },
                    { new Guid("d5b6b5de-c589-4702-8d6f-94b5a3a7c8c0"), "sarah.scerri@gmail.com", "Sarah", "Scerri", "79312888" },
                    { new Guid("fc3f5c7e-0981-4855-8f6d-85b8c7b2e3d2"), "michael.grech@gmail.com", "Michael", "Grech", "99312951" }
                });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "ID", "Address", "DateOfRegistration", "Price", "PropertyName" },
                values: new object[,]
                {
                    { new Guid("1a7c565e-5291-4a9f-8b19-7e2e2c1b9f0e"), "99 Problems Street", new DateTime(2019, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 600000.00m, "Country House" },
                    { new Guid("67f89a33-b92f-4ef0-b1c4-f0a8a6858dc0"), "123 Triq il-Hadd", new DateTime(2020, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 800000.00m, "Mercury Apartment" },
                    { new Guid("e0a63457-6a49-49b9-b28b-82d6d0a8e9c0"), "123 San Pawl Street", new DateTime(2021, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2500000.00m, "Luxury Villa" }
                });

            migrationBuilder.InsertData(
                table: "Ownerships",
                columns: new[] { "ID", "AcquisitionPrice", "ContactID", "EffectiveFrom", "EffectiveTill", "PropertyID" },
                values: new object[,]
                {
                    { new Guid("3993cfa6-69d4-461c-b777-19ddcfc02260"), 880000.00m, new Guid("8e64ff31-f402-448d-9740-26cb97df4e2d"), new DateTime(2020, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("67f89a33-b92f-4ef0-b1c4-f0a8a6858dc0") },
                    { new Guid("8574239f-b26d-4f0f-8139-462c857cbe35"), 1900000.00m, new Guid("fc3f5c7e-0981-4855-8f6d-85b8c7b2e3d2"), new DateTime(2019, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e0a63457-6a49-49b9-b28b-82d6d0a8e9c0") },
                    { new Guid("a364f17a-5b66-49ba-8036-29304edef650"), 2600000.00m, new Guid("d5b6b5de-c589-4702-8d6f-94b5a3a7c8c0"), new DateTime(2021, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("e0a63457-6a49-49b9-b28b-82d6d0a8e9c0") },
                    { new Guid("bf4f5d11-8dcc-4d42-9cd4-c4b41ebf840c"), 980000.00m, new Guid("fc3f5c7e-0981-4855-8f6d-85b8c7b2e3d2"), new DateTime(2019, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("1a7c565e-5291-4a9f-8b19-7e2e2c1b9f0e") },
                    { new Guid("d6eba0d9-54f0-48e5-a7bb-f190a7e7d57d"), 2000000.00m, new Guid("a9b2b5de-3382-4c9a-bf68-6a0a3c8a8d2f"), new DateTime(2020, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e0a63457-6a49-49b9-b28b-82d6d0a8e9c0") }
                });

            migrationBuilder.InsertData(
                table: "PriceHistories",
                columns: new[] { "ID", "Date", "Price", "PropertyID" },
                values: new object[,]
                {
                    { new Guid("1d80b087-d8ce-49f0-b8ca-fe512cb1b537"), new DateTime(2019, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 350000.00m, new Guid("67f89a33-b92f-4ef0-b1c4-f0a8a6858dc0") },
                    { new Guid("7c14dfac-7cf4-4ee5-a18a-efd2180e0693"), new DateTime(2022, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2400000.00m, new Guid("e0a63457-6a49-49b9-b28b-82d6d0a8e9c0") },
                    { new Guid("91bc57f6-a839-4b5b-9a01-e4f676a6e7bf"), new DateTime(2021, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 750000.00m, new Guid("67f89a33-b92f-4ef0-b1c4-f0a8a6858dc0") },
                    { new Guid("a0e93082-b311-409f-9047-0b8dfb1c0480"), new DateTime(2020, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 450000.00m, new Guid("67f89a33-b92f-4ef0-b1c4-f0a8a6858dc0") },
                    { new Guid("d009d871-5934-4eab-b16d-38dae7b64b9d"), new DateTime(2020, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2100000.00m, new Guid("e0a63457-6a49-49b9-b28b-82d6d0a8e9c0") },
                    { new Guid("d5a32d3a-d2d0-4ee0-aaf8-63c6ed0ef600"), new DateTime(2021, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2300000.00m, new Guid("e0a63457-6a49-49b9-b28b-82d6d0a8e9c0") },
                    { new Guid("ef9623e8-1649-4263-871a-4590c3e6873e"), new DateTime(2020, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 580000.00m, new Guid("1a7c565e-5291-4a9f-8b19-7e2e2c1b9f0e") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ownerships_ContactID",
                table: "Ownerships",
                column: "ContactID");

            migrationBuilder.CreateIndex(
                name: "IX_Ownerships_PropertyID",
                table: "Ownerships",
                column: "PropertyID");

            migrationBuilder.CreateIndex(
                name: "IX_PriceHistories_PropertyID",
                table: "PriceHistories",
                column: "PropertyID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ownerships");

            migrationBuilder.DropTable(
                name: "PriceHistories");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Properties");
        }
    }
}
