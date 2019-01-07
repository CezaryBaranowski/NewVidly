using System;
using System.ComponentModel.DataAnnotations;
using NewVidly.Models;

namespace NewVidly.DTOs
{
    public class RentalDto
    {
        public int Id { get; set; }
        [Required]
        public int MovieId { get; set; }
        [Required]
        public string MovieName { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public string CustomerName { get; set; }
        public DateTime DateRented { get; set; }
    }
}