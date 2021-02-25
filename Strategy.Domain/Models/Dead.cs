using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Strategy.Domain.Models
{
    class Dead : Unit
    {
        public Dead(Player player) : base(player)
        {
            Image = DataSet.InitializeDeadUnitImage();
        }
        //public Player Player { get; }

        new public static ImageSource Image { get; set; }
        
    }
}
