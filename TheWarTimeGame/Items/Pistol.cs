using TheWarTimeGame.Characters;

namespace TheWarTimeGame.Items;

public class Pistol : IWeapon
{
    public PistolPerks Perk { get; private set; }
    public double Price { get; set; }

    public Pistol(PistolPerks perk)
    {
        this.Perk = perk;
    }
    public Pistol()
    {
        this.Perk = PistolPerks.Standard;
    }

    public void Attack(ref Enemy enemy)
    {
        enemy.Health -= (6 * (int)Perk);
        if(enemy.Health < 0) enemy.Health = 0;
        Bleeding(ref enemy);
    }

    public void Bleeding(ref Enemy enemy)
    {
        int i = 10;
        while (i > 0)
        {
            if (enemy.Health <= 0)
            {
                return;
            }
            enemy.Health -= (0.4);
            Thread.Sleep(100);
            i--;
        }
    }
}