namespace Strategy.Domain.Models
{
    /// <summary>
    /// Класс всадника.
    /// </summary>
    public sealed class Horseman : Unit
    {
        const int MAX_STEPS = 10;
        /// <inheritdoc />
        public Horseman(Player player) : base(player)
        {
            HP = DataSet.InitializeHorsemanHP();
            Image = DataSet.InitializeHorsemanImage();
            AttackRange = DataSet.InitializeAttackRangeOfHorseman();
            DamageValue = DataSet.InitializeHorsemanDamageValue();
        }

        public override bool IsMelee() => true;
        public override int MaxSteps { get => MAX_STEPS; }
    }
}