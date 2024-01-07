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
                    Subject = "MATH",
                    CourseNum = 141,
                    SectionNum = 001,
                    ClassTitle = "Calculus 2",
                    ClassNum = 23415
                },
                new Class
                {
                    Subject = "SWENG",
                    CourseNum = 411,
                    SectionNum = 001,
                    ClassTitle = "Software Engineering",
                    ClassNum = 21231
                },
                new Class
                {
                    Subject = "ENGL",
                    CourseNum = 15,
                    SectionNum = 001,
                    ClassTitle = "Rehtoric and Composition",
                    ClassNum = 25632
                },
                new Class
                {
                    Subject = "CMPSC",
                    CourseNum = 465,
                    SectionNum = 001,
                    ClassTitle = "Data Structures and Algorithms",
                    ClassNum = 29231
                },
                new Class
                {
                    Subject = "HIED",
                    CourseNum = 302,
                    SectionNum = 001,
                    ClassTitle = "Resident Assistant",
                    ClassNum = 24328
                }

                //Pretty sure the way the seed data is set up is why the code wont run


            );
            context.SaveChanges();
        }
    }
}
