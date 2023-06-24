using TheWarTimeGame.Characters;

namespace TheWarTimeGame.Items;

public interface IWeapon : ITem
{
    void Attack(ref Enemy enemy); 
    void Bleeding(ref Enemy enemy);
}