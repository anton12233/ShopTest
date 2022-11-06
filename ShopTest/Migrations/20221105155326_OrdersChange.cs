using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopTest.Migrations
{
    public partial class OrdersChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Cars_someCarid",
                table: "OrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Order_someOrderid",
                table: "OrderDetail");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetail_someCarid",
                table: "OrderDetail");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetail_someOrderid",
                table: "OrderDetail");

            migrationBuilder.DropColumn(
                name: "someCarid",
                table: "OrderDetail");

            migrationBuilder.DropColumn(
                name: "someOrderid",
                table: "OrderDetail");

            migrationBuilder.AlterColumn<int>(
                name: "orderID",
                table: "OrderDetail",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "carID",
                table: "OrderDetail",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_carID",
                table: "OrderDetail",
                column: "carID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_orderID",
                table: "OrderDetail",
                column: "orderID");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Cars_carID",
                table: "OrderDetail",
                column: "carID",
                principalTable: "Cars",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Order_orderID",
                table: "OrderDetail",
                column: "orderID",
                principalTable: "Order",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Cars_carID",
                table: "OrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Order_orderID",
                table: "OrderDetail");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetail_carID",
                table: "OrderDetail");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetail_orderID",
                table: "OrderDetail");

            migrationBuilder.AlterColumn<string>(
                name: "orderID",
                table: "OrderDetail",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "carID",
                table: "OrderDetail",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "someCarid",
                table: "OrderDetail",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "someOrderid",
                table: "OrderDetail",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_someCarid",
                table: "OrderDetail",
                column: "someCarid");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_someOrderid",
                table: "OrderDetail",
                column: "someOrderid");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Cars_someCarid",
                table: "OrderDetail",
                column: "someCarid",
                principalTable: "Cars",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Order_someOrderid",
                table: "OrderDetail",
                column: "someOrderid",
                principalTable: "Order",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
