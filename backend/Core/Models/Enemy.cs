namespace backend.Core.Models;

public class Enemy(string name, int health, int attackDamage)
{
    public string Name { get; set; } = name;
    public int Health { get; set; } = health;
    public int AttackDamage { get; set; } = attackDamage;
    public bool IsAlive => Health > 0;
}