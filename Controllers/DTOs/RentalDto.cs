using System;
using System.ComponentModel.DataAnnotations;

namespace NewVidly2.Controllers.DTOs
{
    public class RentalDto
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public DateTime DateRented { get; set; }
        public DateTime? DateReturned { get; set; }
    }
}