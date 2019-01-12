using System.ComponentModel.DataAnnotations;

namespace NewVidly2.Controllers.DTOs
{
    public class GenreDto
    {
        public byte Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}