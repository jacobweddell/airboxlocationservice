using Microsoft.EntityFrameworkCore;

namespace AirboxInterview.LocationService.Models
{
    public class UserLocationContext : DbContext
    {
        //Unit test require parameterless constructor
        public UserLocationContext()
        {
        }

        public UserLocationContext(DbContextOptions<UserLocationContext> options)
            : base(options)
        { }

        public DbSet<UserLocation> UserLocation { get; set; }
    }
}
