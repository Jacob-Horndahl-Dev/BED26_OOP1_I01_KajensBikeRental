namespace OOP1_Inl_KajensBikeRental
{
    internal interface IChargeable
    {
        int BatteryCharge { get; }
        bool LowBatteryWarning { get; }
        void DeCharge(int hours);
        void ReCharge();
    }
}
