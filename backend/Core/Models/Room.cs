namespace backend.Core.Models;

public class Room
{
    public string Description { get; set; } = "";
    public List<string> Options { get; set; } = [];
    public List<Enemy> Enemies { get; set; } = [];
}