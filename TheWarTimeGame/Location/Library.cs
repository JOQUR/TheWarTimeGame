using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheWarTimeGame.Characters;
using TheWarTimeGame.Items;

namespace TheWarTimeGame.Location
{
    public class Library : ILocation
    {
        public Player Player { get; set; }
        public List<KeyValuePair<int, ITem>> Loot { get; set; }
        public List<KeyValuePair<int, IHuman>> Enemies { get; set; }

        public Library()
        {
            Player = Player.GetPlayerInstance();
            Loot = new List<KeyValuePair<int, ITem>>();
            Enemies = new List<KeyValuePair<int, IHuman>>();
        }

        public ILocation GetClone()
        {
            return (Library)this.MemberwiseClone();
        }

        public override string ToString() => "Library";
    }
}
