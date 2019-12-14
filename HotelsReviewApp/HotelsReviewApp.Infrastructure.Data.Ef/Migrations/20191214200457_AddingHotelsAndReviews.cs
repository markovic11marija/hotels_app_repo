using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelsReviewApp.Infrastructure.Data.Ef.Migrations
{
    public partial class AddingHotelsAndReviews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HotelRating",
                table: "Review",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ReviewAuthorId",
                table: "Review",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Hotel",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(maxLength: 255, nullable: true),
                    DisplayName = table.Column<string>(maxLength: 255, nullable: true),
                    Password = table.Column<string>(maxLength: 255, nullable: true),
                    IsAdministrator = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Review_ReviewAuthorId",
                table: "Review",
                column: "ReviewAuthorId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Review_User_ReviewAuthorId",
                table: "Review",
                column: "ReviewAuthorId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hotel_User_UserId",
                table: "Hotel");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_User_ReviewAuthorId",
                table: "Review");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropIndex(
                name: "IX_Review_ReviewAuthorId",
                table: "Review");

            migrationBuilder.DropIndex(
                name: "IX_Hotel_UserId",
                table: "Hotel");

            migrationBuilder.DropColumn(
                name: "HotelRating",
                table: "Review");

            migrationBuilder.DropColumn(
                name: "ReviewAuthorId",
                table: "Review");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Hotel");
        }
    }
}
