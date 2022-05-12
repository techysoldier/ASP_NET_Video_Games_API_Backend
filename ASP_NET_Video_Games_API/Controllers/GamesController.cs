using ASP_NET_Video_Games_API.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP_NET_Video_Games_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GamesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetPublishers()
        {
            var videoGamePublishers = _context.VideoGames.Select(vg => vg.Publisher).Distinct();

            return Ok(videoGamePublishers);
        }

        [HttpGet("publish/{pubName}")]
        public IActionResult GetGamesByPublisher(string pubName)
        {
            var videoGames = _context.VideoGames.Where(vg => vg.Publisher == pubName);
            return Ok(videoGames);
        }
        //Get Games By ID
        [HttpGet("gamebyid/{gameId}")]
        public IActionResult GetGamesById(int gameId)
        {
            var videoGames = _context.VideoGames.Where(vg => vg.Id == gameId);
            return Ok(videoGames);
        }
    }
}
