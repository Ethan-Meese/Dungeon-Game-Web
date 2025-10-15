using Microsoft.AspNetCore.Mvc;
using backend.Core;

namespace backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GameController : ControllerBase
{
    private static GameEngine _Engine = new();

    [HttpPost("start")]
    public IActionResult Start()
    {
        var state = _Engine.StartGame();
        return Ok(state);
    }

    [HttpPost("action")]
    public IActionResult Choose([FromBody] ActionRequest request)
    {
        var state = _Engine.ProcessAction(request.Action);
        return Ok(state);
    }

    [HttpGet("state")]
    public IActionResult GetState()
    {
        return Ok(_Engine.GetState());
    }
}

public class ActionRequest
{
    public string Action { get; set; } = string.Empty;
}
