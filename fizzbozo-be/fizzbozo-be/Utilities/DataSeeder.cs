using fizzbozo_be.Data;
using fizzbozo_be.Entities;

namespace fizzbozo_be.Utilities
{
    public class DataSeeder
    {
        public static void SeedGames(FizzBozoDbContext context)
        {
            if (context.Games.Any()) return;

            var games = new[]
            {
                new Game
                {
                    Name = "Test 1",
                    Author = "Peter",
                    MinNumber = 3,
                    MaxNumber = 89,
                    RulesCount = 3,
                    Rules = new List<Rule>
                    {
                        new Rule {DividedBy = 3, AssociatedWord = "Fizz" },
                        new Rule {DividedBy = 8, AssociatedWord = "Buzz" },
                        new Rule {DividedBy = 6, AssociatedWord = "Boo" }
                    }
                },
                new Game
                {
                    Name = "Test 2",
                    Author = "Peter",
                    MinNumber = 1,
                    MaxNumber = 134,
                    RulesCount = 2,
                    Rules = new List<Rule>
                    {
                        new Rule {DividedBy = 7, AssociatedWord = "Oi" },
                        new Rule {DividedBy = 11, AssociatedWord = "Mate" },
                    }
                },
            };

            context.Games.AddRange(games);
            context.SaveChanges();
        }
    }
}
