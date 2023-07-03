using TheWarTimeGame.Characters;

namespace TheWarTimeGame.Items;

public interface IWeapon : ITem
{
    void Attack(ref double health); 
    void Bleeding(ref double health);
}