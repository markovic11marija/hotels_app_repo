using System;
using System.Collections.Generic;
using System.Text;
using HotelsReviewApp.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HotelsReviewApp.Infrastructure.Data.Ef.Configuration
{
   public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Email).HasMaxLength(255);
            builder.Property(u => u.DisplayName).HasMaxLength(255);
            builder.Property(u => u.Password).HasMaxLength(255);
            builder.HasMany(u => u.Reviews)
                .WithOne(r => r.ReviewAuthor);
        }
    }
}