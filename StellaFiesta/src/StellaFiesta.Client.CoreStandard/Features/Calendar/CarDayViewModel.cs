using System;
namespace StellaFiesta.Client.CoreStandard
{
    public class CarDayViewModel : ViewModelBase
    {
        public CarDayViewModel(
            string name,
            DateTime day,
            bool isBooked,
            string imageUrl)
        {
            Name = name;
            Day = day;
            IsBooked = isBooked;
            ImageUrl = imageUrl;

            IsValidBookingDate = Day.Date >= DateTime.Now.Date;
        }

        public string Name { get; set; }

        public DateTime Day { get; set; }

        public bool IsBooked { get; set; }

        public string ImageUrl { get; set; }

        public bool IsValidBookingDate { get; set; }
    }
}
