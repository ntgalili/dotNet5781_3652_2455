using DO;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    class Trip : User
    {
        public int Id { get; set; }
        //public string UserName { get; set; }  -----------name of user
        public int CodeLine { get; set; }
        //public int FCodeLine { get; set; }  ------------first station of the trip
        //public int LCodeLine { get; set; }  ------------last station of the trip
        public TimeSpan TimeIn { get; set; }
        public TimeSpan TimeOut { get; set; }
        public override string ToString() => this.ToStringProperty();

    }
}
