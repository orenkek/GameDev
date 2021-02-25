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

        }

        public override int MaxSteps { get => 3; set => MaxSteps = value; }
    }
}