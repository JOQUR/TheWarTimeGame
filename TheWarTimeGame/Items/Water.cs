using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheWarTimeGame.Characters;

namespace TheWarTimeGame.Items
{
    public class Water : IFood
    {
        public int ID { get; set; }
        public double Price { get; set; }
        public int Hunger { get; set; }

        public Water(double price) 
        {
            this.Price = price;
        }
        public void Use()
        {
            foreach (var i in Player.GetPlayerInstance().Equipment)
            {
                if (i.GetType() == typeof(Water))
                {
                    Player.GetPlayerInstance().Hunger += 2;
                }
            }
        }

        public override string ToString()
        {
            return "Water";
        }

    }
}
