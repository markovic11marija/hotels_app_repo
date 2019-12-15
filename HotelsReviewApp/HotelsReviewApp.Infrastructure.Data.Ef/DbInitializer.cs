using System.Collections.Generic;
using HotelsReviewApp.Infrastructure.Data.Ef.Seeding;
using Microsoft.EntityFrameworkCore;

namespace HotelsReviewApp.Infrastructure.Data.Ef
{
    public static class DbInitializer
    {
        private static readonly IList<ISeeding> Seedings = new List<ISeeding>();

        static DbInitializer()
        {
            Seedings.Add(new AdministratorsSeeding());
        }

        public static void Initialize(HotelsReviewDbContext context)
        {
            context.Database.Migrate();
            context.SaveChanges();
        }

        public static void Seed(HotelsReviewDbContext context)
        {
            foreach (ISeeding seeding in Seedings)
            {
                seeding.Seed(context);
                context.SaveChanges();
            }
        }
    }
}

