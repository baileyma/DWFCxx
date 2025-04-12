using Microsoft.EntityFrameworkCore;
using DWFCxx.Entities;
using System.Reflection.Emit;

namespace DWFCxx.DbContexts
{
    public class SeasonInfoContext : DbContext
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("connectionstring");

        //    base.OnConfiguring(optionsBuilder);
        //}


        public SeasonInfoContext(DbContextOptions<SeasonInfoContext> options)
            : base(options)
        {
           
        }

        public DbSet<Match> Matches { get; set; }

        public DbSet<Season> Seasons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Season>()
                .HasData(
                new Season(1, "Spring", 2025),
                new Season(2, "Summer", 2025),
                new Season(3, "Autumn", 2025),
                new Season(4, "Winter", 2026)
                );

            modelBuilder.Entity<Match>()
                .HasData(
                new Match(1, 1, 1, new DateTime(2025, 4, 7), 4, 1),
                new Match(2, 2, 2, new DateTime(2025, 4, 14), 3, 3),
                new Match(3, 3, 3, new DateTime(2025, 4, 21), 3, 5)
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
