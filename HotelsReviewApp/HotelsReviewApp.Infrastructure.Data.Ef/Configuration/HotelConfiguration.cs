using HotelsReviewApp.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelsReviewApp.Infrastructure.Data.Ef.Configuration
{
  public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasKey(h => h.Id);
            builder.Property(h => h.Name).HasMaxLength(255);
            builder.Property(h => h.Description).HasMaxLength(500);
            builder.OwnsOne(h => h.Address, ownedBuilder =>
            {
                ownedBuilder.Property(a => a.Street);
                ownedBuilder.Property(a => a.City);
                ownedBuilder.Property(a => a.Country);
                ownedBuilder.Property(a => a.HouseNumber);
                ownedBuilder.Property(a => a.HouseNumberAddition);
            });
            builder.OwnsOne(h => h.Image, ownedBuilder =>
            {
                ownedBuilder.Property(i => i.FileName);
                ownedBuilder.Property(i => i.FileBytes);
            });
            builder.OwnsOne(h => h.GeoLocation, ownedBuilder =>
            {
                ownedBuilder.Property(g => g.Latitude);
                ownedBuilder.Property(g => g.Longitude);
            });
            builder.HasMany(h => h.Reviews)
                .WithOne(a => a.ReviewedHotel);

        }
    }
}
