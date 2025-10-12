namespace backend.Core.Models;

public class Player
{
    public string Name { get; set; } = "";
    public int Health { get; set; } = 100;
    public int AttackDamage { get; set; } = 10;
    public int AbilityPower { get; set; } = 10;
    public int Gold { get; set; } = 0;
    public List<string> Inventory { get; set; } = [];
}