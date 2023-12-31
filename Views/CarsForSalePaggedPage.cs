﻿using Microsoft.Maui.Controls.PlatformConfiguration.AndroidSpecific;

namespace AppDWCert.Views
{
    public class CarsForSalePaggedPage : Microsoft.Maui.Controls.TabbedPage
    {
        public CarsForSalePaggedPage()
        {
            Title = "Carros en la Zona";
            Children.Add(new CarsForSale());
            Children.Add(new MapCars());
            On<Microsoft.Maui.Controls.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
            On<Microsoft.Maui.Controls.PlatformConfiguration.Android>().SetIsSwipePagingEnabled(false);
        }
    }
}
