using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ZavrsniTest.Models
{
    public class AppDbContext: IdentityDbContext<ApplicationUser>
    {


        public DbSet<Band> Bands { get; set; }

        public DbSet<Album> Albums { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Band>().HasData(
                new Band() { Id = 1, Name = "Pink Floyd", YearCreate = 1965 },
                new Band() { Id = 2, Name = "Europe", YearCreate = 1979 },
                new Band() { Id = 3, Name = "The Doors", YearCreate = 1965 }

                );

            builder.Entity<Album>().HasData(
                new Album() { Id = 1, Name ="La Woman", YearPublish= 1971, Genre= "rock", NumberOfSales =4, BandId = 3 },
                new Album() { Id = 2, Name = "The wall", YearPublish = 1979, Genre = "art rock", NumberOfSales = 30, BandId = 1 },
                new Album() { Id = 3, Name = "The final coutndown", YearPublish = 1986, Genre = "glam metal", NumberOfSales = 4, BandId = 2 },
                new Album() { Id = 4, Name = "Meddle", YearPublish = 1971, Genre = "rock", NumberOfSales = 2, BandId = 1 },
                new Album() { Id = 5, Name = "Strange Days", YearPublish = 1969, Genre = "rock", NumberOfSales = 1, BandId = 3 }
                );
            base.OnModelCreating(builder);
        }
    }
}
