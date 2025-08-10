using Microsoft.AspNetCore.Mvc;
using fizzbozo_be.Data;
using fizzbozo_be.Entities;
using fizzbozo_be.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace fizzbozo_be.Controllers
{
    [Route("api/results")]
    [ApiController]
    public class ResultsController : ControllerBase
    {
        private  FizzBozoDbContext _context;

        public ResultsController (FizzBozoDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateResult(Guid sessionId)
        {
            var session = _context.Sessions
                .Include(s => s.GameQuestions)
                .FirstOrDefault(s => s.Id == sessionId);

            if (session == null)
            {
                return NotFound();
            }

            var result = new Result
            {
                TotalAnswers = session.GameQuestions.Count(),
                CorrectAnswers = session.GameQuestions.Count(q => q.IsCorrect),
                WrongAnswers = session.GameQuestions.Count(q => !q.IsCorrect),
                CreatedAt = DateTime.UtcNow,
            };

            try
            {
                _context.Results.Add(result);
                session.EndedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                return Ok(result);
            }
            catch (Exception ex) 
            { 
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("leaderboard")]
        public IActionResult GetLeaderboard ([FromQuery] int gameId)
        {
            var result = _context.Results
                .Where(r => r.GameSession.GameId == gameId)
                .OrderByDescending(r => r.CorrectAnswers)
                .Take(10)
                .Select(r => new LeaderboardEntryDto
                {
                    PlayerName = r.GameSession.PlayerName,
                    Score = r.CorrectAnswers,
                    Date = r.CreatedAt
                })
                .ToList();
            try
            {
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{playerName}")]
        public IActionResult GetResultByName(string playerName)
        {
            var result = _context.Results
                .Where(r => r.GameSession.PlayerName == playerName)
                .OrderByDescending(r => r.CorrectAnswers)
                .Select(r => new LeaderboardEntryDto
                {
                    PlayerName = r.GameSession.PlayerName,
                    Score = r.CorrectAnswers,
                    Date = r.CreatedAt
                })
                .ToList();
            try
            {
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}
