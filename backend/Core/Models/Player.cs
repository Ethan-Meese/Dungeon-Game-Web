namespace backend.Core.Models;

public class Player
{
    public string Name { get; set; } = "Adventurer";
    public int Health { get; set; } = 100;
    public int MaxHealth { get; set; } = 100;
    public int XP { get; set; } = 0;
    public int Level { get; set; } = 1;
    public int AttackDamage { get; set; } = 10;
    public int Gold { get; set; } = 0;
    public List<string> Inventory { get; set; } = [];
    public bool IsAlive => Health > 0;

    public void AddHealth(int amount)
    {
        Health += amount;
        if (Health > MaxHealth)
        {
            Health = MaxHealth;
        }
    }

    public void AddXP(int amount)
    {
        XP += amount;
        while (XP >= 100)
        {
            Level++;
            XP -= 100;

            MaxHealth += 10;
            Health += 10;
            AttackDamage += 3;
        }
    }
}

