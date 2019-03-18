using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace TripkaroApiV0b1.MyDbContext
{
    public class BookingSeatToken
    {
        [Key]
        [IgnoreDataMember]
        public int BookingTokenId { get; set; }
        public string NameOfPerson { get; set; }
        public int SeatNumber { get; set; }
        public int TotalSeats { get; set; }
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
