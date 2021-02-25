using Strategy.Domain.Models.Base;

namespace Strategy.Domain.Models
{
    /// <summary>
    /// Проходимая поверхность на земле.
    /// </summary>
    public sealed class Grass : Cell
    {
        /// <inheritdoc />
        public Grass() : base()
        {
            Image = DataSet.InitializeGrassImage();
        }
    }
}