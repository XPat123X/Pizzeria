using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;

namespace Pizzeria
{
    public class Danie : INotifyPropertyChanged
    {
        public string Nazwa { get; set; }
        public string Opis { get; set; }
        public double Cena { get; set; }
        public string Obraz { get; set; }
        private bool _Wysuniete { get; set; }
        public bool Wysuniete {
            get
            { 
                return _Wysuniete;
            }
            set
            {
                _Wysuniete = value;
                RaisePropertyChanged(nameof(Wysuniete));
            }
        }
        public Danie(string nazwa, string opis, double cena, string obraz)
        {
            Nazwa = nazwa;
            Opis = opis;
            Cena = cena;
            Obraz = obraz;
            Wysuniete = false;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public virtual void RaisePropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void UstawWysuniete()
        {
            Wysuniete = !_Wysuniete;
        }
    }

    public partial class MenuPage : ContentPage
    {
        public ObservableCollection<Danie> Menu { get; set; } = new ObservableCollection<Danie>
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
            danie.UstawWysuniete();
        }
    }
}
