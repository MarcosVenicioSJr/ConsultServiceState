using ConsultServiceState.Entities.Interfaces;

namespace ConsultServiceState.Services.Http
{
    public class ConsultState : IConsultServiceState
    {
        private readonly HttpClient _httpClient;

        public ConsultState(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(_httpClient));
        }

        public async Task<bool> GetAsync(string url)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
                return true;
            else
                return false;
        }
    }
}
