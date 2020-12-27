using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    class Bus
    {
        public DateTime FromDate { get; set; }
        public int LicensePlate { get; set; }
        public float TotalTrip { get; set; }
        public float FuelRemain { get; set; }
        public DO.StatusOfBus Status { get; set; }
        public override string ToString() => this.ToStringProperty();
    }
}
