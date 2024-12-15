namespace MagicVilla_VillaAPI
{
    using MagicVilla_VillaAPI.Models;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Defines the <see cref="ApplicationDbContext" />
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class.
        /// </summary>
        /// <param name="options">The options<see cref="DbContextOptions{ApplicationDbContext}"/></param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the Villas_API
        /// </summary>
        public DbSet<Villa> Villas_API { get; set; }

        /// <summary>
        /// The OnModelCreating
        /// </summary>
        /// <param name="modelBuilder">The modelBuilder<see cref="ModelBuilder"/></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Villa>().HasData(
                new Villa()
                {
                    Id = 1,
                    Name = "Royal Villa",
                    CreatedDate = DateTime.Now,
                    Details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                    ImageUrl = "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa3.jpg",
                    Rate = 200.0,
                    Sqft = 550,
                    Occupancy = 4,
                    Amenity = "",
                    
                },
                new Villa()
                {
                    Id = 2,
                    Name = "Premium Pool Villa",
                    CreatedDate = DateTime.Now,
                    Details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                    ImageUrl = "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa1.jpg",
                    Rate = 300.0,
                    Sqft = 550,
                    Occupancy = 4,
                    Amenity = "",
                },
                new Villa()
                {
                    Id = 3,
                    Name = "Luxury Pool Villa",
                    CreatedDate = DateTime.Now,
                    Details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                    ImageUrl = "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa4.jpg",
                    Rate = 400.0,
                    Sqft = 750,
                    Occupancy = 4,
                    Amenity = "",
                },
                new Villa()
                {
                    Id = 4,
                    Name = "Diamond Villa",
                    CreatedDate = DateTime.Now,
                    Details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                    ImageUrl = "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa5.jpg",
                    Rate = 550.0,
                    Sqft = 900,
                    Occupancy = 4,
                    Amenity = "",
                },
                new Villa()
                {
                    Id = 5,
                    Name = "Diamond Pool Villa",
                    CreatedDate = DateTime.Now,
                    Details = "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.",
                    ImageUrl = "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa2.jpg",
                    Rate = 600.0,
                    Sqft = 1100,
                    Occupancy = 4,
                    Amenity = "",
                });
        }
    }
}
