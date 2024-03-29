﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace TripkaroApiV0b1.MyDbContext
{
    public class TripVisitingPlaces
    {
        [Key]
        [IgnoreDataMember]
        public int TripVisitingPlacesid { get; set; }
        public int CurrentTripId { get; set; }
        public string PlaceName { get; set; }
        public string Description { get; set; }
      //  public string ImagesId { get; set; }          //
        public string NearestLocations { get; set; }
        public string stayingHours { get; set; }
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
