using Android.OS;
using AndroidX.Core.Provider;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace Pizzeria
{
    public class Danie : ContentPage
    {
        public string Nazwa { get; set; }
        public string Opis { get; set; }
        public double Cena { get; set; }
        public string Obraz { get; set; }
        public bool Wysuniete
        {
            get;
            set {
                if(Wysuniete != value)
                {
                    Wysuniete = value;
                    OnPropertyChanged();
                }
            }
        }
        public event PropertyChangingEventHandler? PropertyChanged;
        protected override void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(
                this,
                new
                PropertyChangingEventArgs(propertyName)
            );
        }
        public Danie(string nazwa, string opis, double cena, string obraz)
        {
            Nazwa = nazwa;
            Opis = opis;
            Cena = cena;
            Obraz = obraz;
            Wysuniete = false;
        }
    }

    public partial class MenuPage : ContentPage
    {
        public ObservableCollection<Danie> Menu { get; } = new ObservableCollection<Danie>
        {
            new Danie("Pizza", "Pizzowa", 12.50, "pizza_image.png"),
            new Danie("Pizza2", "Pizzogranie", 25.39, "pizza_image.png")
        };

        public MenuPage()
        {
            InitializeComponent();

            CultureInfo culture = new CultureInfo("pl-PL");
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;

            BindingContext = this;
            CollectionMenu.ItemsSource = Menu;
        }

        private void MenuTab_Tapped(object sender, TappedEventArgs e)
        {
            HorizontalStackLayout stack = sender as HorizontalStackLayout;
            Danie danie = stack.BindingContext as Danie;

            //DisplayAlert("a", danie.Nazwa, "a");
            danie.Wysuniete = !danie.Wysuniete;
        }
    }
}
