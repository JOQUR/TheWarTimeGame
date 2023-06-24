using TheWarTimeGame.Items;

namespace TheWarTimeGame.Characters;

public class WeaponVendor : Vendor
{
    public WeaponVendor(List<ITem>? items, double money) : base(items, money) { }
}