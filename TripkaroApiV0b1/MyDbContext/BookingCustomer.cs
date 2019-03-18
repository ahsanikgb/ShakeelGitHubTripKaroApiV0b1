using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace TripkaroApiV0b1.MyDbContext
{
    public class BookingCustomer
    {
        [Key]
        [IgnoreDataMember]
        public int BookingCustomerId { get; set; }
        public int CustomerName { get; set; }
        public int CustomerId { get; set; }
        public string phoneNumber { get; set; }
        public int PackgesId { get; set; }
        public bool IsSpecialOfferUser { get; set; }
        public int SpecialOfferId { get; set; }
        public bool IsCustomPackegeUser { get; set; }
        public int CustomPackgesId { get; set; }
        public decimal TotalPaid { get; set; }
        public decimal RemaningBudget { get; set; }
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
