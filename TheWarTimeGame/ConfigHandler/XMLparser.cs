using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace TheWarTimeGame.ConfigHandler
{
    public class XMLparser
    {
        
        public XMLparser()
        {
            var xml = XDocument.Load(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory())?.Parent.Parent.FullName, @"./defaultConfig.xml"));
            //var xml = XDocument.Load("./defaultConfig.xml");
            //var query = from c in xml.Root.Descendants("TheWarTime")
            //    where c.Name == "Locations"
            //    where c.Name == "Home"
            //    select c;

            Console.WriteLine(xml);
        }
    }
}
