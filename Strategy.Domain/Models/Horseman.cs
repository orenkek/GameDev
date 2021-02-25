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

        }

        public override int MaxSteps { get => 3; set => MaxSteps = value; }
    }
}