using BookStore.Api.Data;
using BookStore.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Api.Extensions
{
    public static class WebApplicationExtensions
    {
        public static IApplicationBuilder InitializeMigration(this IApplicationBuilder builder)
        {
            using (var serviceScope = builder.ApplicationServices.GetService<IServiceScopeFactory>()!.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();
                context.Database.Migrate();
            }

            return builder;
        }

        public static IApplicationBuilder SeedData(this IApplicationBuilder builder)
        {
            using (var serviceScope = builder.ApplicationServices.GetService<IServiceScopeFactory>()!.CreateScope())
            {

                var context = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();
                if (!context.Books.Any())
                {
                    context.Books.AddRange(
                        new Book { Title = "The Great Gatsby", PublishDate = new DateTime(1925, 1, 1) },
                        new Book { Title = "One Hundred Years of Solitude", PublishDate = new DateTime(1967, 1, 1) },
                        new Book { Title = "Jane Eyre", PublishDate = new DateTime(1847, 1, 1) },
                        new Book { Title = "To Kill a Mockingbird", PublishDate = new DateTime(1960, 1, 1) },
                        new Book { Title = "Anna Karenina", PublishDate = new DateTime(1877, 1, 1) },
                        new Book { Title = "Don Quixote", PublishDate = new DateTime(1605, 1, 1) },
                        new Book { Title = "Nineteen Eighty-Four", PublishDate = new DateTime(1949, 1, 1) },
                        new Book { Title = "The Catcher in the Rye", PublishDate = new DateTime(1951, 1, 1) },
                        new Book { Title = "Adventures of Huckleberry Finn", PublishDate = new DateTime(1884, 1, 1) }
                        );

                    context.SaveChanges();
                }
            }

            return builder;
        }
    }
}
