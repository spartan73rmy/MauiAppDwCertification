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
}