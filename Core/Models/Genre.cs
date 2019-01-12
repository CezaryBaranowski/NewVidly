using System.ComponentModel.DataAnnotations;

namespace NewVidly2.Core.Models
{
    public class Genre
    {
        public byte Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}