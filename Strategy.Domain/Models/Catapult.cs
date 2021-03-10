namespace Strategy.Domain.Models
{
    /// <summary>
    /// Катапульта.
    /// </summary>
    /// 
    public sealed class Catapult : Unit
    {
        const int MAX_STEPS = 1;
        public Catapult(Player player) : base(player)
        {
            HP = DataSet.InitializeCatapultHP();
            Image = DataSet.InitializeCatapultImage();
            AttackRange = DataSet.InitializeAttackRangeOfCatapult();
            DamageValue = DataSet.InitializeCatapultDamageValue();
        }
        public override bool IsMelee() => false;
        public override int MaxSteps { get => MAX_STEPS; }
    }
}