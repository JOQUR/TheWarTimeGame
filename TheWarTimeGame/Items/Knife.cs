using TheWarTimeGame.Characters;

namespace TheWarTimeGame.Items;

public class Knife : IWeapon
{
    public KnifePerks Perk { get; private set; }
    public double Price { get; set; }
    public int ID { get; set; }
    public Knife(KnifePerks perk, double price)
    {
        Perk = perk;
        Price = price;
    }

    public void Attack(ref Enemy enemy)
    {
        if (enemy.Health <= 0)
        {
            enemy.Health = 0;
            return;
        }
        enemy.Health -= (10 * (int)Perk);
        Bleeding(ref enemy);
    }

    public void Bleeding(ref Enemy enemy)
    {
        int i = 10;
        while (i > 0)
        {
            if(enemy.Health <= 0) enemy.Health = 0;
            enemy.Health -= (0.5);
            Thread.Sleep(100);
            i--;
        }
    }

    public override string ToString()
    {
        return "Knife";
    }

    public void Use()
    {
        Console.WriteLine("You cannot use it like that!");
    }
}