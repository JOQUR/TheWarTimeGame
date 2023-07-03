using TheWarTimeGame.Characters;

namespace TheWarTimeGame.Items;

public class Knife : IWeapon
{
    public KnifePerks Perk { get; private set; }
    public double Price { get; set; }
    public int ID { get; set; }
    public Knife(KnifePerks perk, double price)
    {
        Perk = KnifePerks.Standard;
        Price = price;
    }

    public void Attack(ref double health)
    {
        if (health <= 0)
        {
            health = 0;
            return;
        }
        health -= (3 * (int)Perk);
        Bleeding(ref health);
    }

    public void Bleeding(ref double health)
    {
        int i = 10;
        while (i > 0)
        {
            if(health <= 0) health = 0;
            health -= (0.5);
            Thread.Sleep(100);
            i--;
        }
    }

    public override string ToString()
    {
        return "Knife";
    }

    public void Use(ref double value)
    {
        Attack(ref value);
    }

    public ITem GetClone()
    {
        return (Knife)this.MemberwiseClone();
    }
}