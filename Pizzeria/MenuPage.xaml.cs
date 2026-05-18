using System.Collections.ObjectModel;

namespace Pizzeria
{
    public class Danie
    {
        public string Nazwa { get; set; }
        public string Opis { get; set; }
        public decimal Cena { get; set; }
        public string Obraz { get; set; }
        public Danie(string nazwa, string opis, decimal cena, string obraz)
        {
            Nazwa = nazwa;
            Opis = opis;
            Cena = cena;
            Obraz = obraz;
        }
    }

    public partial class MenuPage : ContentPage
    {
        public ObservableCollection<Danie> Menu { get; } = new ObservableCollection<Danie>
        {
            new Danie("Pizza", "Pizzowa", 12_50, "pizza_image.png"),
            new Danie("Pizza2", "Pizzogranie", 25_39, "pizza_image.png")
        };

        public MenuPage()
        {
            InitializeComponent();
            BindingContext = this;
            CollectionMenu.ItemsSource = Menu;
        }

        private void MenuTab_Tapped(object sender, TappedEventArgs e)
        {
            
        }
    }
}
