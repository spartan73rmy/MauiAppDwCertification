using Microsoft.Maui.Controls.PlatformConfiguration.AndroidSpecific;

namespace AppDWCert.Views
{
    public class MainPaggedPage : Microsoft.Maui.Controls.TabbedPage
    {
        public MainPaggedPage()
        {
            Children.Add(new CarsForSalePaggedPage());
            Children.Add(new FavoriteCars());

            On<Microsoft.Maui.Controls.PlatformConfiguration.Android>().SetIsSwipePagingEnabled(false);
        }
    }
}
