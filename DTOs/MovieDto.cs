using System;
using System.ComponentModel.DataAnnotations;
using NewVidly.Models;

namespace NewVidly.DTOs
{
    public class MovieDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public byte GenreId { get; set; }
        public Genre Genre { get; set; }
        public String Description { get; set; }
        [Display(Name = "Date Released")]
        public DateTime? ReleasedDate { get; set; }
        [Display(Name = "Number In Stock")]
        [Range(1, 20)]
        public int NumberInStock { get; set; }   
    }
}