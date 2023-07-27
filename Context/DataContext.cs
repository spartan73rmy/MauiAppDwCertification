using AppDWCert.Models;
using SQLite;

namespace AppDWCert.Context
{
    public class DataContext
    {
        SQLiteAsyncConnection connection;

        private async Task Init()
        {
            if (connection != null) return;

            connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, "AppDWCerDB.db3")
                , SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.SharedCache, storeDateTimeAsTicks: true);

            _ = await connection.CreateTableAsync<Car>();
        }

        public async Task<List<Car>> GetFavoriteCarsAsync()
        {
            await Init();
            return await connection.Table<Car>().ToListAsync();
        }

        public async Task<Car> GetCarByIdAsync(int id)
        {
            await Init();
            return await connection.Table<Car>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async ValueTask<bool> SetFavoriteAsync(Car car)
        {
            await Init();
            var current = await GetCarByIdAsync(car.Id);
            if (current is not null)
                return false;

            return await connection.InsertAsync(car) == 1;
        }

        public async ValueTask<bool> RemoveFavoriteAsync(int id)
        {
            await Init();
            var car = await GetCarByIdAsync(id);
            if (car is null)
                return false;

            return await connection.DeleteAsync(car) == 1;
        }
    }
}
