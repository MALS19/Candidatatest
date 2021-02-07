using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace CandidatesPortal.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DataBaseContext(
                serviceProvider.GetRequiredService<DbContextOptions<DataBaseContext>>()))
            {
                // Look for any data already in database.
                if (context.CandidateDatas.Any())
                {
                    return;   // Database has been seeded
                }
                context.CandidateDatas.AddRange(
                   new CandidateData
                   {
                       Id = 1,
                       FirstName = "Luke",
                       LastName = "Skywalker",
                       IsSelected = true
                   },
                   new CandidateData
                   {
                       Id = 2,
                       FirstName = "Josh",
                       LastName = "Smith",
                       IsSelected = false
                   },
                   new CandidateData
                   {
                       Id = 3,
                       FirstName = "Ray",
                       LastName = "Hope",
                       IsSelected = false
                   },
                   new CandidateData
                   {
                       Id =4,
                       FirstName = "Valentina",
                       LastName = "Palker",
                       IsSelected = true
                   });


                context.SaveChanges();

            }
        }
    }
}
