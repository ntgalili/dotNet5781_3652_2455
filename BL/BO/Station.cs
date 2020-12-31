using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    class Station
    {
        public string Name { get; set; }
        public int Code { get; set; }
        public override string ToString() => this.ToStringProperty();
        public StationInclude Include { get; set; }
        public double Longitude { get; set; }
        public double Lattitude { get; set; }
        public bool Active { get; set; }

    }
}