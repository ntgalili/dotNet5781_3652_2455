﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    public class LineTrip
    {
        public int CodeLineTrip { get; set; }
        public int CodeLine { get; set; }
        public TimeSpan StartAtTime { get; set; }
        public bool Active { get; set; }
        public override string ToString()  {   return this.ToStringProperty(); }

    }
}
