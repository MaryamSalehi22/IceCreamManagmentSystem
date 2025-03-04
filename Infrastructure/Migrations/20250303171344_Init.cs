using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IceCreams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IceCreams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Toppings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Toppings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IceCreamToppings",
                columns: table => new
                {
                    IceCreamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ToppingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IceCreamToppings", x => new { x.IceCreamId, x.ToppingId });
                    table.ForeignKey(
                        name: "FK_IceCreamToppings_IceCreams_IceCreamId",
                        column: x => x.IceCreamId,
                        principalTable: "IceCreams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IceCreamToppings_Toppings_ToppingId",
                        column: x => x.ToppingId,
                        principalTable: "Toppings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "IceCreams",
                columns: new[] { "Id", "Name", "Price", "Size" },
                values: new object[,]
                {
                    { new Guid("5c5c94ee-cabd-4135-b83c-648fef2721e8"), "Strawberry", 6.00m, 2 },
                    { new Guid("603ff90e-ffc6-400a-b6af-bc6f36b6aacd"), "Chocolate", 5.50m, 1 },
                    { new Guid("77db44c0-6b18-4383-8ea1-f4872cd0e9cd"), "Vanilla", 5.00m, 0 }
                });

            migrationBuilder.InsertData(
                table: "Toppings",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("05550215-3b75-45db-9a0a-713fa862e581"), "Melted Chocolate", 1.50m },
                    { new Guid("6def5925-6269-491e-913e-0a50863472cd"), "Smarties", 1.00m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_IceCreamToppings_ToppingId",
                table: "IceCreamToppings",
                column: "ToppingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IceCreamToppings");

            migrationBuilder.DropTable(
                name: "IceCreams");

            migrationBuilder.DropTable(
                name: "Toppings");
        }
    }
}
