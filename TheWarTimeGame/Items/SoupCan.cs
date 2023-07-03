using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheWarTimeGame.Characters;

namespace TheWarTimeGame.Items
{
    public class SoupCan : IFood
    {
        public int ID { get; set; }
        public double Price { get; set; }
        public double Hunger { get; set; }

        public SoupCan(double price)
        {
            this.Price = price;
        }
        public void Use(ref double value)
        {
            foreach(var i in Player.GetPlayerInstance().Equipment)
            {
                if(i.GetType() == typeof(SoupCan))
                {
                    Player.GetPlayerInstance().Equipment.Remove(i);
                    Player.GetPlayerInstance().Hunger += 4;
                    return;
                }
            }
        }

        public override string ToString()
        {
            return "SoupCan";
        }

        public ITem GetClone()
        {
            return (SoupCan)this.MemberwiseClone();
        }
    }
}
