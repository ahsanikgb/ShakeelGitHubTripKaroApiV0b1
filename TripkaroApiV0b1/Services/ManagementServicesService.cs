using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TripkaroApiV0b1.Helpers;
using TripkaroApiV0b1.MyDbContext;

namespace TripkaroApiV0b1.Services
{
    public interface IManagementServicesService
    {
        IEnumerable<CurrentTrip> GetAll();
        CurrentTrip GetById(int id);
        CurrentTrip Create(CurrentTrip trips);
        void Update(CurrentTrip trips);
        void Delete(int id);
    }


    public class ManagementServicesService : IManagementServicesService
    {
        
        private DataContext _context;
        public ManagementServicesService(DataContext context)
        {
            _context = context;
        }
        // users hardcoded for simplicity, store in a db with hashed passwords in production applications

        

        public IEnumerable<CurrentTrip> GetAll()
        {
            return _context.CurrentTrips;
        }

        public IEnumerable<CurrentTrip> GetAllTrips()
        {
          

            return _context.CurrentTrips;
        }

        public CurrentTrip GetById(int id)
        {
            return _context.CurrentTrips.Find(id);
        }

        public CurrentTrip Create(CurrentTrip trip)
        {


            if (_context.CurrentTrips.Any(x => x.TripName == trip.TripName))
                throw new AppException("TripName \"" + trip.TripName + "\" is already taken");


            _context.CurrentTrips.Add(trip);
            _context.SaveChanges();

            return trip;
        }

        public void Update(CurrentTrip trips)
        {
            var _trips = _context.CurrentTrips.Find(trips.CurrentTripId);

            if (_trips == null)
            {
                throw new AppException("User not found");
            }
            else
            {
                
                // update user properties\
                _trips.TripName = trips.TripName;
                _trips.StartingLocation = trips.StartingLocation;
                _trips.TotalBudget = trips.TotalBudget;
                _trips.Descount = trips.Descount;
                _trips.TripPackgesId = trips.TripPackgesId;
          //      _trips.VisitingPlacesId = trips.VisitingPlacesId;
                _trips.TripDuration = trips.TripDuration;
                _trips.AdvisorsContact1 = trips.AdvisorsContact1;
                _trips.AdvisorsContact2 = trips.AdvisorsContact2;
                _trips.UserId = trips.UserId;
                _trips.TotalSeats = trips.TotalSeats;
                _trips.RemainingSeats = trips.RemainingSeats;
                
            }


            _context.CurrentTrips.Update(_trips);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var trips = _context.CurrentTrips.Find(id);
            if (trips != null)
            {
                _context.CurrentTrips.Remove(trips);
                _context.SaveChanges();
            }
        }


    }
}
