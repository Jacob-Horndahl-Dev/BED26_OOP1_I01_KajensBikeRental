namespace OOP1_Inl_KajensBikeRental
{
    internal class Rental
    {
        public int Id { get; private set; }                             //Måste jag koppla rental till en kund? Eller håller menyn reda på det? //ska hyrtiden vara med här? eller räknas ut i kassan?
        public List<Vehicle> rentalOrder { get; private set; } = []; //Vilka cyklar en person lånar stoppas in här
        public static List<Rental> rentalsHistory { get; private set; } = []; //historik över uthyrning
        public Customer RentalCustomer { get; private set; } //så kunden sparas i uthyrningen
        public Rental(Customer c) //när vi skapar en uthyrning skapar vi behållaren först och sen lägger in vad man hyr (tex så man kan hyra fler cyklar samtidigt senare och inte ett specifikt antal)
        {
            Id = Rental.rentalsHistory.Count + 1;
            rentalsHistory.Add(this);
            RentalCustomer = c;
        }
        public void RentVehicle(Vehicle v)
        {
            rentalOrder.Add(v);
            //Sätta v.RentBike() här?
        }
        public decimal Total(Rental r, int hours)
        {
            decimal total = 0;
                foreach (Vehicle v in rentalOrder)
                {
                    total = total + v.Price * hours;
                }
             return total;
        }
        public decimal Discount(bool isMember, int hours)
        {
            decimal discount = 0;
            if (isMember)
            {
                foreach (Vehicle v in rentalOrder)
                {
                    discount = discount + (v.Price * 0.1m) * hours;
                }
            }            
            return discount;
        }
        public decimal Checkout(bool isMember, int hours)
        {
            decimal finalTotal = Total() - Discount(isMember);
            return Math.Max(0, finalTotal);                  //Ifall det blir något fel med rabatter kan priset aldrig gå under noll
        }
    }
}
