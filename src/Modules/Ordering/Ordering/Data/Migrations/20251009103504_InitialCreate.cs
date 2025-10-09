using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ordering.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Ordering");

            migrationBuilder.CreateTable(
                name: "Orders",
                schema: "Ordering",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    BillingAddress_AddressLine = table.Column<string>(type: "character varying(180)", maxLength: 180, nullable: false),
                    BillingAddress_Country = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    BillingAddress_EmailAddress = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    BillingAddress_FirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    BillingAddress_LastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    BillingAddress_State = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    BillingAddress_ZipCode = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Payment_CVV = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    Payment_CardName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Payment_CardNumber = table.Column<string>(type: "character varying(24)", maxLength: 24, nullable: false),
                    Payment_Expiration = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Payment_PaymentMethod = table.Column<int>(type: "integer", nullable: false),
                    ShippingAddress_AddressLine = table.Column<string>(type: "character varying(180)", maxLength: 180, nullable: false),
                    ShippingAddress_Country = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ShippingAddress_EmailAddress = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ShippingAddress_FirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ShippingAddress_LastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ShippingAddress_State = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ShippingAddress_ZipCode = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                schema: "Ordering",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderId = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalSchema: "Ordering",
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                schema: "Ordering",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderName",
                schema: "Ordering",
                table: "Orders",
                column: "OrderName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems",
                schema: "Ordering");

            migrationBuilder.DropTable(
                name: "Orders",
                schema: "Ordering");
        }
    }
}
