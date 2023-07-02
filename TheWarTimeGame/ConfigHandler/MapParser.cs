using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWarTimeGame.ConfigHandler
{
    public static class MapParser
    {
        public static string GetMap()
        {
            string map = string.Empty;
            string path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, @"./map.txt");
            using (StreamReader file = new StreamReader(path))
            {
                string ln;
                while((null != (ln = file.ReadLine())))
                {
                    map += (ln + "\n");
                }
                file.Close();
            }
            return map;
        }
    }
}
