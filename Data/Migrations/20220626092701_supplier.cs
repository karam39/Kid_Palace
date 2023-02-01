using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kid_PalaceA2.Data.Migrations
{
    public partial class supplier : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProdQuantity");

            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                table: "Products2",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SupplierDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupplierPhoneNo = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierDetails", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products2_SupplierId",
                table: "Products2",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products2_SupplierDetails_SupplierId",
                table: "Products2",
                column: "SupplierId",
                principalTable: "SupplierDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products2_SupplierDetails_SupplierId",
                table: "Products2");

            migrationBuilder.DropTable(
                name: "SupplierDetails");

            migrationBuilder.DropIndex(
                name: "IX_Products2_SupplierId",
                table: "Products2");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "Products2");

            migrationBuilder.CreateTable(
                name: "ProdQuantity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductPrice = table.Column<int>(type: "int", nullable: false),
                    ToyModelId = table.Column<int>(type: "int", nullable: false),
                    productQuantity = table.Column<int>(type: "int", nullable: false)
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
    }
}
