using System.Text.Json.Serialization;

namespace AnimeShared;

public class MangaDTO
{
    [JsonPropertyName("mal_id")]
    public int MalId { get; set; }

    public string Title { get; set; }

    [JsonPropertyName("title_english")]
    public string TitleEnglish { get; set; }

    public string Synopsis { get; set; }

    public string Type { get; set; } // Manga, Novel, Manhwa vb.

    public int? Chapters { get; set; } // Bölüm sayısı
    public int? Volumes { get; set; }  // Cilt sayısı

    public double? Score { get; set; }

    public string Status { get; set; } // Publishing, Finished vb.

    public int? Members { get; set; }

    public AnimeImages Images { get; set; } // AnimeImages sınıfını ortak kullanıyoruz

    public List<AnimeGenre> Genres { get; set; } // AnimeGenre sınıfını ortak kullanıyoruz

    // --- MANGA'YA ÖZEL KISIM ---
    public List<MangaAuthor> Authors { get; set; } // Yazarlar (Örn: Oda, Eiichiro)
    public List<AnimeDemographic> Demographics { get; set; }
}

public class MangaAuthor
{
    public string Name { get; set; }
}