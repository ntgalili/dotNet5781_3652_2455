using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    class Line
    {

        public int LineNum { get; set; }
        public int Code { get; set; }
        public Areas Area { get; set; }
        public LineStation FirstStation { get; set; }
        public LineStation LastStation { get; set; }

    }
}
