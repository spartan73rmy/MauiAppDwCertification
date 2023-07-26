using System.Text;
using System.Text.Json;

namespace AppDWCert.Context
{
    public class RestService
    {
        HttpClient httpClient;
        Uri url;
        JsonSerializerOptions options;

        public RestService()
        {
            url = new("https://carshopweb20230725151115.azurewebsites.net/api/");
            httpClient = new()
            {
                BaseAddress = url
            };

            options = new()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }

        public async Task<List<T>> GetListAsync<T>(string url)
        {
            var response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<T>>(content, options);
            }

            throw new Exception("Error al tratar de pobtener la informacion");
        }

        public async Task Set<T>(string path, T item)
        {
            var payload = JsonSerializer.Serialize(item, options);
            var data = new StringContent(payload, encoding: Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(path, data);
            if (!response.IsSuccessStatusCode)
            { throw new Exception("Error, no se pudo enviar la informacion"); }
        }
    }
}
