namespace backend.Core.Models;

public class GameState
{
    public string Message { get; set; } = "";
    public string Description { get; set; } = "";
    public List<string> Options { get; set; } = [];

    public Player Player { get; set; } = new();
    public Room CurrentRoom { get; set; } = new();
    public int DungeonLevel { get; set; }
    public bool IsGameOver { get; set; } = false;
}