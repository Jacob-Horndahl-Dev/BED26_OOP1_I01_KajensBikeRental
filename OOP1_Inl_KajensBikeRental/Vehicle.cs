namespace OOP1_Inl_KajensBikeRental
{
    internal class Vehicle
    {
        private static int _IdCounter = 1; //för att ID ska sättas automatiskt måste vi ha en variabel att utgå ifrån.
                                           //static så att den är gemensam för alla vehicle objekt
        public int Id { get; private set; }
        public decimal Price { get; private set; }
        public decimal FinalPrice //Räknar ut pris med rabatter utan att riskera ändra i prislista
        { get
            {
                //bool member för rabatt? NOT IMPLEMENTED
                return Price;
            }
        }
        
        public bool IsRented { get; private set; } = false; //kanske måste ha protected här, vi får se

        public Vehicle(decimal price) //det enda man behöver för att skapa en vehicle är priset, resten sköts automatiskt.
        {
            Price = price;
            Id = _IdCounter++; //Sätter automatiskt ett id och ökar räknaren för nästa cykel
        }

        public virtual void RentBike() => IsRented = true; //pilen är ett kortare sätt att sätta variabel ist för inom måsvingar.
        public void ReturnBike() => IsRented = false;        
    }
}
