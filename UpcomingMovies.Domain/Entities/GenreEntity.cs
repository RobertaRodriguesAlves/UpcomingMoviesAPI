using Newtonsoft.Json;

namespace Domain.Entities
{
    public class GenreEntity
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
