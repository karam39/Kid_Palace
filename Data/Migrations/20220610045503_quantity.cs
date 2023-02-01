using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kid_PalaceA2.Data.Migrations
{
    public partial class quantity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProdQuantity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productQuantity = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductPrice = table.Column<int>(type: "int", nullable: false),
                    ToyModelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdQuantity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProdQuantity_Products2_ToyModelId",
                        column: x => x.ToyModelId,
                        principalTable: "Products2",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProdQuantity_ToyModelId",
                table: "ProdQuantity",
                column: "ToyModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProdQuantity");
        }
    }
}
