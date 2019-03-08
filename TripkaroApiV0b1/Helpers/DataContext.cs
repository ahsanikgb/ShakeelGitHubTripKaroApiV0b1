using Microsoft.EntityFrameworkCore;
using TripkaroApiV0b1.MyDbContext;

namespace TripkaroApiV0b1.Helpers
{
    public class DataContext:DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<CurrentTrip> CurrentTrips { get; set; }
        public DbSet<TripVisitingPlaces> TripVisitingPlacess { get; set; }

    }
}
