using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class LineTrip
    {
        public int CodeLineTrip { get; set; }
        public int CodeLine { get; set; }
        public TimeSpan StartAtTime { get; set; }
        public override string ToString() => this.ToStringProperty();
        public bool Active { get; set; } 
    }
}
