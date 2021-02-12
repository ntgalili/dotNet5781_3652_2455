using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BO
{
        public class AdjacentStetions
        {
            public Station Station1 { get; set; }
            public Station Station2 { get; set; }
            public double Distance { get; set; }
            public TimeSpan Time { get; set; }
            public bool Active { get; set; }
        }
    }

