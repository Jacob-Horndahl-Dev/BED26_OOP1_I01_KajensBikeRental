namespace OOP1_Inl_KajensBikeRental
{
    internal class Vehicle
    {
        private static int _IdCounter = 1; //för att ID ska sättas automatiskt måste vi ha en variabel att utgå ifrån.
                                           //static så att den är gemensam för alla vehicle objekt
        public int Id { get; private set; }
        public string ModelName { get; private set; }
        public virtual decimal Price { get; private set; } //virtual så att olika pris för olika klasser kan sättas.
        /*public decimal FinalPrice //Räknar ut pris med rabatter utan att riskera ändra i prislista        //Lägger rabatten i rental-klassen istället för att få fordonsklassen mer städad.
        {
            get
            {
                if (IsMember == true)//bool member för rabatt? NOT IMPLEMENTED
                    return Price * 0.9m;
                else return Price;
            }
        }*/

        public bool IsRented { get; private set; } = false; //kanske måste ha protected här, vi får se
        public static List<Vehicle> vehicles { get; private set; } = []; //Lista med alla cyklar. Static = gemensam för alla objekt i klassen.

        public Vehicle(string modelName) //det enda man behöver för att skapa en vehicle är namnet, resten sköts automatiskt.
        {
            ModelName = ModelName;
            Id = _IdCounter++; //Sätter automatiskt ett id och ökar räknaren för nästa cykel
            vehicles.Add(this);  //Lägger automatiskt till alla cyklar i listan. this = det objektet som skapas just nu.
        }

        public virtual void RentBike() => IsRented = true; //pilen är ett kortare sätt att sätta variabel ist för inom måsvingar.
        public void ReturnBike() => IsRented = false;        
    }
}
