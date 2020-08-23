using System;
using System.Linq;
using MvcMovie.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.Internal;

namespace MvcMovie.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMovieContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcMovieContext>>()
                ))
            {
                if (context.Movie.Any())
                {
                    return;
                }

                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "When Harry met Sally",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Genre = "RomaticComedy",
                        Price = 7.69M,
                        Rating="R"
                    },
                    new Movie
                    {
                        Title = "Ghost",
                        ReleaseDate = DateTime.Parse("1984-3-19"),
                        Genre = "Comedy",
                        Price = 8.69M,
                        Rating="D"
                    },
                    new Movie
                    {
                        Title = "Rio",
                        ReleaseDate = DateTime.Parse("1974-5-25"),
                        Genre = "Romatic",
                        Price = 6.99M,
                        Rating="a"
                    }
                    );

                context.SaveChanges();
            }
        }
    }
}
