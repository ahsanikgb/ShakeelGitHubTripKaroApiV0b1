using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace TripkaroApiV0b1.MyDbContext
{
    public class SeatReservation
    {
        [Key]
        [IgnoreDataMember]
        public int SeatReservationId { get; set; }
        public string ReservationName { get; set; }
        public int BookingTokenId { get; set; }
        /// <summary>
        /// Used For Seat Conformation
        /// </summary>
        public int ReservedSeatNumber { get; set; }
        public int RemainingSeats { get; set; }
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
