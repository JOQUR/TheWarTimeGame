using System.ComponentModel;
using System.Globalization;
using System.Xml.Linq;
using System.Xml.Serialization;
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

        public XMLparser(string filename, ILocation x)
        {
            string path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, @$"./saves/{filename}.xml");
            getLocationData(XDocument.Load(path), x);
            getEnemies(XDocument.Load(path), x);
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

        private void getLocationData(XDocument doc, ILocation x)
        {
            try
            {
                foreach (XElement element in doc.Root.Element("Locations").Element(x.ToString()).Elements("Items").Elements("Item"))
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
            catch(Exception ex) { }
        }

        private void getEnemies(ILocation x)
        {
            try
            {
                if (x.GetType() == typeof(Home))
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
            catch(Exception ex) { }
        }

        private void getEnemies(XDocument doc, ILocation x)
        {
            if (x.GetType() == typeof(Home))
            {
                return;
            }

            foreach (XElement element in doc.Root.Element("Locations").Element(x.ToString()).Elements("Enemies").Elements("Enemy"))
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

        public static void SaveGame(Home home, Library library, Church church)
        {
            DateTime localDate = DateTime.Now;
            var culture = new CultureInfo("de-DE");
            var x = localDate.ToString(culture).Replace('.', '_').Replace(':', '_');
            string save = (Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, @$"./saves/{x}.xml"));
            XElement root = new XElement("TheWarTime", new XElement("Locations", new XElement("Home", getElement(home.Loot)), new XElement("Library", getElement(library.Loot), getElement(library.Enemies)), new XElement("Church", getElement(church.Loot), getElement(church.Enemies))), new XElement("Vendors"));
            root.Save(save);

            Console.WriteLine("List saved to XML successfully.");
        }

        private static XElement getElement(List<KeyValuePair<int, ITem>> items)
        {
            XElement item = new XElement("Items");
            foreach (KeyValuePair<int, ITem> iitem in items)
            {
                XElement itemElement = new XElement("Item",
                    new XAttribute("price", iitem.Value.Price),
                    new XAttribute("id", iitem.Value.ID),
                    new XAttribute("name", iitem.Value.ToString())
                );

                item.Add(itemElement);

            }
            return item;
        }

        private static XElement getElement(List<KeyValuePair<int, IHuman>> items)
        {
            XElement item = new XElement("Enemies");
            foreach (KeyValuePair<int, IHuman> iitem in items)
            {
                XElement itemElement = new XElement("Enemy",
                    new XAttribute("hp", iitem.Value.Health)
                );

                item.Add(itemElement);

            }
            return item;
        }
    }
}
