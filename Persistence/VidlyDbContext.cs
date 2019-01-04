using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using NewVidly.Models;
using NewVidly2;

namespace NewVidly.Persistence
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
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Startup.Connection);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //  modelBuilder
            //     .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
            //     .HasAnnotation("Relational:MaxIdentifierLength", 128)
            //     .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            // modelBuilder.Entity("NewVidly.Models.Customer", b =>
            //     {
            //         b.Property<int>("Id")
            //             .ValueGeneratedOnAdd()
            //             .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            //         b.Property<DateTime?>("BirthdayDate");

            //         b.Property<bool>("IsSubscribetToNewsletter");

            //         b.Property<byte>("MembershipTypeId");

            //         b.Property<string>("Name")
            //             .IsRequired()
            //             .HasMaxLength(255);

            //         b.HasKey("Id");

            //         b.HasIndex("MembershipTypeId");

            //         b.ToTable("Customers");
            //     });

            // modelBuilder.Entity("NewVidly.Models.Genre", b =>
            //     {
            //         b.Property<byte>("Id");

            //         b.Property<string>("Name")
            //             .IsRequired();

            //         b.HasKey("Id");

            //         b.ToTable("Genres");
            //     });

            // modelBuilder.Entity("NewVidly.Models.MembershipType", b =>
            //     {
            //         b.Property<byte>("Id");

            //         b.Property<byte>("DiscountRate");

            //         b.Property<byte>("DurationInMonths");

            //         b.Property<string>("Name")
            //             .IsRequired();

            //         b.Property<short>("SignUpFee");

            //         b.HasKey("Id");

            //         b.ToTable("MembershipTypes");
            //     });

            // modelBuilder.Entity("NewVidly.Models.Movie", b =>
            //     {
            //         b.Property<int>("Id")
            //             .ValueGeneratedOnAdd()
            //             .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            //         b.Property<DateTime>("DateAdded");

            //         b.Property<byte>("GenreId");

            //         b.Property<string>("Name")
            //             .IsRequired();

            //         b.Property<int>("NumberAvailable");

            //         b.Property<int?>("NumberInStock");

            //         b.Property<DateTime?>("ReleasedDate");

            //         b.HasKey("Id");

            //         b.HasIndex("GenreId");

            //         b.ToTable("Movies");
            //     });

            // modelBuilder.Entity("NewVidly.Models.Rental", b =>
            //     {
            //         b.Property<int>("Id")
            //             .ValueGeneratedOnAdd()
            //             .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            //         b.Property<int>("CustomerId");

            //         b.Property<DateTime>("DateRented");

            //         b.Property<DateTime?>("DateReturned");

            //         b.Property<int>("MovieId");

            //         b.HasKey("Id");

            //         b.HasIndex("CustomerId");

            //         b.HasIndex("MovieId");

            //         b.ToTable("Rentals");
            //     });

            // modelBuilder.Entity("NewVidly.Models.Customer", b =>
            //     {
            //         b.HasOne("NewVidly.Models.MembershipType", "MemebershipType")
            //             .WithMany()
            //             .HasForeignKey("MembershipTypeId")
            //             .OnDelete(DeleteBehavior.Cascade);
            //     });

            // modelBuilder.Entity("NewVidly.Models.Movie", b =>
            //     {
            //         b.HasOne("NewVidly.Models.Genre", "Genre")
            //             .WithMany()
            //             .HasForeignKey("GenreId")
            //             .OnDelete(DeleteBehavior.Cascade);
            //     });

            // modelBuilder.Entity("NewVidly.Models.Rental", b =>
            //     {
            //         b.HasOne("NewVidly.Models.Customer", "Customer")
            //             .WithMany()
            //             .HasForeignKey("CustomerId")
            //             .OnDelete(DeleteBehavior.Cascade);

            //         b.HasOne("NewVidly.Models.Movie", "Movie")
            //             .WithMany()
            //             .HasForeignKey("MovieId")
            //             .OnDelete(DeleteBehavior.Cascade);
            //     });
        }
    }
}