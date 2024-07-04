using System.Net.Http.Headers;
using TareasPendientesWeb.Models;

namespace TareasPendientesWeb.Service
{
    public class TareasPendientesService
    {
        private readonly HttpClient _client;
        public TareasPendientesService(HttpClient client)
        {
            _client = client;
            _client.BaseAddress = new System.Uri("http://localhost:54684/api/TareasPendientes/");
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IEnumerable<TareasPendientes>> GetTareasPendientesAsync()
        {
            var response = await _client.GetAsync("");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<IEnumerable<TareasPendientes>>();
            }
            return null;
        }

        public async Task<TareasPendientes> GetTareaPendienteAsync(int id)
        {
            var response = await _client.GetAsync($"{id}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<TareasPendientes>();
            }
            return null;
        }

        public async Task<bool> CreateTareaPendienteAsync(TareasPendientes tareasPendientes)
        {
            var response = await _client.PostAsJsonAsync("", tareasPendientes);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateTareasPendientesAsync(int id, TareasPendientes tareasPendientes)
        {
            var response = await _client.PutAsJsonAsync($"{id}", tareasPendientes);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteTareasPendientesAsync(int id)
        {
            var response = await _client.DeleteAsync($"{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
