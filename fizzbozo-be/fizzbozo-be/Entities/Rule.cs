namespace fizzbozo_be.Entities
{
    public class Rule
    {
        public int Id { get; set; }
        public int DividedBy { get; set; }
        public string AssociatedWord { get; set; } = string.Empty;
        
        //Foreign Key
        public int GameId { get; set; }
        public Game Game { get; set; }
    }
}
