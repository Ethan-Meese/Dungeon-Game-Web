using Microsoft.AspNetCore.Mvc;
using backend.Core;

namespace backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GameController : ControllerBase
{
    private static GameEngine _Engine = new();

    [HttpGet("start")]
    public IActionResult Start()
    {
        _Engine.StartGame();
        return Ok(_Engine.GetState());
    }

    [HttpPost("action")]
    public IActionResult Choose([FromBody] string action)
    {
        _Engine.ProcessAction(action);
        return Ok(_Engine.GetState());
    }
}
