using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy.Domain.Models
{
    class Dead : Unit
    {
        public Dead(Player player) : base(player)
        {
            Player.Portrait = DataSet.InitializeDeadUnitImage();
        }
        public Player Player { get; }
    }
}
