﻿using System.Diagnostics;
using TheWarTimeGame.Items;

namespace TheWarTimeGame.Characters;

public class Player : IHuman
{
    public double Health { get; set; }
    public double Hunger { get; set; }
    public List<ITem> Equipment { get; set; }
    private static Player? _player;
    public IWeapon? Weapon;

    private Player()
    {
        this.Health = 10;
        this.Hunger = 10; 
        Equipment = new List<ITem>();
        Weapon = new Knife(KnifePerks.Standard, 2);
    }

    public static Player GetPlayerInstance()
    {
        return _player ??= new Player();
    }
    public void Attack(ref double health)
    {
        Debug.Assert(Weapon != null, nameof(Weapon) + " != null");
        Weapon.Attack(ref health);
    }

    public void Eat(IFood food)
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