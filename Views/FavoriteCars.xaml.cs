using AppDWCert.Context;
using AppDWCert.Models;

namespace AppDWCert.Views;

public partial class FavoriteCars : ContentPage
{
    public FavoriteCars()
    {
        InitializeComponent();
    }

    private async Task LoadData()
    {
        CarList.ItemsSource = await new DataContext().GetFavoriteCarsAsync();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await LoadData();
    }

    private async void btnBorrar_Invoked(object sender, EventArgs e)
    {
        var car = (Car)((SwipeItem)sender).BindingContext;
        var result = await new DataContext().RemoveFavoriteAsync(car.Id);

        if (result)
            await LoadData();

    }
}