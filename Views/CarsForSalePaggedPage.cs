using Microsoft.Maui.Controls.PlatformConfiguration.AndroidSpecific;

namespace AppDWCert.Views
{
    public class CarsForSalePaggedPage : Microsoft.Maui.Controls.TabbedPage
    {
        public CarsForSalePaggedPage()
        {
            Title = "Carros en venta";
            Children.Add(new CarsForSale());
            Children.Add(new AddCar());
            On<Microsoft.Maui.Controls.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
        }
    }
}
