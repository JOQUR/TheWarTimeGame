using TheWarTimeGame.Items;

namespace TheWarTimeGame.ConfigHandler
{
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
