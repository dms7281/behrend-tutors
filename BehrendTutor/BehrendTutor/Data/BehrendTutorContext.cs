using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BehrendTutor.Models;

namespace BehrendTutor.Data
{
    public class BehrendTutorContext : DbContext
    {
        public BehrendTutorContext(DbContextOptions<BehrendTutorContext> options)
            : base(options)
        {
        }

        public DbSet<Class> Class { get; set; } = default!;
        public DbSet<SubjectType> SubjectType { get; set; } = default!;
        public DbSet<Person> Person { get; set; } = default!;
        public DbSet<PersonType> PersonType { get; set; } = default!;
        public DbSet<TutorSession> TutorSession { get; set; } = default!;
        public DbSet<SessionLocationType> SessionLocationType { get; set; } = default!;
        public DbSet<TutorSessionType> TutorSessionType { get; set; } = default!;
        public DbSet<TutorClass> TutorClass { get; set; } = default!;
    }
    }
