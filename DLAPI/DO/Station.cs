using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DO
{
    public class Station
    {
        public int CodeLine { get; set; }
        public string NameOfLine { get; set; }
        public int StationNumberOnLine { get; set; }
        public override string ToString()
        {
            return this.ToStringProperty();
        }

    }
}
