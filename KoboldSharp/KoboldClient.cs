using System.Text;
using System.Text.Json;

namespace KoboldSharp
{
    public class KoboldClient
    {
        private readonly HttpClient _client;
        private readonly string _baseUri;

        public KoboldClient(string baseUri)
        {
            _client = new HttpClient()
            {
                Timeout = TimeSpan.FromMinutes(5)
            };
            _baseUri = baseUri;
        }

        public KoboldClient(string baseUri, HttpClient client)
        {
            _client = client;
            _baseUri = baseUri;
        }

        public async Task<ModelOutput> Generate(GenParams parameters)
        {
            var payload = new StringContent(parameters.GetJson(), Encoding.UTF8, "application/json");
            var response = await _client.PostAsync($"{_baseUri}/api/v1/generate", payload);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            content = content.Trim();
            return JsonSerializer.Deserialize<ModelOutput>(content);
            
        }
    }
}
