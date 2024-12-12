using Microsoft.EntityFrameworkCore;
using DashboardApp.Data.Entity;

namespace DashboardApp.Contexts
{
    public class DashboardDb : DbContext
    {
        public DashboardDb(DbContextOptions<DashboardDb> options)
        : base(options)
        {
        }

        public DbSet<MainTopic>? MainTopics { get; set; }
        public DbSet<SubTopic>? SubTopics { get; set; }
        public DbSet<URL>? URLs { get; set; }
        public DbSet<Info>? Infos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=DashboardDb;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // SubTopic -> URLs ilişkisi için Cascade Delete
            modelBuilder.Entity<SubTopic>()
                .HasMany(st => st.URLs)
                .WithOne(u => u.SubTopic)
                .HasForeignKey(u => u.SubTopicId)
                .OnDelete(DeleteBehavior.Cascade);

            // SubTopic -> Infos ilişkisi için Cascade Delete
            modelBuilder.Entity<SubTopic>()
                .HasMany(st => st.Infos)
                .WithOne(i => i.SubTopic)
                .HasForeignKey(i => i.SubTopicId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}


