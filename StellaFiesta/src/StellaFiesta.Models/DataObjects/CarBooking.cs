using System;
using System.ComponentModel.DataAnnotations;

namespace StellaFiesta.Api
{
    public class CarBooking
    {
        [Key]
        public int ID { get; set; }

        public string BookerName { get; set; }

        public string BookerId { get; set; }

        public DateTime BookingStartDate { get; set; }

        public DateTime BookingEndDate { get; set; }
    }
}
