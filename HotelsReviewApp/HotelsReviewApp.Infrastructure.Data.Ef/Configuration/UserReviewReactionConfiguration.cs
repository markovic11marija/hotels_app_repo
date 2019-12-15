using HotelsReviewApp.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelsReviewApp.Infrastructure.Data.Ef.Configuration
{
    public class UserReviewReactionConfiguration : IEntityTypeConfiguration<UserReviewReaction>
    {
        public void Configure(EntityTypeBuilder<UserReviewReaction> builder)
        {
            builder.HasKey(ur => new { ur.UserId, ur.ReviewId, ur.ReactionType });
            builder.HasOne(ur => ur.User)
                .WithMany(u => u.ReviewReactions)
                .HasForeignKey(r => r.UserId);
            builder.HasOne(ur => ur.Review)
                .WithMany(r => r.UserReactions)
                .HasForeignKey(u => u.ReviewId);
        }
    }
}

