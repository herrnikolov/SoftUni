public class FakeWeapom : IWeapon
{
    public int DurabilityPoints => 0;

    public int AttackPoints => 0;

    public void Attack(ITarget target)
    {
    }
}
