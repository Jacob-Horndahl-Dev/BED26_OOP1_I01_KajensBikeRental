using System;
using System.Collections.Generic;
using System.Text;

namespace OOP1_Inl_KajensBikeRental
{
    internal class ElectricBike : Vehicle
    {
        public override decimal Price => 70m; //Om programmet byggs ut borde detta ersättas med metod för att sätta pris.
        public int BatteryCharge { get; private set; } = 100;
        public bool lowBatteryWarning
        { get
            {
                return (BatteryCharge < 30); // OBS! True om lägre än 30%, alltså en varning.
            } 
        }
        public ElectricBike(string name) : base(name)
        {
        }
        public void Charge()
        {
        BatteryCharge = 100;    //I framtiden kanske detta bör ändras så den laddar viss % per timme.
        }
    }
}
