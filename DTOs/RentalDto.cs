using System;
using NewVidly.Models;

namespace NewVidly.DTOs
{
    public class RentalDto
    {
        public Movie Movie { get; set; }
        public int MovieId { get; set; }

        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public DateTime DateRented { get; set; }
        public DateTime? DateReturned { get; set; }
    }
}