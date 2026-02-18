// Name/efternamn: Kashaf Mahmood
// Kurs: L0002B
// Uppgift: Växelräknare (Console Application)

using System; // Detta importerar System-biblioteket som används för konsol- och andra operationer

class Program
{
    static void Main()
    {
        // Frågar användaren om priset på varan
        Console.Write("Ange pris: ");
        string priceInput = Console.ReadLine() ?? ""; // den läser in pris från användaren, det kommer blir en tom sträng om det är null
        int price; // Variablen för pris

        // föröka omvandla inmatade värdet till ett heltal och kommer kontrollerar om det är giltigt
        if (!int.TryParse(priceInput, out price) || price <= 0) // Kontrollerar om priset är ett heltal och >0
        {
            // Om det är ogiltigt, vdet visar ett felmedelandet och avslutar 
            Console.WriteLine("Felaktigt värde för pris! Ange ett positivt heltal.");
            return; // Avslutar programmet
        }

        // Ffrågar om total beloppe
        Console.Write("Betalt belopp: ");
        string paidInput = Console.ReadLine() ?? ""; // Läser in betalt belopp från användaren, om null blir det en tom sträng
        int paid; // Variabel för betalt belopp

        // Försöker omvandla det inmatade beloppet till ett heltal och kontrollerar om det är giltigt
        if (!int.TryParse(paidInput, out paid) || paid <= 0) // Kontroll om beloppet är ett heltal och större än 0
        {
            // Om det är ogiltigt, visar ett felmeddelande och avslutar
            Console.WriteLine("Felaktigt värde för betalt belopp! Ange ett positivt heltal.");
            return; // Avslutar programmet
        }

        // Kontrollera om det betalt beloppet är mindre än priset
        if (paid < price) // Om användaren betalat för lite
        {
            // Visarr ett felmeddelande om att betalningen är otillräcklig
            Console.WriteLine("Betalningen är för liten!");
            return; // Avslutar programmet
        }

        // Beräkna växel som ska man ska få tillbaka
        int change = paid - price; // skillnaden mellan betalt belopp och pris
        Console.WriteLine($"\nVäxel tillbaka: {change} SEK\n"); // Skriver ut hur mycket växel som man ska få tillbaka

        // Lista av valörer som används i Sverige
        int[] denominations = { 500, 200, 100, 50, 20, 10, 5, 1 }; // Array som innehåller alla sedlar och mynt

        // Loop för att beräkna antalet sedlar och mynt för varje valör
        foreach (int denomination in denominations) // Itererar över varje valör i arrayen
        {
            int count = change / denomination; // Räkna hur många av denna  som behövs
            change = change % denomination; // Uppdatera återstående växel

            // Om antalet av denna  är större än noll
            if (count > 0)
            {
                // Skriverut antalet sedlar/mynt för denna valör
                Console.WriteLine($"{count} x {denomination}-SEK");
            }
        }

        // Avslutningsmeddelande, den väntar på att användaren trycker på en tangent
        Console.WriteLine("\nTryck på valfri tangent för att avsluta..."); // Informerar användaren
        Console.ReadLine(); // Väntar på att användaren trycker Enter innan programmet avslutas
    }
}
