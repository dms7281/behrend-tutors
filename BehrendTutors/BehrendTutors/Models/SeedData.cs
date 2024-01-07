using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BehrendTutors.Data;
using System;
using System.Linq;

namespace BehrendTutors.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new BehrendTutorsContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<BehrendTutorsContext>>()))
        {
            // Look for any classes
            if (context.Class.Any())
            {
                return;   // DB has been seeded
            }
            context.Class.AddRange(
                new Class
                {
                    id = 21134,
                    Subject = "MATH",
                    CourseNum = 141,
                    SectionNum = 001,
                    ClassTitle = "Calculus 2"
                }

                //Pretty sure the way the seed data is set up is why the code wont run


            );
            context.SaveChanges();
        }
    }
}
