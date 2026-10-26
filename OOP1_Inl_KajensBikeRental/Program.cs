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

new Bicycle("Mountainbike D-Trail");
new Bicycle("Damcykel Crescent");
new Bicycle("Hybrid ZJ600");
new ElectricBike("City EC3900");
new ElectricBike("Mountainbike Breeze");
new ElectricBike("Lådcykel Carrier");
Vehicle debugBike1 = Vehicle.vehicles[5];
((ElectricBike)debugBike1).DeCharge(9);


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

            break;
        case "3":

            break;
        case "4":

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