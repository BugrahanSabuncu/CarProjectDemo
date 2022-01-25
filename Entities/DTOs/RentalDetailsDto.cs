using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class RentalDetailsDto:IDto
    {
        public int RentalId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BrandName { get; set; }
        public DateTime RentalDate { get; set; }
        public Nullable<DateTime> ReturnDate { get; set; }
        public decimal DailyPrice { get; set; }
        public decimal TotalPrice { get; set; }

    }
}
