using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace fizzbozo_be.Models.DTOs
{
    public class GameCreateDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Author { get; set; }

        [Range(0,1000)]
        public int MinNumber { get; set; }

        [Range(0,1000)]
        public int MaxNumber { get; set; }

        public List<RuleCreateDto> Rules { get; set; } = new();

    }
}
