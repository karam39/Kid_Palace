using Microsoft.EntityFrameworkCore.Migrations;

namespace Kid_PalaceA2.Data.Migrations
{
    public partial class orderitemfk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Products2_ToyModelId",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "ToyModel",
                table: "OrderItems");

            migrationBuilder.AlterColumn<int>(
                name: "ToyModelId",
                table: "OrderItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Products2_ToyModelId",
                table: "OrderItems",
                column: "ToyModelId",
                principalTable: "Products2",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Products2_ToyModelId",
                table: "OrderItems");

            migrationBuilder.AlterColumn<int>(
                name: "ToyModelId",
                table: "OrderItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ToyModel",
                table: "OrderItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
