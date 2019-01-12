using System;
using System.ComponentModel.DataAnnotations;

namespace NewVidly2.Core.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }
        [Required]
        public String Name { get; set; }

    }
}