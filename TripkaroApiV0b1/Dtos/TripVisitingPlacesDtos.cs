using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TripkaroApiV0b1.Dtos
{
    public class TripVisitingPlacesDtos
    {
        [Key]
        public int TripVisitingPlacesid { get; set; }
        public string PlaceName { get; set; }
        public string Description { get; set; }
        public string NearestLocations { get; set; }
        public DateTime stayingHours { get; set; }

    }
}
