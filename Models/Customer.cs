using System;
using System.ComponentModel.DataAnnotations;

namespace NewVidly2.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public String Name { get; set; }
        public bool IsSubscribetToNewsletter { get; set; }
        public MembershipType MemebershipType { get; set; }
        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }
        public DateTime? BirthdayDate { get; set; }

        public Customer(string name)
        {
            this.Name = name;
        }
        public Customer(int id, string name)
        {
            this.Name = name;
            this.Id = id;
        }
    }
}