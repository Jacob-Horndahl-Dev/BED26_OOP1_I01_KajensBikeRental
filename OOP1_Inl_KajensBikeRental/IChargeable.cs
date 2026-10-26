namespace OOP1_Inl_KajensBikeRental
{
    internal interface IChargeable
    {
        int BatteryCharge { get; }
        void DeCharge(int hours);
        void ReCharge();
    }
}
