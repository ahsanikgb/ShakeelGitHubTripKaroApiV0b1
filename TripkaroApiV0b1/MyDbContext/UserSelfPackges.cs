using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace TripkaroApiV0b1.MyDbContext
{
    public class UserSelfPackges
    {
        [Key]
        [IgnoreDataMember]
        public int UserSelfPackgesId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal ActualCost { get; set; }
        public decimal Descount { get; set; }
        public decimal RecentCost { get; set; }

        public bool IsSpecialOfferUser { get; set; }
        public int SpecialOfferId { get; set; }
        [IgnoreDataMember]
        public int UserPackgesId { get; set; }
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
