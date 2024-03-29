﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using TripkaroApiV0b1.Dtos;

namespace TripkaroApiV0b1.MyDbContext
{
    public class CurrentTrip
    {
        [Key]
        [IgnoreDataMember]
        public int CurrentTripId { get; set; }
        public string TripName { get; set; }
        public string StartingLocation { get; set; }
        public decimal TotalBudget { get; set; }
        public decimal Descount { get; set; }
        //   public int VisitingPlacesId { get; set; }   
        public DateTime DateOfDeparture { get; set; }
        public DateTime DateOfArival { get; set; }
        public string TripDuration { get; set; }
        public string AdvisorsContact1 { get; set; }
        public string AdvisorsContact2 { get; set; }
        public int TotalSeats { get; set; }
        public int RemainingSeats { get; set; }
        public int TripPackgesId { get; set; }      //
        [IgnoreDataMember]
        public int UserId { get; set; }
        [IgnoreDataMember]
        public int ModifiedUserId { get; set; }
        [IgnoreDataMember]
        public string CreatedBy { get; set; }
        [IgnoreDataMember]
        public DateTime CreatedDate { get; set; }
        [IgnoreDataMember]
        public string ModifiedBy { get; set; }
        [IgnoreDataMember]
        public DateTime ModifiedDate { get; set; }
 


    }
}
