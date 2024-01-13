using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BehrendTutors.Models;

namespace BehrendTutors.Data
{
    public class BehrendTutorsContext : DbContext
    {
        public BehrendTutorsContext (DbContextOptions<BehrendTutorsContext> options)
            : base(options)
        {
        }

        public DbSet<BehrendTutors.Models.Class> Class { get; set; }
        public DbSet<BehrendTutors.Models.Tutor> Tutor { get; set; }
        public DbSet<BehrendTutors.Models.TutorSession> TutorSession { get; set; }
        public DbSet<BehrendTutors.Models.Admin> Admin { get; set; } = default!;
        public DbSet<TutorClass> TutorClass { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TutorClass>()
                .HasKey(tc => new { tc.TutorId, tc.ClassId });

            modelBuilder.Entity<TutorClass>()
                .HasOne(tc => tc.Tutor)
                .WithMany(t => t.TutorClasses)
                .HasForeignKey(tc => tc.TutorId);

            modelBuilder.Entity<TutorClass>()
                .HasOne(tc => tc.Class)
                .WithMany(t => t.TutorClasses)
                .HasForeignKey(tc => tc.ClassId);
        }

    }
}
