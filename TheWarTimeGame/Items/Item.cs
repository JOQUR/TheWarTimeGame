using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWarTimeGame.Items
{
    public interface ITem
    {
        double Price { get; set; }
        public string? ToString();
        public int ID { get; set; }
    }
}
