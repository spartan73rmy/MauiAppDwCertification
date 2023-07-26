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
        var car = new Car()
        {
            Brand = EntryMarca.Text,
            Model = EntryModelo.Text,
            Description = EntryDescripcion.Text,
            Year = int.Parse(EntryYear.Text),
            Price = decimal.Parse(EntryPrecio.Text),
            PhotoUrl = "https://static.wikia.nocookie.net/disney/images/6/6f/Profile_-_Maui.jpeg/revision/latest/thumbnail/width/360/height/360?cb=20190628013307"
        };

        await new RestService().Set("CarsForSalesApi", car);
        _ = await Navigation.PopAsync(true);
    }
}