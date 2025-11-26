using AnimeBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace AnimeBackend.Controllers;

[Route("api/[controller]")]
[ApiController]

public class AnimeController
    {
    private readonly JikanService _jikanService;

    public AnimeController(JikanService jikanService)
    {
        _jikanService = jikanService;
    }

    [HttpGet("search")]
    public async Task<IActionResult> SearchAnime([FromQuery] string query)
    {
        var results = await _jikanService.SearchAnimeAsync(query);
        return new JsonResult(results);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAnimeById(int id)
    {
        var anime = await _jikanService.GetAnimeByIdAsync(id);
        if (anime == null)
        {
            return new NotFoundResult();
        }
        return new JsonResult(anime);
    }
}

