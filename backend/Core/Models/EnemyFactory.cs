namespace backend.Core.Models;

public static class EnemyFactory
{
    private static readonly Random random = new();
    public static Enemy CreateRandomEnemy(int dungeonLevel)
    {
        Enemy Goblin = new("Goblin", 50, 5);
        Enemy Orc = new("Orc", 75, 3);
        Enemy Skeleton = new("Skelton", 25, 2);
        Enemy Zombie = new("Zombie", 50, 3);
        Enemy Slime = new("Slime", 15, 2);
        Enemy DarkWizard = new("Dark Wizard", 50, 10);

        var Enemies = new List<Enemy> { Goblin, Orc, Skeleton, Zombie, Slime, DarkWizard };

        foreach (Enemy enemy in Enemies){
            enemy.Health += dungeonLevel * random.Next(2, 5);
            enemy.AttackDamage += dungeonLevel * random.Next(1, 3);
        }

        return Enemies[random.Next(Enemies.Count)];
    }
}