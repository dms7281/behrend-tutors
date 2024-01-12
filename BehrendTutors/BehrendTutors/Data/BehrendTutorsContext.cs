using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BehrendTutors.Models;
using BehrendTutors.Migrations;

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
        public DbSet<ClassTutor> ClassTutor { get; set; }
        public DbSet<BehrendTutors.Models.Admin> Admin { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships here
            modelBuilder.Entity<ClassTutor>()
            .HasKey(ct => new { ct.TutorId, ct.ClassId });

            modelBuilder.Entity<ClassTutor>()
            .HasOne(tc => tc.Tutor)
            .WithMany(t => t.ClassTutor)
            .HasForeignKey(tc => tc.TutorId);

            modelBuilder.Entity<ClassTutor>()
                .HasOne(tc => tc.Class)
                .WithMany(c => c.ClassTutor)
                .HasForeignKey(tc => tc.ClassId);
        }

    }
}
