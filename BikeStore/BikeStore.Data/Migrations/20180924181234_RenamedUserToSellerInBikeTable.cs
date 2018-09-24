using Microsoft.EntityFrameworkCore.Migrations;

namespace BikeStore.Data.Migrations
{
    public partial class RenamedUserToSellerInBikeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bikes_AspNetUsers_UserId",
                table: "Bikes");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Bikes",
                newName: "SellerId");

            migrationBuilder.RenameIndex(
                name: "IX_Bikes_UserId",
                table: "Bikes",
                newName: "IX_Bikes_SellerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bikes_AspNetUsers_SellerId",
                table: "Bikes",
                column: "SellerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bikes_AspNetUsers_SellerId",
                table: "Bikes");

            migrationBuilder.RenameColumn(
                name: "SellerId",
                table: "Bikes",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Bikes_SellerId",
                table: "Bikes",
                newName: "IX_Bikes_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bikes_AspNetUsers_UserId",
                table: "Bikes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
