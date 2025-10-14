using Microsoft.AspNetCore.SignalR;

namespace backend.Core.Models;

public class Room
{
    public string Name { get; set;} = "";
    public string Description { get; set; } = "";
    public int Number { get; set; } = 1;
    public List<string> Options { get; set; } = [];
    public List<Enemy> Enemies { get; set; } = [];
}