using AppDWCert.Views;

namespace AppDWCert;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new MainPaggedPage();
    }
}
