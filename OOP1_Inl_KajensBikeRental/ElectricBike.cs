using System;
using System.Collections.Generic;
using System.Text;

namespace OOP1_Inl_KajensBikeRental
{
    internal class ElectricBike : Vehicle
    {
        public int BatteryCharge { get; private set; }
        public bool lowBatteryWarning
        { get
            {
                return (BatteryCharge > 30); // ej kontrollerad om rätt
            } 
        }
        public ElectricBike(decimal price) : base(price)
        {
        }
    }
}
