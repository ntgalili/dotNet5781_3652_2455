﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DO
{
    public class Station
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public double Longitude { get; set; }
        public double Lattitude { get; set; }
        public StationInclude Include { get; set; }
        public bool Active { get; set; }
        public override string ToString()
        {
            return this.ToStringProperty();
        }

    }
}
