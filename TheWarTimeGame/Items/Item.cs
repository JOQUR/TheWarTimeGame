using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWarTimeGame.Items
{
    public interface ITem
    {
    }

    public interface IWeapon : ITem
    {
        void Attack(ref double health); 
        void Bleeding(ref double health);
    }

    public class Pistol : IWeapon
    {
        public PistolPerks Perk { get; private set; }

        public Pistol(PistolPerks perk)
        {
            this.Perk = perk;
        }
        public Pistol()
        {
            this.Perk = PistolPerks.Standard;
        }

        public void Attack(ref double health)
        {
            health -= (6 * (int)Perk);
            if(health < 0) health = 0;
        }

        public void Bleeding(ref double health)
        {
            int i = 10;
            while (i > 0)
            {
                if (health <= 0)
                {
                    return;
                }
                health -= (0.4);
                Thread.Sleep(100);
                i--;
            }
        }
    }

    public class Knife : IWeapon
    {
        public KnifePerks Perk { get; private set; }
        public void Attack(ref double health)
        {
            health -= (10 * (int)Perk);
        }

        public void Bleeding(ref double health)
        {
            int i = 10;
            while (i > 0)
            {
                health -= (0.5);
                Thread.Sleep(100);
                i--;
            }
        }
    }

    public enum KnifePerks
    {
        Standard,
        SharpenedEdge,
        PoisonedEdge
    }
    public enum PistolPerks
    {
        Standard = 1,
        BetterAmmo,
        WeaponSight
    }
}
