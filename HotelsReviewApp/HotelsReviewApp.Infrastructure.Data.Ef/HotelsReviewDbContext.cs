using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using HotelsReviewApp.Domain.Model;
using HotelsReviewApp.Infrastructure.Data.Ef.Configuration;

namespace HotelsReviewApp.Infrastructure.Data.Ef
{
  public  class HotelsReviewDbContext : DbContext
    {
        public Action<ModelBuilder> ModelBuilderConfigurator { private get; set; }
        public HotelsReviewDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseEntityTypeConfiguration(typeof(HotelConfiguration).Assembly);
          
            RegisterEntities(modelBuilder);

            ModelBuilderConfigurator?.Invoke(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void RegisterEntities(ModelBuilder modelBuilder) 
        {
            MethodInfo entityMethod = typeof(ModelBuilder).GetMethods().First(m => m.Name == "Entity" && m.IsGenericMethod);
      
            IEnumerable<Type> entityTypes = Assembly.GetAssembly(typeof(Hotel)).GetTypes()
                .Where(x => (x.IsSubclassOf(typeof(Entity)) && !x.IsAbstract)); 

            foreach (Type type in entityTypes)
            {
                entityMethod.MakeGenericMethod(type).Invoke(modelBuilder, new object[] { });
            }
        }
    }
}
