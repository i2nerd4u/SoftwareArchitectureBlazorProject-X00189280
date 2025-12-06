namespace RickAndMortyAPI.Components.Data
{
    public class Character
    {
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public string status { get; set; } = string.Empty;
        public string species { get; set; } = string.Empty;
        public string image { get; set; } = string.Empty;
    }

    public class CharactersSearchResponse
    {
        public CharacterInfo info { get; set; } = new();
        public List<Character> results { get; set; } = new();
    }

    public class CharacterInfo
    {
        public int count { get; set; }
        public int pages { get; set; }
        public string? next { get; set; }
        public string? prev { get; set; }
    }
}
