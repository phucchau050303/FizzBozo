using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using fizzbozo_be.Data;
using fizzbozo_be.Entities;
using fizzbozo_be.Models.DTOs;

namespace fizzbozo_be.Controllers
{
    [Route("api/games")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly FizzBozoDbContext _context;

        public GamesController(FizzBozoDbContext context)
        {
            _context = context;
        }

        // GET: api/Games
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Game>>> GetGames()
        {

            return await _context.Games.ToListAsync();
        }

        // GET: api/Games/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Game>> GetGame(int id)
        {
            var game = await _context.Games.FindAsync(id);

            if (game == null)
            {
                return NotFound();
            }

            return game;
        }

        //// PUT: api/Games/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutGame(int id, Game game)
        //{
        //    if (id != game.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(game).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!GameExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Games
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> CreateGame([FromBody] GameCreateDto dto)
        {
            var game = new Game
            {
                Name = dto.Name,
                Author = dto.Author,
                MinNumber = dto.MinNumber,
                MaxNumber = dto.MaxNumber,
                Rules = dto.Rules.Select(r => new Rule
                {
                    DividedBy = r.DividedBy,
                    AssociatedWord = r.Word,
                }).ToList()
            };
            try
            {
                _context.Games.Add(game);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetGame", new { id = game.Id }, game);
            }
            catch (Exception ex) {                  
                return BadRequest($"Something went wrong: {ex.Message}");
            }


        }

        // DELETE: api/Games/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGame(int id)
        {
            var game = await _context.Games.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }
            try
            {
                _context.Games.Remove(game);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest($"Something went wrong: {ex.Message}");
            }

        }

        private bool GameExists(int id)
        {
            return _context.Games.Any(e => e.Id == id);
        }
    }
}
