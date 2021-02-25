namespace Strategy.Domain.Models
{
    /// <summary>
    /// Катапульта.
    /// </summary>
    /// 
    public sealed class Catapult : Unit
    {
        const int MAX_STEPS = 1;
        public Catapult(Player player) : base(player)
        {
            _hp = DataSet.InitializeCatapultHP();
            Player.Portrait = DataSet.InitializeCatapultImage();
        }

        public override int MaxSteps { get => MAX_STEPS; }
    }
}