using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelClub.Core
{
    public class Customer : BaseDataModel
    {
        public Customer()
        {
            Address = new Collection<Address>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required]
        [Display(Name = "Customer name")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string Name { get; set; }
        
        [Required]
        [Display(Name = "E-Mail")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string Email { get; set; }

        public ICollection<Address> Address { get; set; }

        public void AddAdress(Address myAddress)
        {
            Address.Add(myAddress);
        }
    }

    public class Fee
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public decimal Ammount { get; set; }
        public DateTime Reference { get; set; }
        public DateTime PayedDate { get; set; }
    }
}
