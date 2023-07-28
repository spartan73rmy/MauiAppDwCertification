using AppDWCert.ViewModels;

namespace AppDWCert.Views;

public partial class AddCar : ContentPage
{
    public AddCar()
    {
        InitializeComponent();
        BindingContext = new AddCarViewModel(Navigation);
    }
}