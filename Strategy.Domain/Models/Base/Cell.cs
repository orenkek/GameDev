using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Strategy.Domain.Models.Base
{
    public class Cell
    {
        public Cell()
        {

        }
        public int X { get; set; }
        public int Y { get; set; }

        public Coordinates GetCoordinates() => new Coordinates(X, Y);
        public virtual ImageSource Image { get; set; }
    }
}
