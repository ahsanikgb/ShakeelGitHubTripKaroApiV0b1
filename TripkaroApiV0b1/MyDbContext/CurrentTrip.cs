using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TripkaroApiV0b1.MyDbContext
{
    public class CurrentTrip
    {
        [Key]
        public int CurrentTripId { get; set; }
        public string TripName { get; set; }
        public string StartingLocation { get; set; }
        public decimal TotalBudget { get; set; }
        public decimal Descount { get; set; }
        public int VisitingPlacesId { get; set; }   //
        public int TripDuration { get; set; }
        public string AdvisorsContact1 { get; set; }
        public string AdvisorsContact2 { get; set; }
        public int TotalSeats { get; set; }
        public int RemainingSeats { get; set; }
        public int TripPackgesId { get; set; }      //
        public string ImagesId { get; set; }
    }
}
