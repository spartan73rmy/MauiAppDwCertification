using AppDWCert.ViewModels;

namespace AppDWCert.Views;

public partial class AddCar : ContentPage
{
    public AddCar()
    {
        InitializeComponent();
        BindingContext = new AddCarViewModel(Navigation);
    }

    private void Button_Clicked(object sender, SkiaSharp.Views.Maui.SKTouchEventArgs e)
    {

    }
}