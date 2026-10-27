namespace OOP1_Inl_KajensBikeRental
{
    internal class Checkout
    {
        public static void PrintReceipt(Rental r,int rentTime)
        {
            Console.WriteLine($"\n   --- KVITTO #{r.Id} ---");
            Console.WriteLine("-----------------------");
            Console.WriteLine("Du har hyrt:");
            foreach (Vehicle v in r.rentalOrder)
            {
                Console.WriteLine($"Fordon ID{v.Id,-3} {v.ModelName,-10} med pris {v.Price} kr/h i {rentTime} timmar");
                Console.WriteLine($"Pris: {rentTime}h á {v.Price} kr/h : {v.Price * rentTime} kr");              
            }
            Console.WriteLine("-----------------------");
            Console.WriteLine($"Medlem: {r.RentalCustomer.Name} | Kundnummer: {r.RentalCustomer.CustomerNo}");
            Console.WriteLine($"Rabatt: {r.Discount(rentTime):F2} kr");
            Console.WriteLine($"Att betala: {r.Checkout(rentTime):F2} kr");
            Console.WriteLine($"Moms 25% {r.Checkout(rentTime) * 0.25m:F2} kr");
            Console.WriteLine("-----------------------");
            Console.WriteLine("Välkommen åter!");
            Console.WriteLine("");
            Console.WriteLine("Kajens cykeluthyrning AB");
            Console.WriteLine("Org: 5555 3333 4444 8888");
            Console.WriteLine("-----------------------");
        }
    }
}
