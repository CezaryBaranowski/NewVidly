using System;
using NewVidly.Models;

namespace NewVidly.DTOs
{
    public class MovieDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Genre Genre { get; set; }
        public String Description { get; set; }

        public byte GenreId { get; set; }

        public DateTime? ReleasedDate { get; set; }

        public int NumberAvailable { get; set; }   
    }
}