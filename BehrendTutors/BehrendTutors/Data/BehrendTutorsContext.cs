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
        
    }
}
