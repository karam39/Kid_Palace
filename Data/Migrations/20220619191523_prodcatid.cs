using Microsoft.EntityFrameworkCore.Migrations;

namespace Kid_PalaceA2.Data.Migrations
{
    public partial class prodcatid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products2_ProductCategory_Toyrefid",
                table: "Products2");

            migrationBuilder.RenameColumn(
                name: "Toyrefid",
                table: "Products2",
                newName: "ProdCategoryid");

            migrationBuilder.RenameIndex(
                name: "IX_Products2_Toyrefid",
                table: "Products2",
                newName: "IX_Products2_ProdCategoryid");

            migrationBuilder.AddForeignKey(
                name: "FK_Products2_ProductCategory_ProdCategoryid",
                table: "Products2",
                column: "ProdCategoryid",
                principalTable: "ProductCategory",
                principalColumn: "ProductCategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products2_ProductCategory_ProdCategoryid",
                table: "Products2");

            migrationBuilder.RenameColumn(
                name: "ProdCategoryid",
                table: "Products2",
                newName: "Toyrefid");

            migrationBuilder.RenameIndex(
                name: "IX_Products2_ProdCategoryid",
                table: "Products2",
                newName: "IX_Products2_Toyrefid");

            migrationBuilder.AddForeignKey(
                name: "FK_Products2_ProductCategory_Toyrefid",
                table: "Products2",
                column: "Toyrefid",
                principalTable: "ProductCategory",
                principalColumn: "ProductCategoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
