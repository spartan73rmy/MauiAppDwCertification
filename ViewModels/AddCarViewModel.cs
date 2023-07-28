using AppDWCert.Context;
using AppDWCert.Models;
using AppDWCert.ViewModels.Base;
using System.Windows.Input;

namespace AppDWCert.ViewModels
{
    public class AddCarViewModel : BaseViewModel
    {
        public Car CarModel { get; set; }
        public AddCarViewModel(INavigation navigation) : base(navigation)
        {
            CarModel = new Car();
        }

        //Comandos
        public ICommand TakePhotoCommand => new Command(async () => await TakePhotoAsync());
        public ICommand AddCarCommand => new Command(async () => await AddCarAsync());

        private async Task TakePhotoAsync()
        {
            var photo = await MediaPicker.Default.CapturePhotoAsync(new MediaPickerOptions());
            CarModel.PhotoUrl = photo.FullPath;

            var photoStream = await photo.OpenReadAsync();
        }

        private async Task AddCarAsync()
        {
            var location = await Geolocation.Default.GetLocationAsync();
            await Navigation.PopAsync();

            PermissionStatus status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
            if (status == PermissionStatus.Denied)
            {
                //await DisplayAlert("Permiso", "La aplicacion requiere la ubicacion para guardar el carro", "Ok");
                return;
            }

            if (location is null)
                return;

            CarModel.Lat = location.Latitude;
            CarModel.Lon = location.Longitude;
            CarModel.PhotoUrl = "https://static.wikia.nocookie.net/disney/images/6/6f/Profile_-_Maui.jpeg/revision/latest/thumbnail/width/360/height/360?cb=20190628013307";

            await new RestService().Set("CarsForSalesApi", CarModel);
            _ = await Navigation.PopAsync(true);
        }
    }
}
