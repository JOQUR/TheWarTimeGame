using TheWarTimeGame.Characters;

namespace TheWarTimeGame.Items;

public class Knife : IWeapon
{
    public KnifePerks Perk { get; private set; }
    public double Price { get; set; }
    public Knife(KnifePerks perk, double price)
    {
        Perk = perk;
        Price = price;
    }

    public void Attack(ref Enemy enemy)
    {
        enemy.Health -= (10 * (int)Perk);
        Bleeding(ref enemy);
    }

    public void Bleeding(ref Enemy enemy)
    {
        int i = 10;
        while (i > 0)
        {
            enemy.Health -= (0.5);
            Thread.Sleep(100);
            i--;
        }
    }
}