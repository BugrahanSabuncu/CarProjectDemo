using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarDto:IDto
    {
        public int CarId { get; set; }
        public int ColorId { get; set; }
        public string ColorName { get; set; }
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public int ModelYear { get; set; }
        public Decimal DailyPrice { get; set; }
        public string Description { get; set; }
    }
}
