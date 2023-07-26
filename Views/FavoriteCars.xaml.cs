using AppDWCert.Context;

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

}