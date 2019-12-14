using Microsoft.EntityFrameworkCore;

namespace HotelsReviewApp.Infrastructure.Data.Ef
{
    public static class DbInitializer
    {
        public static void Initialize(HotelsReviewDbContext context)
        {
            context.Database.Migrate();
            context.SaveChanges();
        }
    }
}

