using Microsoft.AspNetCore.Mvc;
using backend.Core;

namespace backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GameController : ControllerBase
{
    private static GameEngine game = new GameEngine();

    [HttpGet("start")]
    public IActionResult Start()
    {
        game.Start();
        return Ok(game.GetState());
    }

    [HttpPost("choose")]
    public IActionResult Choose([FromBody] string choice)
    {
        game.MakeChoice(choice);
        return Ok(game.GetState());
    }
}
