using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheWarTimeGame.Characters;

namespace TheWarTimeGame.Items
{
    public interface IFood : ITem
    {
        public double Price { get; set; }
        public int Hunger { get; set; }
        public int ID { get; set; }

        public abstract void Use();
    }
}
