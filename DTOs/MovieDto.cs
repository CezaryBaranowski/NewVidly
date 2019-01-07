using System;
using System.ComponentModel.DataAnnotations;
using NewVidly2.Models;
using NewVidly2.DTOs;

namespace NewVidly2.DTOs
{
    public class MovieDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public byte GenreId { get; set; }
        public GenreDto Genre { get; set; }
        public String Description { get; set; }
        [Display(Name = "Date Released")]
        public DateTime? ReleasedDate { get; set; }
        [Display(Name = "Number In Stock")]
        [Range(1, 20)]
        public int NumberInStock { get; set; }   
    }
}