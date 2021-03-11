namespace Strategy.Domain.Models
{
    /// <summary>
    /// Класс всадника.
    /// </summary>
    public sealed class Horseman : Unit
    {
        /// <inheritdoc />
        public Horseman(Player player) : base(player)
        {
            HP = DataSet.InitializeHorsemanHP();
            Image = DataSet.InitializeHorsemanImage();
            AttackRange = DataSet.InitializeAttackRangeOfHorseman();
            DamageValue = DataSet.InitializeHorsemanDamageValue();
            MaxSteps = DataSet.InitializeHorsemanMaxSteps();
        }

        public override bool IsMelee() => true;
    }
}