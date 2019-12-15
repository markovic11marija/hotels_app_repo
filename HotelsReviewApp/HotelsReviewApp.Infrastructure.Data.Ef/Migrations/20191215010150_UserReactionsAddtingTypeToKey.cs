using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelsReviewApp.Infrastructure.Data.Ef.Migrations
{
    public partial class UserReactionsAddtingTypeToKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserReviewReaction",
                table: "UserReviewReaction");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserReviewReaction",
                table: "UserReviewReaction",
                columns: new[] { "UserId", "ReviewId", "ReactionType" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserReviewReaction",
                table: "UserReviewReaction");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserReviewReaction",
                table: "UserReviewReaction",
                columns: new[] { "UserId", "ReviewId" });
        }
    }
}
