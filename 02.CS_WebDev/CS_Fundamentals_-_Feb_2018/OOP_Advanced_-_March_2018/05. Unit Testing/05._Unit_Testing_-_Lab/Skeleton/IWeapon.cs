public interface IWeapon
{
    void Attack(ITarget target);

    int DurabilityPoints { get; }

    int AttackPoints { get; }
}