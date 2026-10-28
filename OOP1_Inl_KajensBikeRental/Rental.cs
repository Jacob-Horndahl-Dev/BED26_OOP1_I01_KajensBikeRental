namespace OOP1_Inl_KajensBikeRental
{
    internal class Rental
    {
        public int Id { get; private set; }                           //dateTime start hyrtid borde egentigen finnas med här
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
        public decimal Total(int hours)
        {
            decimal total = 0m;
                foreach (Vehicle v in rentalOrder)
                {
                    total += v.Price * hours;
                }
             return total;
        }
        public decimal Discount(int hours)
        {
            decimal discount = 0m;
            bool isMember = RentalCustomer.IsMember; //kollar om kunden i uthyrningen är medlem
            if (isMember)
            {
                foreach (Vehicle v in rentalOrder)
                {
                    discount = discount + (v.Price * 0.1m) * hours;
                }
            }            
            return discount;
        }
        public decimal Checkout(int hours)
        {
            decimal finalTotal = Total(hours) - Discount(hours);
            return Math.Max(0, finalTotal);                  //Ifall det blir något fel med rabatter kan priset aldrig gå under noll
        }
    }
}
