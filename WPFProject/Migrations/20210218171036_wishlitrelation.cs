using Microsoft.EntityFrameworkCore.Migrations;

namespace WPFProject.Migrations
{
    public partial class wishlitrelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Wishlist",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Wishlist_UserId",
                table: "Wishlist",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Wishlist_Users_UserId",
                table: "Wishlist",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wishlist_Users_UserId",
                table: "Wishlist");

            migrationBuilder.DropIndex(
                name: "IX_Wishlist_UserId",
                table: "Wishlist");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Wishlist");
        }
    }
}
