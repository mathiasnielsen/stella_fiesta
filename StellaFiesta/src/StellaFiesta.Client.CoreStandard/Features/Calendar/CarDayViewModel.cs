﻿using System;

namespace StellaFiesta.Client.CoreStandard
{
    public class CarDayViewModel : ViewModelBase
    {
        private string name;
        private DateTime day;
        private bool isBooked;
        private bool isValidBookingDate;
        private string imageUrl;

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

        public string Name
        {
            get { return name; }
            set { Set(ref name, value); }
        }

        public DateTime Day
        {
            get { return day; }
            set { Set(ref day, value); }
        }

        public bool IsBooked
        {
            get { return isBooked; }
            set { Set(ref isBooked, value); }
        }

        public string ImageUrl
        {
            get { return imageUrl; }
            set { Set(ref imageUrl, value); }
        }

        public bool IsValidBookingDate
        {
            get { return isValidBookingDate; }
            set { Set(ref isValidBookingDate, value); }
        }
    }
}
