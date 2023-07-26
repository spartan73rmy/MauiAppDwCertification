using AppDWCert.Context;
using AppDWCert.Models;

namespace AppDWCert.Views;

public partial class CarsForSale : ContentPage
{
    public CarsForSale()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        await LoadList();
        base.OnAppearing();
    }

    private async Task LoadList()
    {
        CarList.ItemsSource = await new RestService().GetListAsync<Car>("CarsForSalesApi");
    }

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddCar());
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        var favoriteResult = await new DataContext().SetFavoriteAsync((Car)((Button)sender).BindingContext);

        await DisplayAlert("Auto favorito", favoriteResult ? "Auto agregado correctamente" : "El auto ya se encuentra en favoritos", "Ok");
    }
}