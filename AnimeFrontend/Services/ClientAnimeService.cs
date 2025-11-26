using AnimeShared;
using System.Net.Http.Json;

namespace AnimeFrontend.Services;

public class ClientAnimeService
{
    private readonly HttpClient _httpClient;

    public ClientAnimeService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<AnimeDTO>> SearchAnime(string query)
    {
        var response = await _httpClient.GetFromJsonAsync<List<AnimeDTO>>($"/api/anime/search?query={Uri.EscapeDataString(query)}");
        return response ?? new List<AnimeDTO>();
    }
    public async Task<List<MangaDTO>> SearchManga(string query)
    {
        var response = await _httpClient.GetFromJsonAsync<List<MangaDTO>>($"/api/manga/search?query={Uri.EscapeDataString(query)}");
        return response ?? new List<MangaDTO>();
    }
    // ID'ye göre tek bir anime getir
    public async Task<AnimeDTO> GetAnimeById(int id)
    {
        // Backend: api/anime/542
        return await _httpClient.GetFromJsonAsync<AnimeDTO>($"api/anime/{id}");
    }
}
