using HotelsReviewApp.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelsReviewApp.Infrastructure.Data.Ef.Configuration
{
  public  class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Description).HasMaxLength(500);
            builder.Property(r => r.HotelRating).HasConversion<string>().HasMaxLength(255);
        }
    }
}
