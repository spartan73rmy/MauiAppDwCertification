using AppDWCert.Context;
using AppDWCert.Messages;
using AppDWCert.Models;
using AppDWCert.ViewModels.Base;
using AppDWCert.Views;
using CommunityToolkit.Mvvm.Messaging;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace AppDWCert.ViewModels
{
    public class CarsForSaleViewModel : BaseViewModel
    {
        private bool isBusy;
        public bool IsBusy
        {
            get => isBusy;
            set => SetProperty(ref isBusy, value);
        }


        ObservableCollection<Car> _carList;
        public ObservableCollection<Car> CarsList
        {
            get => _carList;
            set => SetProperty(ref _carList, value);
        }

        public ICommand RefreshCommand => new Command(async x => await LoadCarsAsync());
        public ICommand SetFavoriteCommand => new Command(async (car) => await SetFavoriteAsync(car));
        public ICommand AddCarCommand => new Command(async () => await Navigation.PushAsync(new AddCar()));

        public CarsForSaleViewModel(INavigation navigation) : base(navigation)
        {
            if (!WeakReferenceMessenger.Default.IsRegistered<RefreshCarList>(""))
                WeakReferenceMessenger.Default.Register<RefreshCarList>("", async (o, s) => await LoadCarsAsync());
            _ = LoadCarsAsync();
        }

        private async Task LoadCarsAsync()
        {
            IsBusy = true;
            CarsList = new ObservableCollection<Car>(await new RestService().GetListAsync<Car>("CarsForSalesApi"));
            IsBusy = false;
        }

        private async Task SetFavoriteAsync(object obj)
        {
            if (IsBusy)
                return;

            IsBusy = true;
            if (obj is Material.Components.Maui.Button carButton)
            {
                if (carButton.BindingContext is Car car)
                {
                    await new DataContext().SetFavoriteAsync(car);
                    await Application.Current.MainPage.DisplayAlert("Se guardo el carro en favorito", "Favorito", "Ok");
                }
            }

            IsBusy = false;
        }
    }
}
