using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using mvc_Tricked.Models;

namespace mvc_Tricked.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ProfileContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ProfileContext>>()))
            {
                // Look for any movies.
                if (context.Profile.Any())
                {
                    return;   // DB has been seeded
                }

                context.Profile.AddRange(
                    new Profile
                    {
                        Name = "Niclas H",
                        IGN = "Grannice",
                        Role = Roles.SUPPORT,
                        Elo = 1
                    },

                    new Profile
                    {
                        Name = "Casper J",
                        IGN = "StokkeFar",
                        Role = Roles.SUPPORT,
                        Elo = 1
                    },

                    new Profile
                    {
                        Name = "Tobias S",
                        IGN = "Stengaard",
                        Role = Roles.SUPPORT,
                        Elo = 1
                    },

                    new Profile
                    {
                        Name = "Lula Yvonna",
                        IGN = "BigBootyYvonna",
                        Role = Roles.SUPPORT,
                        Elo = 1
                    }
                );
                context.SaveChanges();
            }
        }
    }
}