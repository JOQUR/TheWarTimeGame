using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheWarTimeGame.Characters;

namespace TheWarTimeGame.Items
{
    public class SoupCan : Food
    {

        public SoupCan(double price)
        {
            this.Price = price;
        }
        public override void Use(Player owner, ref int value)
        {
            foreach(var i in owner.Equipment)
            {
                if(i.GetType() == typeof(SoupCan))
                {
                    owner.Equipment.Remove(i);
                    value += 4;
                }
            }
        }

        public override string ToString()
        {
            return "SoupCan";
        }
    }
}
