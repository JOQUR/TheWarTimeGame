using TheWarTimeGame.Items;

namespace TheWarTimeGame.Characters;

public class Player : IHuman
{
    public double Health { get; set; }
    public int Hunger { get; private set; }
    public List<ITem> Equipment { get; set; }
    private static Player? _player;
    private IWeapon _weapon;

    private Player()
    {
        this.Health = 10;
        this.Hunger = 10; 
        Equipment = new List<ITem>();
        {
        }
    }

    public static Player GetPlayerInstance()
    {
        return _player ??= new Player();
    }
    public void Attack(ref Enemy enemy)
    {
        _weapon.Attack(ref enemy);
    }

    public void Eat(ref Food food)
    {
        if (_player!.Equipment.Contains((food)))
        {
            _player.Equipment.Remove((food));
            _player.Hunger += food.Hunger;
            if (_player.Hunger >= 10)
            {
                _player.Hunger = 10;
            }
        }
    }


}