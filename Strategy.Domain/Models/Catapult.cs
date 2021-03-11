namespace Strategy.Domain.Models
{
    /// <summary>
    /// Катапульта.
    /// </summary>
    /// 
    public sealed class Catapult : Unit
    {
        public Catapult(Player player) : base(player)
        {
            HP = DataSet.InitializeCatapultHP();
            Image = DataSet.InitializeCatapultImage();
            AttackRange = DataSet.InitializeAttackRangeOfCatapult();
            DamageValue = DataSet.InitializeCatapultDamageValue();
            MaxSteps = DataSet.InitializeCatapultMaxSteps();
        }
        public override bool IsMelee() => false;
    }
}