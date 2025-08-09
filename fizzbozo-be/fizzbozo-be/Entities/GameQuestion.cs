namespace fizzbozo_be.Entities
{
    public class GameQuestion
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string ExpectedAnswer { get; set; } = string.Empty;
        public string PlayerAnswer { get; set; } = string.Empty;
        public bool IsCorrect {  get; set; }
        public string AnswerAt { get; set; } = string.Empty;

        // Foreign key
        public int SessionId { get; set; }
        public GameSession GameSession { get; set; }
    }
}
