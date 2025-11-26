using AnimeShared;
using System.Text.Json;
using System.Net.Http;
using System.Threading.Tasks;


namespace AnimeBackend.Services
{
    public class JikanService
    {
        private readonly HttpClient _httpClient;
        public JikanService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://api.jikan.moe/v4/");
        }
        public async Task<List<AnimeDTO>> SearchAnimeAsync(string query)
        {
            var response = await _httpClient.GetAsync($"anime?q={query}");

            if (response.IsSuccessStatusCode)
            {
                var jsonContent = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var result = JsonSerializer.Deserialize<jikanResponse<List<AnimeDTO>>>(jsonContent, options);
                return result?.Data ?? new List<AnimeDTO>();
            }
            return new List<AnimeDTO>();
        }
        public async Task<AnimeDTO?> GetAnimeByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"anime/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonContent = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var result = JsonSerializer.Deserialize<jikanResponse<AnimeDTO>>(jsonContent, options);
                return result?.Data;
            }
            return null;
        }
        public async Task<List<MangaDTO>> SearchMangaAsync(string query)
        {
            var response = await _httpClient.GetAsync($"manga?q={query}");
            if (response.IsSuccessStatusCode)
            {
                var jsonContent = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var result = JsonSerializer.Deserialize<jikanResponse<List<MangaDTO>>>(jsonContent, options);
                return result?.Data ?? new List<MangaDTO>();
            }
            return new List<MangaDTO>();
        }
        public async Task<MangaDTO?> GetMangaByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"manga/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonContent = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var result = JsonSerializer.Deserialize<jikanResponse<MangaDTO>>(jsonContent, options);
                return result?.Data;
            }
            return null;
        }
    }
}
