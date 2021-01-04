using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BL
{
    namespace BO
    {
        public class LineStation : BO.Station
        {
            public int LineNum { get; set; }

            public int LineStationIndex { get; set; }
            public BO.Station PrevStation { get; set; }
            public BO.Station NextStation { get; set; }
        }
    }
}
