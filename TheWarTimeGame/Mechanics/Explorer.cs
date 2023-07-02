using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWarTimeGame.Mechanics
{
    public class Explorer
    {
        private Explorer() { }
        public static void Invoke(IExplore command)
        {
            command.Explore();
        }
    }
}
