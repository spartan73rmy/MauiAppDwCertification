using AppDWCert.Models;
using Java.Net;
using System.Text;
using System.Text.Json;

namespace AppDWCert.Context
{
    public class RestService
    {
        HttpClient httpClient;
        Uri url;

        public RestService()
        {
            url = new("URL_BASE");
            httpClient = new()
            {
                BaseAddress = url
            };
        }

        public async Task<List<T>> GetList<T>(string url)
        {
            var response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<T>>(content);
            }

            throw new Exception("Error al tratar de pobtener la informacion");
        }

        public async Task Set<T>(string path, T item)
        {
            var payload = JsonSerializer.Serialize(item);
            var data = new StringContent(payload, encoding: Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(url, data);
            if (!response.IsSuccessStatusCode)
            { throw new Exception("Error, no se pudo enviar la informacion"); }
        }
    }
}
