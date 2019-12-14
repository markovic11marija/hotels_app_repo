using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelsReviewApp.Infrastructure.Data.Ef.Migrations
{
    public partial class RemovingRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hotel_User_UserId",
                table: "Hotel");

            migrationBuilder.DropIndex(
                name: "IX_Hotel_UserId",
                table: "Hotel");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Hotel");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Hotel",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hotel_UserId",
                table: "Hotel",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hotel_User_UserId",
                table: "Hotel",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
