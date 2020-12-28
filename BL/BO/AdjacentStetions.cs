using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    class AdjacentStetions
    {
        BO.Station Station1 { get; set; }
        BO.Station  Station2 { get; set; }
        public double Distance { get; set; }
        public TimeSpan Time { get; set; }
    }
}

