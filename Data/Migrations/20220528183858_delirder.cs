using Microsoft.EntityFrameworkCore.Migrations;

namespace Kid_PalaceA2.Data.Migrations
{
    public partial class delirder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Products2_ToyModelId",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_ToyModelId",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "ToyModelId",
                table: "OrderItems");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ToyModelId",
                table: "OrderItems",
                type: "int",
                nullable: true);

           

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ToyModelId",
                table: "OrderItems",
                column: "ToyModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Products2_ToyModelId",
                table: "OrderItems",
                column: "ToyModelId",
                principalTable: "Products2",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
