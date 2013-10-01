using System;

namespace HotelClub.Core
{
    public class Fee
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public decimal Ammount { get; set; }
        public DateTime Reference { get; set; }
        public DateTime PayedDate { get; set; }
    }
}