using TheWarTimeGame.Characters;

namespace TheWarTimeGame.Items;

public class Pistol : IWeapon
{
    public PistolPerks Perk { get; private set; }
    public double Price { get; set; }
    public int ID { get; set; }

    public Pistol(double price, PistolPerks perk)
    {
        this.Perk = perk;
        this.Price = price;
    }
    public Pistol(double price)
    {
        this.Perk = PistolPerks.Standard;
        this.Price = price;
    }
    public void Attack(ref Enemy enemy)
    {
        if (enemy.Health < 0) enemy.Health = 0;
        enemy.Health -= (6 * (int)Perk);
        Bleeding(ref enemy);
    }

    public void Bleeding(ref Enemy enemy)
    {
        int i = 10;
        while (i > 0)
        {
            if (enemy.Health <= 0)
            {
                enemy.Health = 0;
                return;
            }
            enemy.Health -= (0.2);
            Thread.Sleep(100);
            i--;
        }
    }

    public override string ToString()
    {
        return "Pistol";
    }
}