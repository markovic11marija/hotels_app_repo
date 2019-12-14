using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelsReviewApp.Infrastructure.Data.Ef.Migrations
{
    public partial class UserReactions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserReviewReaction",
                columns: table => new
                {
                    ReviewId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    ReactionType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserReviewReaction", x => new { x.UserId, x.ReviewId });
                    table.ForeignKey(
                        name: "FK_UserReviewReaction_Review_ReviewId",
                        column: x => x.ReviewId,
                        principalTable: "Review",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserReviewReaction_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserReviewReaction_ReviewId",
                table: "UserReviewReaction",
                column: "ReviewId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserReviewReaction");
        }
    }
}
