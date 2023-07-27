using AppDWCert.Context;
using AppDWCert.Models;

namespace AppDWCert.Views;

public partial class AddCar : ContentPage
{
    public AddCar()
    {
        InitializeComponent();
    }

    private async void btnAceptar_Clicked(object sender, EventArgs e)
    {
        var location = await Geolocation.Default.GetLocationAsync();

        PermissionStatus status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
        if (status == PermissionStatus.Denied)
        {
            await DisplayAlert("Permiso", "La aplicacion requiere la ubicacion para guardar el carro", "Ok");
            return;
        }

        if (location is null)
            return;

        var car = new Car()
        {
            Brand = EntryMarca.Text,
            Model = EntryModelo.Text,
            Description = EntryDescripcion.Text,
            Year = int.Parse(EntryYear.Text),
            Price = decimal.Parse(EntryPrecio.Text),
            Lat = location.Latitude,
            Lon = location.Longitude,
            PhotoUrl = "https://static.wikia.nocookie.net/disney/images/6/6f/Profile_-_Maui.jpeg/revision/latest/thumbnail/width/360/height/360?cb=20190628013307"
        };

        await new RestService().Set("CarsForSalesApi", car);
        _ = await Navigation.PopAsync(true);
    }
}