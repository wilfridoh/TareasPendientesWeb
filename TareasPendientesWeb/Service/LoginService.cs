using System.Net.Http.Headers;

namespace TareasPendientesWeb.Service
{
    public class LoginService
    {
        private readonly HttpClient _client;
        public LoginService(HttpClient client)
        {
            _client = client;
            _client.BaseAddress = new System.Uri("http://localhost:54684/api/login/authenticate/");
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<string> AuthenticateUserAsync(string username, string password)
        {
            var requestBody = new
            {
                Username = username,
                Password = password
            };
            var response = await _client.PostAsJsonAsync("", requestBody);
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var token = responseContent.ToString();
                return token;
            }
            return null;
        }
    }
}
