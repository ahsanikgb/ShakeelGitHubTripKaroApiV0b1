using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace TripkaroApiV0b1.MyDbContext
{
    public class TripPackges
    {
        [Key]
        [IgnoreDataMember]
        public int TripPackgesId { get; set; }
        public string Name { get; set; }
        public int PackageQuantity { get; set; }
        public string Description { get; set; }
        public decimal EstimatedCost { get; set; }

        public string PackageType { get; set; }
        public int CurrentTripId { get; set; }
        public bool IsSpecialOffer { get; set; }
        public int SpecialOfferId { get; set; }
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
