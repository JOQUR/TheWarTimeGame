using TheWarTimeGame.Items;

namespace TheWarGameUnitTesting
{
    public class PistolTest
    {
        [Theory]
        [InlineData(20, 14)]
        [InlineData(5, 0)]
        public void test_pistol_attack(double val, double exp)
        {
            double health = val;
            Pistol pistol = new Pistol();
            pistol.Attack(ref health);
            Assert.Equal(exp, health);
        }
    }
}