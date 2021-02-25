using Strategy.Domain.Models.Base;

namespace Strategy.Domain.Models
{
    /// <summary>
    /// Непроходимая наземная поверхность.
    /// </summary>
    public sealed class Water : Cell
    {
        /// <inheritdoc />
        public Water() : base()
        {

        }
    }
}