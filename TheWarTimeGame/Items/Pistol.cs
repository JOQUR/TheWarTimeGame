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
    public Pistol(PistolPerks standard)
    {
        this.Perk = PistolPerks.Standard;
    }
    public void Attack(ref double health)
    {
        if (health < 0) health = 0;
        health -= (6 * (int)Perk);
        Bleeding(ref health);
    }

    public void Bleeding(ref double health)
    {
        int i = 10;
        while (i > 0)
        {
            if (health <= 0)
            {
                health = 0;
                return;
            }
            health -= (0.2);
            Thread.Sleep(100);
            i--;
        }
    }

    public void Use(ref double value)
    {
        this.Attack(ref value);
    }

    public override string ToString()
    {
        return "Pistol";
    }

    public ITem GetClone()
    {
        return (Pistol)this.MemberwiseClone();
    }
}