namespace OOP1_Inl_KajensBikeRental
{
    internal class Bicycle : Vehicle
    {
        public override string Type => "Cykel";
        public override decimal Price =>    40m; //Om programmet byggs ut borde detta ersättas med metod för att sätta pris.
        public Bicycle(string name) : base(name) //Cykelklassen är i princip tom, men det blir mer framtidssäkert att inte ha den som bas
        {
        }
    }
}
