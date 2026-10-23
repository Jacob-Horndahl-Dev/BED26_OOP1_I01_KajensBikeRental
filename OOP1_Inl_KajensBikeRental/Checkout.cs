namespace OOP1_Inl_KajensBikeRental
{
    internal class Checkout
    {
        public void PrintReciet(Rental r,int rentTime, bool isMember) //Stoppa in en kund istället för bool?
        {
            Console.WriteLine($"\n--- KVITTO #{r.Id} ---");
            Console.WriteLine("-------------------");
            Console.WriteLine("Du har hyrt:");
            foreach (Vehicle v in r.rentalOrder)
            {
                Console.WriteLine($"Fordon ID{v.Id,-3} {v.ModelName,-10} med pris {v.Price} SEK/T{-7} i {rentTime} timmar");
                Console.WriteLine($"Pris: {rentTime}h á {v.Price} kr/h : {r.Total()} kr");
                Console.WriteLine($"Rabatt: {r.Discount:F2} kr");
                Console.WriteLine($"Att betala: {r.Checkout(isMember):F2} kr");
                Console.WriteLine($"Moms 25% {r.Checkout(isMember) * 0.25m:F2} kr");
                Console.WriteLine("-----------------");
                Console.WriteLine("Välkommen åter!");
            }
        }
    }
}
