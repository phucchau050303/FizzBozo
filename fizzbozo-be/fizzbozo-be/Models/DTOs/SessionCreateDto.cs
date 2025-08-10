using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace fizzbozo_be.Models.DTOs
{
    public class SessionCreateDto
    {
        [Required]
        public string PlayerName { get; set; } = string.Empty;

        [Required]
        public int DurationSeconds { get; set; }

        [Required]
        public int GameId { get; set; }
    }
}
