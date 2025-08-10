namespace fizzbozo_be.Entities
{
    public class GameQuestion
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string ExpectedAnswer { get; set; } = string.Empty;
        public string PlayerAnswer { get; set; } = string.Empty;
        public bool IsCorrect {  get; set; }
        public DateTime AnsweredAt { get; set; } = DateTime.UtcNow;

        // Foreign key
        public Guid SessionId { get; set; }
        public GameSession GameSession { get; set; }
    }
}
