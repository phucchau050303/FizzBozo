using System.Data;

namespace fizzbozo_be.Entities
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public int MinNumber { get; set; }
        public int MaxNumber { get; set; }
        public int RulesCount { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        // Navigation properties
        public ICollection<Rule> Rules { get; set; }
        public ICollection<GameSession> GameSessions { get; set; }
    }
}
