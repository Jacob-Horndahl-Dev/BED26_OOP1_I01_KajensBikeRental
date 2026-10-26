using OOP1_Inl_KajensBikeRental;

Console.WriteLine("o/-o  K A J E N S  C Y K E L U T H Y R N I N G  o/-o");

//<---- Backlog <----
//Customer klass
//Rental klass
//Interface renteable??
//Kassa klass
//Json lista för cyklarna
//Menyn

/// Program init ///
///

/// Testobjekt att starta med ///
/// 

new Bicycle("Mountainbike D-Trail");        //Cyklar som finns i listan att hyra som default
new Bicycle("Damcykel Crescent");
new Bicycle("Hybrid ZJ600");
new ElectricBike("City EC3900");
new ElectricBike("Mountainbike Breeze");
new ElectricBike("Lådcykel Carrier");

Vehicle debugBike1 = Vehicle.vehicles[5];
((ElectricBike)debugBike1).DeCharge(9);     //Laddar ur en elcykel för test.

Customer debugMember1 = new Customer("Gabbro", 25);     //Två testkunder en över 18 och en under
Customer debugMember2 = new Customer("Feldspar", 16);
debugMember1.AddMembership();
debugMember2.AddMembership();

Vehicle debugBike2 = Vehicle.vehicles[1];     //Lånar ut en cykel för testning.
debugBike2.RentBike();
Rental debugRental = new Rental(debugMember1);
debugRental.RentVehicle(debugBike2);

/*Vehicle debugBike3 = Vehicle.vehicles[3];     //Lånar ut en cykel till i samma order för testning.
debugBike3.RentBike();
debugRental.RentVehicle(debugBike3);*/

Console.WriteLine($"DEBUG: kundnummer >18: {debugMember1.CustomerNo}");     //Skriver ut kundnumren som man kan testa att använda högst upp i programmet
Console.WriteLine($"DEBUG: kundnummer <18: {debugMember2.CustomerNo}");

/// Program RUN ///
/// 

bool run = true;
while (run == true)
{    
    Console.WriteLine("=========== M E N Y ==========");
    Console.WriteLine("[1] Visa alla cyklar");
    Console.WriteLine("[2] Registrera kund");
    Console.WriteLine("[3] Uthyrning");
    Console.WriteLine("[4] Återlämning och betalning");
    Console.WriteLine("[5] Ladda elcykel");
    Console.WriteLine("[6] Avsluta");
    Console.WriteLine("==============================");
    Console.WriteLine("Välj [1]-[6]:");
    string menuChoice = Console.ReadLine();
    //Console.Clear();                            //Clear tar bort för mycket känns ointuitivt, måste flyttas
    switch(menuChoice)
    {
        case "1":
            Console.WriteLine("[1] - Visar alla cyklar:");
            foreach (Vehicle v in Vehicle.vehicles)
            {
                v.ShowInfo();
            }
            break;

        case "2":
            Console.WriteLine("[2] - Registrera ny kund.");
            Console.WriteLine("Ange kundens namn:");
            string newCustomerName = Console.ReadLine();
            Console.WriteLine("Ange ålder:");
            int newCustomerAge;
            while (!int.TryParse(Console.ReadLine(), out newCustomerAge) || newCustomerAge < 1 || newCustomerAge > 120)
            {
                Console.WriteLine("Ange ålder i heltal:");
            }
            if (newCustomerAge < 15)
            {
                Console.WriteLine("Kunden måste vara minst 15 år för att registreras, avbryter registrering.");
            }
            else if (newCustomerAge > 100)
            {
                Console.WriteLine("På grund av skaderisk får kunden inte vara över 100 år, avbryter registrering.");
            }
            else
            {
                Customer newCustomer = new Customer (newCustomerName, newCustomerAge);
                newCustomer.AddMembership();
                Console.WriteLine($"Kund {newCustomer.Name} med ålder {newCustomer.Age} har lagts till!");
                Console.WriteLine($"Kunden har fått kundnummer: {newCustomer.CustomerNo}");
                Console.WriteLine("OBS! Spara kundnumret och ange vid uthyrning så får kunden 10% rabatt!");
                Console.WriteLine("Tryck för att fortsätta..");
                Console.ReadLine();
            }
            break;

        case "3":
            Console.WriteLine("[3] - Uthyrning.");
            Console.WriteLine("Vilken cykel ska hyras ut?");
            foreach (Vehicle v in Vehicle.vehicles)
            {
                v.ShowInfo();
            }
            Console.WriteLine("Skriv ID-numret på cykeln som ska hyras:");
            int rentalIdChoice;
            while(!int.TryParse(Console.ReadLine(), out rentalIdChoice))
            {
                Console.WriteLine("Du måste ange ett heltal:");
            }
            string rentalIdSearchString = rentalIdChoice.ToString();    //Gick inte att använda contains utan att göra om till string
            var choiceToRent = Vehicle.vehicles
                .Where(v => v.Id
                .ToString()
                .EndsWith(rentalIdSearchString)) //ends with istället för contains, annars kan den råka ta årtalet 26 istället för cykel 002
                .FirstOrDefault(); //Tar första matchningen ifall hittar flera
            if (choiceToRent == null)
            {
                Console.WriteLine("Ingen cykel med angivet ID hittades.");
                Console.WriteLine("Återgår till menyn.");
                break;
            }                
            if (choiceToRent.IsRented)
            {
                Console.WriteLine($"{choiceToRent.Id} - {choiceToRent.ModelName} är redan uthyrd, välj en annan cykel.");
                break;
            }
            else if (choiceToRent is IChargeable chargeableVehicle && chargeableVehicle.LowBatteryWarning) //kontrollerar om valt fordon är laddbart, om den inte är det kollar den inte batterinivån.
            {
                Console.WriteLine($"{choiceToRent.Id} - {choiceToRent.ModelName} har för lågt batteri, ladda, byt batteri eller välj en annan cykel.");
                break;
            }            
            Console.WriteLine($"Du har valt {choiceToRent.Id} - {choiceToRent.ModelName}");
            Console.WriteLine("Är kunden medlem? j/n");
            var rentalCustomer = new Customer("Ej medlem", 0);
            string rentMemberOrNonMember = Console.ReadLine().ToLower().Trim();
            switch (rentMemberOrNonMember)
            {
                case "j":
                case "ja":
                case "y":
                case "yes":
                    Console.WriteLine("Ange medlemsnummer (ÅÅXXXX):");                    
                    int memberNoSearch;
                    while (!int.TryParse(Console.ReadLine(), out memberNoSearch) || memberNoSearch == 0)
                    {
                        Console.WriteLine("Du måste ange ett sexsiffrigt nummer (ÅÅNNNN):");
                    }
                    rentalCustomer = Customer.customers.Where(c => c.CustomerNo == memberNoSearch).FirstOrDefault();
                    if (rentalCustomer == null)
                    {
                        Console.WriteLine("Kundnummer kunde ej hittas.");
                        Console.WriteLine("Fortsätter utan medlemskap...");
                        goto default;
                    }
                    if (!rentalCustomer.Is18 && choiceToRent is IChargeable)
                    {
                        Console.WriteLine("Tyvärr är det 18-årsgräns på elcyklar, välj en annan cykel.");
                        continue;
                    }                    
                    break;
                default:
                    //Om man inte är medlem görs default non member här + ålderskontroll för icke medlem
                    Console.WriteLine("Uthyrning utan medlemsskap.");
                    Console.WriteLine("Hur gammal är du?");
                    int nonMemberAge;
                    while (!int.TryParse(Console.ReadLine(), out nonMemberAge) || nonMemberAge < 1 || nonMemberAge > 120)
                    {
                        Console.WriteLine("Ange ålder i heltal:");
                    }
                    if (nonMemberAge >= 15 && nonMemberAge < 18 && choiceToRent is IChargeable)
                    {
                        Console.WriteLine("Tyvärr är det 18-årsgräns på elcyklar, välj en annan cykel.");
                        continue;
                    }
                    else if (nonMemberAge < 15)
                    {
                        Console.WriteLine("Du måste tyvärr vara minst 15 år för att hyra en cykel och 18 år för att hyra en elcykel.");
                        continue;
                    }
                    rentalCustomer.UpdateMemberAge(nonMemberAge);
                    break;
            }
            Console.WriteLine($"Toppen! Du har lånat {choiceToRent.ModelName}.");
            Console.WriteLine($"Pris {choiceToRent.Price} kr/h");
            Console.WriteLine("Din kostnad räknas ut när du återlämnar cykeln, ha en trevlig tur!");
            choiceToRent.RentBike();            
            Rental newRental = new Rental(rentalCustomer);  //tidpunkten för uthyrning bör egentligen loggas här
            newRental.RentVehicle(choiceToRent);
            Console.WriteLine($"Uthyrningsnummer #{newRental.Id}");
            Console.WriteLine("Tryck för att fortsätta...");
            Console.ReadLine();

            break;
        case "4":
            Console.WriteLine("[4] - Återlämning & betalning");
            Console.WriteLine("Vilken cykel ska lämnas tillbaka?");
            foreach (Vehicle v in Vehicle.vehicles)
            {
                v.ShowInfo();
            }
            Console.WriteLine("Skriv ID-numret på cykeln som ska återlämnas:");
            int returnIdChoice;
            while (!int.TryParse(Console.ReadLine(), out returnIdChoice))
            {
                Console.WriteLine("Du måste ange ett heltal:");
            }
            string returnIdSearchString = returnIdChoice.ToString();    //Gick inte att använda contains utan att göra om till string
            var choiceToReturn = Vehicle.vehicles
                .Where(v => v.Id
                .ToString()
                .EndsWith(returnIdSearchString)) //ends with istället för contains, annars kan den råka ta årtalet 26 istället för cykel 002
                .FirstOrDefault(); //Tar första matchningen ifall hittar flera
            if (choiceToReturn == null)
            {
                Console.WriteLine("Ingen cykel med angivet ID hittades.");
                Console.WriteLine("Återgår till menyn.");
                break;
            }
            if (!choiceToReturn.IsRented)
            {
                Console.WriteLine($"{choiceToReturn.Id} - {choiceToReturn.ModelName} är inte uthyrd, välj en annan cykel.");
                break;
            }
            Console.WriteLine($"Du har valt att återlämna {choiceToReturn.Id} - {choiceToReturn.ModelName}");

            var rentalToReturn = Rental.rentalsHistory.FirstOrDefault(r => r.rentalOrder.Any(v => v.Id == choiceToReturn.Id)); //hämtar den senaste uthyrningen där den cykeln är med i, lite komplicerat!
            if (rentalToReturn == null)
            {
                Console.WriteLine("Kunde inte hitta någon uthyrning kopplad till denna cykel.");
                Console.WriteLine("Avbryter...");
                break;
            }

            Console.WriteLine($"Ordernr #{rentalToReturn.Id}"); //funktion för att hitta senaste ordern med den cykeln i
            Console.WriteLine("Hur många timmar har du haft cykeln?"); //Egentligen bör en date time funktion användas här tillammans med en som sätts när cykeln hyrs.
            int rentedHours;
            while(!int.TryParse(Console.ReadLine(), out rentedHours) || rentedHours < 0)
            {
                Console.WriteLine("Ange ett helt antal timmar:");
            }            
                Checkout.PrintReceipt(rentalToReturn, rentedHours); //skriver ut kvittot
                Console.WriteLine("");
            
            foreach (Vehicle v in rentalToReturn.rentalOrder)   //lämnar tillbaka cyklar som hyrts
            {
                v.ReturnBike();
            }
            foreach (IChargeable ev in rentalToReturn.rentalOrder.OfType<IChargeable>()) //räknar ut hur mycket batteri som gått åt. Of type behövs för att inte vanliga cyklar ska krascha programmet
            {
                ev.DeCharge(rentedHours);
            }
            Console.WriteLine("Tryck för att fortsätta...");
            Console.ReadLine();
            break;

        case "5":
            Console.WriteLine("[5] - Ladda elcykel");
            Console.WriteLine("Vilken cykel ska laddas?");
            //var electricVehiclesList = Vehicle.vehicles.Where(ev => ev.Type.Contains("Elcykel")).ToList(); //det här är sämre sätt att göra det på, interface rechargeable är bättre
            var electricVehiclesList = Vehicle.vehicles.Where(ev => ev is IChargeable).ToList(); //listar alla laddbara fordon
            //lista alla cyklar och lägg till val för vilken som ska laddas.
            for (int i = 0; i < electricVehiclesList.Count; i++)
            {
                Vehicle ev = electricVehiclesList[i]; //motsvarande Vehicle v i foreach loop
                IChargeable chargeableEv = (IChargeable)ev; //måste casta till interfacet, annars fattar den inte att det är något som kan laddas (bara vehicle)

                Console.WriteLine($"[{i+1}] {electricVehiclesList[i].ModelName, -20} | {chargeableEv.BatteryCharge}%");
            }
            int chargeChoice;
            while(!int.TryParse(Console.ReadLine(), out chargeChoice) || chargeChoice < 1 || chargeChoice > electricVehiclesList.Count)
                {
                Console.WriteLine("Ange ett korrekt index med en siffra!");
                }
            chargeChoice --; //korrigerar användarens val till listindex
            ((IChargeable)electricVehiclesList[chargeChoice]).ReCharge(); //ska cykeln gå att ladda om den är uthyrd?
            Console.WriteLine($"{electricVehiclesList[chargeChoice].ModelName} har snabbladdats till {((IChargeable)electricVehiclesList[chargeChoice]).BatteryCharge}%!");
            break;

        case "6":
            Console.WriteLine("Avslutar programmet...");
            run = false;
            break;
        default:
            Console.WriteLine("\nOgiltigt menyval. Försök igen!");
            Console.WriteLine("");
            break;
    }

}