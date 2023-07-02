using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheWarTimeGame.Characters;

namespace TheWarTimeGame.Items
{
    public class Water : Food
    {
        public int ID { get; set; }
        public Water(double price) 
        {
            this.Price = price;
        }
        public override void Use(Player owner, ref int value)
        {
            foreach (var i in owner.Equipment)
            {
                if (i.GetType() == typeof(Water))
                {
                    owner.Equipment.Remove(i);
                    value += 2;
                }
            }
        }

        public override string ToString()
        {
            return "Water";
        }

    }
}
