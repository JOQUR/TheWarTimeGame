using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheWarTimeGame.Characters;
using TheWarTimeGame.Items;

namespace TheWarTimeGame.Location
{
    public class Home : ILocation
    {

        public Player Player { get; set; }
        public List<ITem> Loot { get; set; }
        public Home(Player player, List<ITem> loot)
        {
            Player = player;
            Loot = loot;
        }
    }
}
