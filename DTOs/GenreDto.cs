using System.ComponentModel.DataAnnotations;

namespace NewVidly2.DTOs
{
    public class GenreDto
    {
        public byte Id { get; set; } 
        [Required]
        public string Name { get; set; }    
    }
}