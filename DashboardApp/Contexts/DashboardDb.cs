using Microsoft.EntityFrameworkCore;
using DashboardApp.Data.Entity;
using System.Collections.Generic;
using System.Reflection.Emit;


namespace DashboardApp.Contexts
{
    public class DashboardDb : DbContext 
    {
        public DashboardDb(DbContextOptions<DashboardDb> options)
        : base(options)
        {

        }
        public DbSet<MainTopic> MainTopics { get; set; }
        public DbSet<SubTopic> SubTopics { get; set; }
        public DbSet<URL> URLs { get; set; }
        public DbSet<Info> Infos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=DashboardDb;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder);

    }
}
