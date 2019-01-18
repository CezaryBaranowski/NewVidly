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
        public MembershipTypeDto MembershipType { get; set; }
        public byte MembershipTypeId { get; set; }
        public String BirthdayDate { get; set; }
        public string Email { get; set; }   
    }
}