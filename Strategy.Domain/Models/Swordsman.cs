namespace Strategy.Domain.Models
{
    /// <summary>
    /// Класс мечника.
    /// </summary>
    public sealed class Swordsman : Unit
    {
        public Swordsman(Player player) : base(player)
        {

        }

        public override int MaxSteps { get => 5; set => MaxSteps = value; }
    }
}