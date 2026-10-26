namespace OOP1_Inl_KajensBikeRental
{
    internal class ElectricBike : Vehicle , IChargeable
    {
        public override string Type => "Elcykel";
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
        public bool LowBatteryWarning
        { get
            {
                return (BatteryCharge < 30); // OBS! True om lägre än 30%, alltså en varning.
            } 
        }
        public ElectricBike(string name) : base(name)
        {            
            BatteryCharge = 100;
        }
        public void ReCharge()
        {
        BatteryCharge = 100;    //I framtiden kanske detta bör ändras så den laddar viss % per timme och ha en bool IsCharging när den är upptagen med att ladda (om den ska bli 100% innan uthyrning igen)
        }
        public void DeCharge(int hours)
        {
            BatteryCharge -= hours * 10; //10% per timme
        }
        public override void ShowInfo()
        {
            string rentStatus = "Ledig";
            if (IsRented) rentStatus = "Uthyrd";            

            if (LowBatteryWarning) Console.WriteLine($"ID{Id,-3} {ModelName,-20} {Price} kr/h | STATUS: {rentStatus} | Batteri {BatteryCharge}% OBS! Lågt batteri, måste laddas innan uthyrning!");
            else Console.WriteLine($"ID{Id,-3} {ModelName,-20} {Price} kr/h | STATUS: {rentStatus} | Batteri {BatteryCharge}%");
        }
    }
}
