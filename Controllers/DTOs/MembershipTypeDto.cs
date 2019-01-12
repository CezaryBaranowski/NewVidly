using System;
using System.ComponentModel.DataAnnotations;

namespace NewVidly2.Controllers.DTOs
{
    public class MembershipTypeDto
    {
        public byte Id { get; set; }
        public byte DurationInMonths { get; set; }
        [Required]
        public String Name { get; set; }
    }
}