using Strategy.Domain.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy.Domain.Models
{
    abstract public class Unit : Cell
    {
        public Unit(Player player)
        {
            Player = player;
        }

        public Player Player { get; }

        public virtual int MaxSteps { get; set; }
    }
}
