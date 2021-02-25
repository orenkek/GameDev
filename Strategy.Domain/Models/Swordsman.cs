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
            _hp = DataSet.InitializeSwordsmanHP();
            Player.Portrait = DataSet.InitializeSwordsmanImage();
        }

        public override int MaxSteps { get => MAX_STEPS; }
    }
}