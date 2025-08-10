namespace fizzbozo_be.Entities
{
    public class Result
    {
            public int Id { get; set; }
            public int TotalAnswers { get; set; }
            public int CorrectAnswers { get; set; }
            public int WrongAnswers { get; set; }
            public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

            // Foreign key
            public Guid SessionId { get; set; }
            public GameSession GameSession { get; set; }
    }
}
