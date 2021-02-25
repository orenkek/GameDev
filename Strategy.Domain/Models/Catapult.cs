namespace Strategy.Domain.Models
{
    /// <summary>
    /// Катапульта.
    /// </summary>
    /// 
    public sealed class Catapult : Unit
    {
        public Catapult(Player player) : base(player)
        {

        }

        public override int MaxSteps { get => 10; set => MaxSteps = value; }

    }
}