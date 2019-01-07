using System;
using System.ComponentModel.DataAnnotations;
using NewVidly2.Models;
using NewVidly2.DTOs;

namespace NewVidly2.DTOs
{
    public class CustomerDto
    {
        public int Id { get; set; } 
        [Required]
        [StringLength(255)]
        public String Name { get; set; }
        public bool IsSubscribetToNewsletter { get; set; }  
        public MembershipTypeDto  MemebershipType  { get; set; }
        public byte MembershipTypeId { get; set; }
        public DateTime? BirthdayDate { get; set; }
    }
}