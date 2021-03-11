namespace Strategy.Domain.Models
{
    /// <summary>
    /// Класс мечника.
    /// </summary>
    public sealed class Swordsman : Unit
    {
        public Swordsman(Player player) : base(player)
        {
            HP = DataSet.InitializeSwordsmanHP();
            Image = DataSet.InitializeSwordsmanImage();
            AttackRange = DataSet.InitializeAttackRangeOfSwordsman();
            DamageValue = DataSet.InitializeSwordsmanDamageValue();
            MaxSteps = DataSet.InitializeSwordsmanMaxSteps();
        }

        public override bool IsMelee() => true;
    }
}