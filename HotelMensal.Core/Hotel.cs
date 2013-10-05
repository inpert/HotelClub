using System;
using System.ComponentModel.DataAnnotations;

namespace HotelClub.Core
{
    public class Hotel : BaseDataModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Display(Name = "Premiere Date")]
        [Required]
        public DateTime Premiere { get; set; }

        public Address Address { get; set; }
    }
}