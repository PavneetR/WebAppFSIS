﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSISSystem.ENTITIES
{
   public class Position
    {
        public int PositionID { get; set; }

        public string Description { get; set; }

        public int ReportsTo { get; set; }
    }
}
