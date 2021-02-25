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
            _hp = DataSet.InitializeHorsemanHP();
            Image = DataSet.InitializeHorsemanImage();
        }

        public override int MaxSteps { get => MAX_STEPS; }
    }
}