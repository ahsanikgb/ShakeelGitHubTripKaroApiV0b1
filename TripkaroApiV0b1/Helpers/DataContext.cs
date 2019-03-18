using Microsoft.EntityFrameworkCore;
using TripkaroApiV0b1.MyDbContext;
using TripkaroApiV0b1.Dtos;

namespace TripkaroApiV0b1.Helpers
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
        }


        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

 
        public DbSet<User> Users { get; set; }
        public DbSet<CurrentTrip> CurrentTrips { get; set; }
        public DbSet<TripVisitingPlaces> TripVisitingPlacess { get; set; }
        public DbSet<TripPackges> TripPackgess { get; set; }
        public DbSet<UserSelfPackges> UserSelfPackgess { get; set; }
        public DbSet<SpecialOffer> SpecialOffers { get; set; }
        public DbSet<SpecialOfferUsers> SpecialOfferUserss { get; set; }
        public DbSet<SeatReservation> SeatReservations { get; set; }
        public DbSet<BookingCustomer> BookingCustomers { get; set; }
        public DbSet<BookingSeatToken> BookingSeatTokens { get; set; }

    }
}
