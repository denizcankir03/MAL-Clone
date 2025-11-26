using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization; // Bunu eklemeyi unutma!

namespace AnimeShared
{
    public class jikanResponse<T>
    {
        public T Data { get; set; }
    }

    public class AnimeDTO
    {
        [JsonPropertyName("mal_id")] // API'den "mal_id" gelir, biz "MalId" kullanırız
        public int MalId { get; set; }

        public string Title { get; set; }

        [JsonPropertyName("title_english")]
        public string TitleEnglish { get; set; }

        [JsonPropertyName("title_japanese")]
        public string TitleJapanese { get; set; }

        public string Synopsis { get; set; }

        public string Type { get; set; }

        // --- DÜZELTME 1: Soru işaretleri eklendi ---
        public int? Episodes { get; set; } // int? yaptık (null gelebilir)
        public double? Score { get; set; } // double? yaptık (null gelebilir)

        public string Status { get; set; }

        public int? Members { get; set; }

        // --- DÜZELTME 2: Resim yapısı Jikan'a uygun hale getirildi ---
        public AnimeImages Images { get; set; }

        public List<AnimeGenre> Genres { get; set; }
        public List<AnimeStudio> Studios { get; set; }       // Stüdyolar (Örn: MAPPA)
        public List<AnimeDemographic> Demographics { get; set; } // Hedef Kitle (Örn: Shounen)

    }

    // Jikan yapısı: images -> jpg -> image_url
    public class AnimeImages
    {
        public JpgImage Jpg { get; set; }
    }

    public class JpgImage
    {
        [JsonPropertyName("image_url")]
        public string ImageUrl { get; set; }

        [JsonPropertyName("large_image_url")]
        public string LargeImageUrl { get; set; }
    }

    public class AnimeGenre
    {
        public string Name { get; set; }
    }
    public class AnimeStudio
    {
        public string Name { get; set; }
    }

    public class AnimeDemographic
    {
        public string Name { get; set; }
    }
}