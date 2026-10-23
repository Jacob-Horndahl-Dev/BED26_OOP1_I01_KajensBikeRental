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

new Bicycle("Cykel Mountainbike");
new Bicycle("Cykel Damcykel");
new Bicycle("Cykel Hybrid");
new ElectricBike("Elcykel City");
new ElectricBike("Elcykel Mountainbike");
new ElectricBike("Elcykel Lådcykel");


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
                v.ShowInfo(); //Fel formattering i metoden. Måste åtgärdas.
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
            var electricVehiclesList = Vehicle.vehicles.Select(ev => ev.ModelName.Contains("Elcykel")); //det här är ett dåligt sätt att göra det på, interface rechargeable??
            //lista alla cyklar och lägg till val för vilken som ska laddas.
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