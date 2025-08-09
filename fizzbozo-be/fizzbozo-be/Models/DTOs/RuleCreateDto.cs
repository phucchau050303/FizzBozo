using System.ComponentModel.DataAnnotations;

namespace fizzbozo_be.Models.DTOs
{
    public class RuleCreateDto
    {
        [Range(1, int.MaxValue, ErrorMessage = "Divisor must be greater than 0.")]
        public int DividedBy { get; set; }

        [Required(ErrorMessage = "Divisor must be greater than 0.")]
        public string Word { get; set; }
    }
}
