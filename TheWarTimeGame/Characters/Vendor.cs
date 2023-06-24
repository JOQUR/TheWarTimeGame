using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TheWarTimeGame.Items;

namespace TheWarTimeGame.Characters
{
    public class Vendor
    {
        public List<ITem>? Items;
        protected double Money;

        protected Vendor(List<ITem>? items, double money)
        {
            Items = items;
            Money = money;
        }

        public void SellItems(List<ITem> items, ITem item, ref double money)
        {
            items.Add(item);
            money += item.Price;
            this.Money -= item.Price;
        }
        public void BuyItems(List<ITem> items, ITem item, ref double money)
        {
            items.Remove(item);
            money += item.Price;
            this.Money -= item.Price;
        }
    }
}
