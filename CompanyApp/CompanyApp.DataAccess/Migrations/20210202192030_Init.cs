using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyApp.DataAccess.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Manager = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size = table.Column<double>(type: "float", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Warehouses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SupplyActivities",
                columns: table => new
                {
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    WarehouseId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    DateOfSupply = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplyActivities", x => new { x.StoreId, x.WarehouseId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_SupplyActivities_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SupplyActivities_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SupplyActivities_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Product1" },
                    { 2, "Product2" },
                    { 3, "Product3" },
                    { 4, "Product4" },
                    { 5, "Product5" }
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "Id", "Address", "Manager", "Name", "PhoneNumber", "Size", "Type" },
                values: new object[,]
                {
                    { 1, "StoreAddress 1", "John Doe", "Store1", "070/111-111", 55.0, 1 },
                    { 2, "StoreAddress 2", "John Doe", "Store2", "070/222-222", 77.700000000000003, 2 },
                    { 3, "StoreAddress 3", "John Doe", "Store3", "070/333-333", 55.5, 3 }
                });

            migrationBuilder.InsertData(
                table: "Warehouses",
                columns: new[] { "Id", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Warehouse1", "071/111-111" },
                    { 2, "Warehouse2", "071/121-212" }
                });

            migrationBuilder.InsertData(
                table: "SupplyActivities",
                columns: new[] { "ProductId", "StoreId", "WarehouseId", "DateOfSupply", "Id", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2021, 2, 2, 20, 20, 29, 816, DateTimeKind.Local).AddTicks(262), 1, 1 },
                    { 2, 1, 1, new DateTime(2021, 2, 2, 20, 20, 29, 820, DateTimeKind.Local).AddTicks(9921), 2, 3 },
                    { 3, 1, 1, new DateTime(2021, 2, 2, 20, 20, 29, 820, DateTimeKind.Local).AddTicks(9975), 3, 5 },
                    { 5, 3, 1, new DateTime(2021, 2, 2, 20, 20, 29, 820, DateTimeKind.Local).AddTicks(9987), 6, 7 },
                    { 2, 3, 1, new DateTime(2021, 2, 2, 20, 20, 29, 820, DateTimeKind.Local).AddTicks(9990), 7, 11 },
                    { 4, 2, 2, new DateTime(2021, 2, 2, 20, 20, 29, 820, DateTimeKind.Local).AddTicks(9981), 4, 3 },
                    { 4, 3, 2, new DateTime(2021, 2, 2, 20, 20, 29, 820, DateTimeKind.Local).AddTicks(9984), 5, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SupplyActivities_ProductId",
                table: "SupplyActivities",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplyActivities_WarehouseId",
                table: "SupplyActivities",
                column: "WarehouseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SupplyActivities");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Stores");

            migrationBuilder.DropTable(
                name: "Warehouses");
        }
    }
}
