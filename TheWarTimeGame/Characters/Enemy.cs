using TheWarTimeGame.Items;

namespace TheWarTimeGame.Characters
{
    public class Enemy : IHuman
    {
        public double Health { get; set; }
        private Pistol _pistol;

        public Enemy()
        {
        }

        public void Attack(ref Enemy enemy)
        {
            _pistol.Attack(ref enemy);
        }
    }
}
