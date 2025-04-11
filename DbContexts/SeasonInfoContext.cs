using Microsoft.EntityFrameworkCore;
using DWFCxx.Entities;

namespace DWFCxx.DbContexts
{
    public class SeasonInfoContext : DbContext
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("connectionstring");

        //    base.OnConfiguring(optionsBuilder);
        //}


        public DbSet<Match> Matches { get; set; }

        public DbSet<Season> Seasons { get; set; }

    }
}
