using HotelsReviewApp.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelsReviewApp.Infrastructure.Data.Ef.Configuration
{
   public class UserFavoriteHotelConfiguration : IEntityTypeConfiguration<UserFavoriteHotel>
    {
        public void Configure(EntityTypeBuilder<UserFavoriteHotel> builder)
        {
            builder.HasKey(uf => new { uf.UserId, uf.HotelId });
            builder.HasOne(uf => uf.User)
                .WithMany(u => u.FavoriteHotels)
                .HasForeignKey(h => h.UserId);
        }
    }
}
