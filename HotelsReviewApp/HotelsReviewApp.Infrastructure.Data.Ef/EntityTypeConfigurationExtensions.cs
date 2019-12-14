﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace HotelsReviewApp.Infrastructure.Data.Ef
{
    public static class EntityTypeConfigurationExtensions
    {
        private static readonly Dictionary<Assembly, IEnumerable<Type>> TypesPerAssembly =
            new Dictionary<Assembly, IEnumerable<Type>>();

        public static ModelBuilder UseEntityTypeConfiguration(this ModelBuilder modelBuilder, Assembly assembly)
        {
            if (!TypesPerAssembly.TryGetValue(assembly, out IEnumerable<Type> configurationTypes))
            {
                TypesPerAssembly[assembly] = configurationTypes = assembly
                    .GetExportedTypes()
                    .Where(x => x.GetTypeInfo().IsClass && !x.GetTypeInfo().IsAbstract && x.GetInterfaces().Any(y =>
                                    y.GetTypeInfo().IsGenericType && y.GetGenericTypeDefinition() ==
                                    typeof(IEntityTypeConfiguration<>)));
            }

            IEnumerable<object> configurations = configurationTypes.Select(Activator.CreateInstance);

            foreach (dynamic configuration in configurations)
            {
                ApplyConfiguration(modelBuilder, configuration);
            }

            return modelBuilder;
        }

        private static Type FindEntityType(Type type)
        {
            Type interfaceType = type.GetInterfaces().First(x =>
                x.GetTypeInfo().IsGenericType && x.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>));
            return interfaceType.GetGenericArguments().First();
        }

        private static readonly MethodInfo EntityMethod = typeof(ModelBuilder).GetTypeInfo().GetMethods()
            .Single(x => x.Name == "Entity" && x.IsGenericMethod && x.GetParameters().Length == 0); 

        private static void ApplyConfiguration<T>(this ModelBuilder modelBuilder,
            IEntityTypeConfiguration<T> configuration) where T : class
        {
            Type entityType = FindEntityType(configuration.GetType());

            dynamic entityTypeBuilder = EntityMethod
                .MakeGenericMethod(entityType)
                .Invoke(modelBuilder, new object[0]);

            configuration.Configure(entityTypeBuilder);
        }
    }
}