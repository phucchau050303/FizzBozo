namespace fizzbozo_be.Entities
{
    public class GameSession
    {
        public int Id { get; set; }
        public Guid SessionId { get; set; }
        public string PlayerName { get; set; } = string.Empty;
        public int DurationSeconds { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime EndedAt { get; set; }
        public List<int> NumbersUsed { get; set; } = new();

        // Foreign key
        public int GameId { get; set; }
        public Game Game { get; set; }

        //Navigation Properties
        public ICollection<GameQuestion> GameQuestions { get; set; }
        public Result Result { get; set; }
    }
}
