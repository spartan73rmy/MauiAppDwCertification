using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDWCert.Views
{
    public class MainPaggedPage : TabbedPage
    {
        public MainPaggedPage()
        {
            Children.Add(new FavoriteCars());
            Children.Add(new CarsForSale());
            Children.Add(new AddCar());
        }
    }
}
