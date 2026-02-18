using Avalonia.Controls;
using Avalonia.Interactivity;

namespace ChangeCalculatorGUI
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateChange(object sender, RoutedEventArgs e)
        {
            // Läser in och validerar priset från användaren
            if (!int.TryParse(PriceTextBox.Text, out int price) || price <= 0)
            {
                // Visar ett felmeddelande om priset inte är ett positivt heltal
                ResultTextBox.Text = "Ogiltigt pris. Ange ett positivt heltal.";
                return;
            }

            // Läser in och validerar beloppet som har betalats av användaren
            if (!int.TryParse(PaidTextBox.Text, out int paid) || paid <= 0)
            {
                // Visar ett felmeddelande om beloppet inte är ett positivt heltal
                ResultTextBox.Text = "Ogiltigt belopp. Ange ett positivt heltal.";
                return;
            }

            // Kontrollera om det betalade beloppet är mindre än priset
            if (paid < price)
            {
                // Visar ett meddelande om betalningen är otillräcklig
                ResultTextBox.Text = "Betalningen är för lite!";
                return;
            }

            // Beräkna växeln
            int change = paid - price;
            string result = $"Växel tillbaka: {change} kr\n";

            // Definiera olika valörer och räkna hur många av varje som behövs
            int[] denominations = { 500, 200, 100, 50, 20, 10, 5, 1 };
            foreach (int denomination in denominations)
            {
                // Räkna hur många av en specifik valör som behövs
                int count = change / denomination;
                if (count > 0)
                {
                    // Lägg till resultatet för den aktuella valören
                    result += $"{count} x {denomination}-kronor\n";
                    // Uppdatera växeln som återstår
                    change %= denomination;
                }
            }

            // Visar slutresultatet i ResultTextBox
            ResultTextBox.Text = result;
        }

        private void ExitApplication(object sender, RoutedEventArgs e)
        {
            // Avslutar applikationen
            System.Environment.Exit(0);
        }
    }
}
