namespace fizzbozo_be.Models.DTOs
{
    internal class LeaderboardEntryDto
    {
        public string PlayerName { get; set; }
        public int Score { get; set; }

        public int GameDuration { get; set; }
        public DateTime Date { get; set; }
    }
}