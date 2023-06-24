using TheWarTime.Items;

namespace TheWarTimeUT
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(20, 14)]
        public void test_attack(double val, double expected)
        {
            double health = val;
            Pistol pistol = new Pistol();
            pistol.Attack(ref health);
            Assert.Equal(expected, health);
        }
    }
}