using AppDWCert.ViewModels;

namespace AppDWCert.Views;

public partial class CarsForSale : ContentPage
{
    public CarsForSale()
    {
        InitializeComponent();
        BindingContext = new CarsForSaleViewModel(Navigation);
    }
}