using Microsoft.EntityFrameworkCore;
using NewVidly2.Core.Models;

namespace NewVidly2.Persistence
{
    public class VidlyDbContext : DbContext
    {
        public VidlyDbContext(DbContextOptions<VidlyDbContext> options)
        : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Rental> Rentals { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Startup.Connection);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}