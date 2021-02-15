using Microsoft.EntityFrameworkCore.Migrations;

namespace WPFProject.Migrations
{
    public partial class listChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wishlist_Movies_MovieId",
                table: "Wishlist");

            migrationBuilder.DropIndex(
                name: "IX_Wishlist_MovieId",
                table: "Wishlist");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "Wishlist");

            migrationBuilder.AddColumn<string>(
                name: "MovieTitle",
                table: "Wishlist",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MovieTitle",
                table: "Wishlist");

            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "Wishlist",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Wishlist_MovieId",
                table: "Wishlist",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Wishlist_Movies_MovieId",
                table: "Wishlist",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
