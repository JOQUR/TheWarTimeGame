using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheWarTimeGame.Characters;
using TheWarTimeGame.Items;

namespace TheWarTimeGame.Location
{
    public interface ILocation
    {
        public Player Player { get; protected set; }
        public List<ITem> Loot { get; protected set; }
    }
}
