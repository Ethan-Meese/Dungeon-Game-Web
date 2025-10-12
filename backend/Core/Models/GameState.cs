namespace backend.Core.Models;

public class GameState
{
    public string Message { get; set; } = "";
    public string Description { get; set; } = "";
    public Player Player { get; set; } = new();
    public Room CurrentRoom { get; set; } = new();
    public bool IsGameOver { get; set; } = false;
}