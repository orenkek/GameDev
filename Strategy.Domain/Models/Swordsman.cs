namespace Strategy.Domain.Models
{
    /// <summary>
    /// Класс мечника.
    /// </summary>
    public sealed class Swordsman : Unit
    {
        const int MAX_STEPS = 5;
        public Swordsman(Player player) : base(player)
        {
            HP = DataSet.InitializeSwordsmanHP();
            Image = DataSet.InitializeSwordsmanImage();
            AttackRange = DataSet.InitializeAttackRangeOfSwordsman();
            DamageValue = DataSet.InitializeSwordsmanDamageValue();
        }

        public override bool IsMelee() => true;
        public override int MaxSteps { get => MAX_STEPS; }
    }
}