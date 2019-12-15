using System;
using System.Linq;
using HotelsReviewApp.Domain.Model;

namespace HotelsReviewApp.Infrastructure.Data.Ef.Seeding
{
    public class AdministratorsSeeding : ISeeding
    {
        public void Seed(HotelsReviewDbContext context)
        {
            IQueryable<User> admins = context.Set<User>().Where(a => a.IsAdministrator);
            if (!admins.Any())
            {
                context.Add(new User("markovicmarija@gmail.com", "marijam", "pass123", true));
                context.Add(new User("petarpetrovic@gmail.com", "petar23", "jidjqowdi5263", true));
                context.Add(new User("goranmicic@gmail.com", "goran64", "hchcdsd54d44", true));
                context.SaveChanges();
            }
        }
    }
}
