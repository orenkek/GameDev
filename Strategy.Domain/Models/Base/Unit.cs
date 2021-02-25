﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy.Domain.Models
{
    abstract public class Unit
    {
        public Unit(Player player)
        {
            Player = player;
        }

        public int Y { get; set; }

        public int X { get; set; }

        public Player Player { get; }

        public abstract int MaxSteps { get; set; }
    }
}
