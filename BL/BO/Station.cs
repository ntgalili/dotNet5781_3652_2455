using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    class Station
    {
        //public int CodeLine { get; set; }  ------------code of the bus on the trip
        public string Name { get; set; }
        public int Code { get; set; }
        public override string ToString() => this.ToStringProperty();

    }
}
