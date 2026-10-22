using System;
using System.Collections.Generic;
using System.Text;

namespace OOP1_Inl_KajensBikeRental
{
    internal class ElectricBike : Vehicle
    {
        public override decimal Price => 70m; //Om programmet byggs ut borde detta ersättas med metod för att sätta pris.
        private int _batteryCharge; //behöver denna för att det inte ska bli en stack overflow/evig loop i get/set på public varianten.
        public int BatteryCharge
        {
            get
            {
                return Math.Max(0, _batteryCharge); //Batteriet kan inte bli lägre än noll %
            }
        
            private set
            {
                _batteryCharge = Math.Min(100, value); //Batteriet kan inte bli över 100% laddat. value är en inbyggd variabel som bara finns i set, tar värdet den får.
            }
        }
        public bool lowBatteryWarning
        { get
            {
                return (BatteryCharge < 30); // OBS! True om lägre än 30%, alltså en varning.
            } 
        }
        public ElectricBike(string name) : base(name)
        {
        }
        public void ReCharge()
        {
        BatteryCharge = 100;    //I framtiden kanske detta bör ändras så den laddar viss % per timme.
        }
        public void DeCharge(int hours)
        {
            BatteryCharge -= hours * 10;
        }
    }
}
