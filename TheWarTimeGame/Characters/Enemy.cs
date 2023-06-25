using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheWarTimeGame.Items;

namespace TheWarTimeGame.Characters
{
    public class Enemy : IHuman
    {
        public double Health { get; set; }
        private Pistol _pistol;

        public Enemy()
        {
            _pistol = new Pistol();
        }

        public void Attack(ref Enemy enemy)
        {
            _pistol.Attack(ref enemy);
        }
    }
}
