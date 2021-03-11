using Strategy.Domain;

namespace Strategy.Domain.Models
{
    /// <summary>
    /// Лучник.
    /// </summary>
    public sealed class Archer : Unit
    {
        /// <inheritdoc />
        public Archer(Player player) : base(player)
        {
            HP = DataSet.InitializeArcherHP();
            Image = DataSet.InitializeArcherImage();
            AttackRange = DataSet.InitializeAttackRangeOfArcher();
            DamageValue = DataSet.InitializeArcherDamageValue();
            MaxSteps = DataSet.InitializeArcherMaxSteps();
        }

        public override bool IsMelee() => false;
    }
}