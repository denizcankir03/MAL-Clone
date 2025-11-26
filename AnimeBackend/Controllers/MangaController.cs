using AnimeBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace AnimeBackend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MangaController : ControllerBase
{
    private readonly JikanService _jikanService;

    public MangaController(JikanService jikanService)
    {
        _jikanService = jikanService;
    }

    [HttpGet("search")]
    public async Task<IActionResult> SearchManga([FromQuery] string query)
    {
        if (string.IsNullOrWhiteSpace(query))
        {
            return BadRequest("Query parameter is required.");
        }
        var results = await _jikanService.SearchMangaAsync(query);
        return new JsonResult(results);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetMangaById(int id)
    {
        var manga = await _jikanService.GetMangaByIdAsync(id);
        if (manga == null)
        {
            return NotFound();
        }
        return new JsonResult(manga);
    }
}
