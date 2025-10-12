namespace backend.Core.Models;

public class Enemy
{
    public string Name { get; set; } = "";
    public int Health { get; set; } = 50;
    public int AttackDamage { get; set; } = 5;
    public int AbilityPower { get; set; } = 5;
    public bool IsAlive => Health > 0;
}