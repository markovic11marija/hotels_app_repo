using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelsReviewApp.Infrastructure.Data.Ef.Migrations
{
    public partial class UserReactionsLikesAndDislikes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReactionType",
                table: "UserReviewReaction");

            migrationBuilder.AddColumn<bool>(
                name: "Disliked",
                table: "UserReviewReaction",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Liked",
                table: "UserReviewReaction",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Disliked",
                table: "UserReviewReaction");

            migrationBuilder.DropColumn(
                name: "Liked",
                table: "UserReviewReaction");

            migrationBuilder.AddColumn<int>(
                name: "ReactionType",
                table: "UserReviewReaction",
                nullable: false,
                defaultValue: 0);
        }
    }
}
