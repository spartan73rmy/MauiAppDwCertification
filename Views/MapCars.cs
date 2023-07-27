using AppDWCert.Context;
using AppDWCert.Models;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;

namespace AppDWCert.Views
{
    public class MapCars : ContentPage
    {
        Microsoft.Maui.Controls.Maps.Map map;
        public MapCars()
        {
            Title = "Carros Cerca";
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var location = await Geolocation.Default.GetLocationAsync();
            map = new(MapSpan.FromCenterAndRadius(location, Distance.FromKilometers(1)))
            {
                IsShowingUser = true
            };

            map.MapElements.Add(new Circle
            {
                Center = new Location(location.Latitude, location.Longitude),
                Radius = new Distance(250),
                StrokeWidth = 8,
                StrokeColor = Color.FromRgba("#FF9900"),
                FillColor = Color.FromRgba("#D46A6A")
            });

            var carsForSale = await new RestService().GetListAsync<Car>("CarsForSalesApi");
            foreach (var car in carsForSale)
            {
                if (car.Lat is null || car.Lon is null)
                    continue;
                map.Pins.Add(new Pin()
                {
                    Label = $"{car.Brand} - {car.Model}",
                    Location = new Location(car.Lat.Value, car.Lon.Value),
                });
            }
            Content = map;
        }
    }
}
