using Strategy.Domain;

namespace Strategy.Domain.Models
{
    /// <summary>
    /// Лучник.
    /// </summary>
    public sealed class Archer : Unit
    {
        const int MAX_STEPS = 3;
        /// <inheritdoc />
        public Archer(Player player) : base(player)
        {
            HP = DataSet.InitializeArcherHP();
            Image = DataSet.InitializeArcherImage();
            AttackRange = DataSet.InitializeAttackRangeOfArcher();
            DamageValue = DataSet.InitializeArcherDamageValue();
        }

        public override bool IsMelee() => false;
        public override int MaxSteps { get => MAX_STEPS; }
    }
}