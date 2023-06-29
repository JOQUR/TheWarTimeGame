using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheWarTimeGame.Characters;

namespace TheWarTimeGame.Items
{
    public class Food : ITem
    {
        public double Price { get; set; }
        public int Hunger { get; set; }

        public virtual void Use(Player owner, ref int value)
        {
            throw new NotImplementedException("Cannot use it here");
        }
    }
}
