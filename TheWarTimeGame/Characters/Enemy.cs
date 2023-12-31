﻿using TheWarTimeGame.Items;

namespace TheWarTimeGame.Characters
{
    public class Enemy : IHuman
    {
        public double Health { get; set; }
        private Pistol _pistol;

        public Enemy()
        {
            _pistol = new Pistol(0, PistolPerks.Standard);
        }

        public void Attack(ref double health)
        {
            _pistol.Attack(ref health);
        }
    }
}
