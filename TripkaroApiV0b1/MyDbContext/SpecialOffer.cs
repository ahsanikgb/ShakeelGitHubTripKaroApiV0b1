using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace TripkaroApiV0b1.MyDbContext
{
    public class SpecialOffer
    {
        [Key]
        [IgnoreDataMember]
        public int SpecialOfferId { get; set; }
        public string SpecialOfferName { get; set; }        //
        public string DealCode { get; set; }                //
        public decimal Descount { get; set; }               //
        public string Description { get; set; }              //
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
