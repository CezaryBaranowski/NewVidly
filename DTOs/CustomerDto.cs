using System;
using NewVidly.Models;

namespace NewVidly.DTOs
{
    public class CustomerDto
    {
        public int Id { get; set; } 
        public String Name { get; set; }
        public bool IsSubscribetToNewsletter { get; set; }  
        public MembershipType  MemebershipType  { get; set; }
        public byte MembershipTypeId { get; set; }
        public DateTime? BirthdayDate { get; set; }
    }
}