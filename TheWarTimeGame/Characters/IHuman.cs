using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWarTimeGame.Characters
{
    public interface IHuman
    {
        public double Health { get; set; }
        public void Attack(ref double health);
    }
}
