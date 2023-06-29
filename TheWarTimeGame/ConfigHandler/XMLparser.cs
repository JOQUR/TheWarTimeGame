using System.Xml.Linq;
using TheWarTimeGame.Items;
using TheWarTimeGame.Location;

namespace TheWarTimeGame.ConfigHandler
{
    public class XMLparser
    {
        XDocument xmlDoc = XDocument.Load(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, @"./defaultConfig.xml"));
        public XMLparser(ILocation x)
        {
            

            foreach (XElement element in xmlDoc.Root.Element("Locations").Element("Home").Elements("Items").Elements("Item"))
            {
                double price;
                if ((double)element.Attribute("price") == null)
                {
                    price = 1;
                }

                price = (double)element.Attribute("price");
                ITem item = ItemFactory.CreateItem((string)element.Attribute("name"), price);
                x.Loot.Add(new KeyValuePair<int, ITem>((int)element.Attribute("id"), item));

            }

        }
    }

    public class ItemFactory
    {
        protected ItemFactory()
        {

        }

        public static ITem CreateItem(string itemType, double price)
        {
            switch (itemType.ToLower())
            {
                case "knife":
                    return new Knife(0, price);
                case "pistol":
                    return new Pistol(price, PistolPerks.BetterAmmo);
                case "soupcan":
                    return new SoupCan(price);
                case "water":
                    return new Water(price);
                default:
                    return new Water(price);
            }
        }
    }
}
