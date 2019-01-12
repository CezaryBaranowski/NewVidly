using System;
using System.ComponentModel.DataAnnotations;

namespace NewVidly2.Controllers.DTOs
{
    public class CustomerDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public String Name { get; set; }
        public bool IsSubscribetToNewsletter { get; set; }
        public MembershipTypeDto MemebershipType { get; set; }
        public byte MembershipTypeId { get; set; }
        public DateTime? BirthdayDate { get; set; }
    }
}