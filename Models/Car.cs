using AppDWCert.ViewModels.Base;
using SQLite;

namespace AppDWCert.Models
{
    public class Car : ObservableObject
    {
        int id;
        [PrimaryKey, AutoIncrement]
        public int Id { get => id; set => SetProperty(ref id, value); }

        private string brand;
        public string Brand
        {
            get => brand;
            set => SetProperty(ref brand, value);
        }

        private string model;
        public string Model
        {
            get => model;
            set => SetProperty(ref model, value);
        }

        private string description;
        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        private decimal price;
        public decimal Price
        {
            get => price;
            set => SetProperty(ref price, value);
        }

        private int year;
        public int Year
        {
            get => year;
            set => SetProperty(ref year, value);
        }

        private string photoUrl;
        public string PhotoUrl
        {
            get => photoUrl;
            set => SetProperty(ref photoUrl, value);
        }

        private double? lat;
        public double? Lat
        {
            get => lat;
            set => SetProperty(ref lat, value);
        }

        private double? lon;
        public double? Lon
        {
            get => lon;
            set => SetProperty(ref lon, value);
        }
    }
}
