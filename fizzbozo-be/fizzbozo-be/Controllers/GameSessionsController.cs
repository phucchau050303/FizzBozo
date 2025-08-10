using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using fizzbozo_be.Data;
using fizzbozo_be.Entities;
using fizzbozo_be.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace fizzbozo_be.Controllers
{
    [Route("api/sessions")]
    [ApiController]
    public class GameSessionsController : ControllerBase
    {
        private readonly FizzBozoDbContext _context;
        private readonly Random _random = new();

        public GameSessionsController (FizzBozoDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> CreateGameSession([FromBody] SessionCreateDto dto)
        {
            var session = new GameSession //create a game session object using the dto
            {
                PlayerName = dto.PlayerName,
                DurationSeconds = dto.DurationSeconds,
                StartedAt = DateTime.UtcNow,
                GameId = dto.GameId,
            };
            try
            {
                _context.Sessions.Add(session);
                await _context.SaveChangesAsync();

                //The new {} syntax inside Ok() creates an anonymous object that gets serialized to JSON in the HTTP response.
                return Ok(new 
                {
                    SessionId = session.Id, 
                });
            }
            catch (Exception ex) { 
                return BadRequest(ex.Message);
            }
        }

        //Get a new random Number
        [HttpGet]
        public IActionResult GetNextNumber(Guid SessionId)
        {
            var session = _context.Sessions // fetch game session
                .Include(s => s.Game)
                .FirstOrDefault(s => s.Id == SessionId);

            if (session == null) { //if none return not found
                return NotFound();
            }

            int nextRandomNumber; 
            do
            {
                nextRandomNumber = _random.Next(session.Game.MinNumber, session.Game.MaxNumber + 1);
            }
            while (session.NumbersUsed.Contains(nextRandomNumber)); //keep createing if duplicate

            try
            {
                session.NumbersUsed.Add(nextRandomNumber);
                _context.SaveChanges();

                return Ok(new { Number = nextRandomNumber });
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{sessionId}/answer")]
        public async Task<IActionResult> SubmitAnswer(Guid sessionid, [FromBody] AnswerSubmitDto dto)
        {
            var session = _context.Sessions
                .Include(s => s.Game)
                .ThenInclude(s => s.Rules)
                .FirstOrDefault(r => r.Id == sessionid);
            if (session == null) { 
                return NotFound();
            }
            var expectedAnswer = GetExpectedAnswer(dto.Number, session.Game.Rules);
            var question = new GameQuestion
            {
                Number = dto.Number,
                ExpectedAnswer = expectedAnswer,
                PlayerAnswer = dto.PlayerAnswer,
                IsCorrect = dto.PlayerAnswer == expectedAnswer,
                SessionId = dto.SessionId,
            };
            try
            {
                _context.GameQuestions.Add(question);
                await _context.SaveChangesAsync();

                return Ok(new { IsCorrect = question.IsCorrect });
            }
            catch (Exception ex) { 
                return BadRequest(ex.Message);
            }
        }

        private string GetExpectedAnswer(int number, ICollection<Rule> rules)
        {
            var result = rules
                .Where(r => number % r.DividedBy == 0)
                .OrderBy(r => r.DividedBy)
                .Select(r => r.AssociatedWord)
                .ToList();
            return result.Any() ? string.Join("", result) : number.ToString();
        }
    }
}
