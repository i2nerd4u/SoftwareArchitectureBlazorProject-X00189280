namespace RickAndMortyAPI.Components.Data
{
    public class Episode
    {
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public string air_date { get; set; } = string.Empty;
        public string episode { get; set; } = string.Empty; // "S01E01"
        public List<string> characters { get; set; } = new();
    }

    public class EpisodeSearchResponse
    {
        public EpisodeInfo info { get; set; } = new();
        public List<Episode> results { get; set; } = new();
    }

    public class EpisodeInfo
    {
        public int count { get; set; }
        public int pages { get; set; }
        public string? next { get; set; }
        public string? prev { get; set; }
    }
}
