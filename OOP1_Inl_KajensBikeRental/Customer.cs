namespace OOP1_Inl_KajensBikeRental
{
    internal class Customer
    {
        public string Name { get; private set; }
        public int Age { get; private set; } //hmm denna borde uppdateras med tiden
        public bool Is15 => Age >= 15;
        public bool Is18 => Age >= 18;
        public int CustomerNo { get; private set; } = 0000;
        public bool IsMember => CustomerNo > 0; //koden gick att förenkla. boolen kontrolleras varje gång egenskapen anropas.
        /*{
            get
            {
                if (CustomerNo > 0)
                return true;
                else return false;
            }
            private set;    //gick inte att blanda egen definiering och private set (varning)
        }*/
        public static List<Customer> customers { get; private set; } = [];
        public Customer (string  name, int age)
        {
            Name = name;
            Age = age;
            customers.Add(this);
        }
        public void UpdateMemberAge(int age)
        {
            Age = age;
        }
        public void AddMembership()         //Jag tyckte det vore kul att slumpa fram kundnummer:
        {
            Random rnd = new Random();
            string shortYear = DateTime.Now.Year.ToString().Substring(2); //se vehicles för förklaring

            int generatedNo = 0000;
            bool isUnique = false;          //Måste kontrollera att två kundnummer inte slumpas lika
            
            while (!isUnique)
            {
                int randomNumber = rnd.Next(0001, 10000); // Slumpa 0001-9999, next inkluderar inte maxvärdet
                string firstFour = randomNumber.ToString("D4"); //måste ha det här så tal under 1000 inte blir kortare.
                generatedNo = int.Parse(shortYear + firstFour);
                
                bool alreadyExists = customers.Any(c => c.CustomerNo == generatedNo); //kontroll om kundnummer redan finns i kundlistan. Any = true om något enda objekt hittas

                if (!alreadyExists)
                {
                    isUnique = true; //om numret inte redan finns slutar slumpgeneratorn och kontroll-loopen
                }
            }            
            CustomerNo = generatedNo;            
        }
    }
}
