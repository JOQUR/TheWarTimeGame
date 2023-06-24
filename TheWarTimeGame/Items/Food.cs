using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWarTimeGame.Items
{
    public class Food : ITem
    {
        public double Price { get; set; }
        public int Hunger { get; set; }
    }
}
