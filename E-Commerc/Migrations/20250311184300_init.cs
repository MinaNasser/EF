using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E_Commerc.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StockHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ChangeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    QuantityChanged = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockHistories_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shippings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ShippedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shippings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shippings_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Email", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "john@example.com", "John Doe", "123456789" },
                    { 2, "jane@example.com", "Jane Doe", "987654321" },
                    { 3, "alice@example.com", "Alice Brown", "555123456" },
                    { 4, "bob@example.com", "Bob Smith", "666987654" },
                    { 5, "charlie@example.com", "Charlie Johnson", "777654321" },
                    { 6, "david@example.com", "David Wilson", "888123987" },
                    { 7, "eve@example.com", "Eve Taylor", "999654789" },
                    { 8, "frank@example.com", "Frank White", "111222333" },
                    { 9, "grace@example.com", "Grace Hall", "444555666" },
                    { 10, "hank@example.com", "Hank Adams", "777888999" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Price", "StockQuantity" },
                values: new object[,]
                {
                    { 1, "Laptop", 1000m, 50 },
                    { 2, "Phone", 500m, 100 },
                    { 3, "Tablet", 300m, 80 },
                    { 4, "Monitor", 200m, 70 },
                    { 5, "Keyboard", 50m, 150 },
                    { 6, "Mouse", 30m, 200 },
                    { 7, "Headphones", 80m, 120 },
                    { 8, "Smart Watch", 150m, 90 },
                    { 9, "Speaker", 60m, 110 },
                    { 10, "USB Drive", 20m, 300 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CustomerId", "OrderDate", "TotalAmount" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1500m },
                    { 2, 2, new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 800m },
                    { 3, 3, new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 600m },
                    { 4, 4, new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1200m },
                    { 5, 5, new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 500m }
                });

            migrationBuilder.InsertData(
                table: "StockHistories",
                columns: new[] { "Id", "ChangeDate", "ProductId", "QuantityChanged" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, -1 },
                    { 2, new DateTime(2024, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, -1 },
                    { 3, new DateTime(2024, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, -2 },
                    { 4, new DateTime(2024, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, -1 },
                    { 5, new DateTime(2024, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, -2 }
                });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "Id", "OrderId", "ProductId", "Quantity", "UnitPrice" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, 1000m },
                    { 2, 1, 2, 1, 500m },
                    { 3, 2, 3, 2, 300m },
                    { 4, 3, 4, 1, 200m },
                    { 5, 3, 5, 2, 50m }
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "IsPaid", "OrderId", "PaymentMethod" },
                values: new object[,]
                {
                    { 1, true, 1, "Credit Card" },
                    { 2, true, 2, "PayPal" },
                    { 3, false, 3, "Bank Transfer" }
                });

            migrationBuilder.InsertData(
                table: "Shippings",
                columns: new[] { "Id", "Address", "OrderId", "ShippedDate" },
                values: new object[,]
                {
                    { 1, "123 Main St, NY", 1, new DateTime(2024, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "456 Elm St, LA", 2, new DateTime(2024, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "789 Oak St, TX", 3, new DateTime(2024, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_OrderId",
                table: "Payments",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Shippings_OrderId",
                table: "Shippings",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StockHistories_ProductId",
                table: "StockHistories",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Shippings");

            migrationBuilder.DropTable(
                name: "StockHistories");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
