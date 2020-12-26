using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    public class Bus
    {
        public int LicensePlate { get; set; }
        public DateTime LicensingDate { get; set; }
        public float TotalTrip { get; set; }
        public float FuelRemain { get; set; }
        public StatusOfBus Status { get; set; }

        public override string ToString()
        {
            return this.ToStringProperty();
        }

    }
}