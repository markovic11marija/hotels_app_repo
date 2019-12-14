using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelsReviewApp.Infrastructure.Data.Ef.Migrations
{
    public partial class FavoriteHotelAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserFavoriteHotel",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    HotelId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFavoriteHotel", x => new { x.UserId, x.HotelId });
                    table.ForeignKey(
                        name: "FK_UserFavoriteHotel_Hotel_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserFavoriteHotel_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserFavoriteHotel_HotelId",
                table: "UserFavoriteHotel",
                column: "HotelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserFavoriteHotel");
        }
    }
}
