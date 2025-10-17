namespace backend.Core.Models;

public class Player
{
    public string Name { get; set; } = "Adventurer";
    public int Health { get; set; } = 100;
    public int MaxHealth { get; set; } = 100;
    public int XP { get; set; } = 0;
    public int Level { get; set; } = 1;
    public int AttackDamage { get; set; } = 10;
    public int Mana { get; set; } = 100;
    public int MaxMana { get; set; } = 100;
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

    public void AddMana(int amount)
    {
        Mana += amount;
        if (Mana > MaxMana)
        {
            Mana = MaxMana;
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
            MaxMana += 5;
            Mana += 5;

        }
    }
}

