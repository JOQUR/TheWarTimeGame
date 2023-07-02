using System.Xml.Linq;
using TheWarTimeGame.Characters;
using TheWarTimeGame.Items;
using TheWarTimeGame.Location;

namespace TheWarTimeGame.ConfigHandler
{
    public class XMLparser
    {
        public static int id = 0;
        private XDocument xmlDoc = XDocument.Load(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, @"./defaultConfig.xml"));
        private static XDocument xmlScript = XDocument.Load(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, @"./Script.xml"));
        public XMLparser(ILocation x)
        {
            getLocationData(x);
            getEnemies(x);
        }

        public XMLparser()
        {

        }

        private void getLocationData(ILocation x)
        {
            foreach (XElement element in xmlDoc.Root.Element("Locations").Element(x.ToString()).Elements("Items").Elements("Item"))
            {
                double price;
                if ((double)element.Attribute("price") == null)
                {
                    price = 1;
                }

                price = (double)element.Attribute("price");
                ITem item = ItemFactory.CreateItem(itemType: (string)element.Attribute("name"), price: price);
                x.Loot.Add(new KeyValuePair<int, ITem>((int)id++, item));
            }
        }

        private void getEnemies(ILocation x)
        {
            if(x.GetType() == typeof(Home))
            {
                return;
            }

            foreach (XElement element in xmlDoc.Root.Element("Locations").Element(x.ToString()).Elements("Enemies").Elements("Enemy"))
            {
                int hp = (int)element.Attribute("hp");
                Enemy enemy = new Enemy();
                enemy.Health = hp;
                x.Enemies.Add(new KeyValuePair<int, IHuman>((int)id++, enemy));
            }
        }

        public static string ReadScript(string _node)
        {
            string script;
            XElement element = xmlScript.Root.Element("Scripts").Element(_node);
            script = (string)element.Attribute("msg");
            return script;
        }
    }
}
