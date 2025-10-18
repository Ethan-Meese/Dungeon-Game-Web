namespace backend.Core.Models;

public class Attacks(string attackName, int attackDamage, int attackManaCost)
{
    public string AttackName { get; set; } = attackName;
    public int AttackDamage { get; set; } = attackDamage;
    public int AttackManaCost { get; set; } = attackManaCost;
}