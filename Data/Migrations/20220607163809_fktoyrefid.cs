using Microsoft.EntityFrameworkCore.Migrations;

namespace Kid_PalaceA2.Data.Migrations
{
    public partial class fktoyrefid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Products2_Toyrefid",
                table: "Products2",
                column: "Toyrefid");

            migrationBuilder.AddForeignKey(
                name: "FK_Products2_ProductCategory_Toyrefid",
                table: "Products2",
                column: "Toyrefid",
                principalTable: "ProductCategory",
                principalColumn: "ProductCategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products2_ProductCategory_Toyrefid",
                table: "Products2");

            migrationBuilder.DropIndex(
                name: "IX_Products2_Toyrefid",
                table: "Products2");
        }
    }
}
