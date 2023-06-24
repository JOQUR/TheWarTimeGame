using TheWarTimeGame.Items;

namespace TheWarTimeGame.Characters;

public class ConsumablesVendor : Vendor
{
    public ConsumablesVendor(List<ITem>? items, double money) : base(items, money) { }
}