using System.ComponentModel.DataAnnotations;

namespace fizzbozo_be.Models.DTOs
{
    public class AnswerSubmitDto
    {
        [Required]
        public int Number { get; set; }

        [Required]
        public string ExpectedAnswer { get; set; } = string.Empty;

        [Required]
        public string PlayerAnswer { get; set; } = string.Empty;

        [Required]
        public Guid SessionId { get; set; }
    }
}
