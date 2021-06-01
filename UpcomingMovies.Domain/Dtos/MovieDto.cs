using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace UpcomingMovies.Domain.Dtos
{
    public class MovieDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("release_date")]
        public DateTime? ReleaseDate { get; set; }

        [JsonProperty("genre_ids")]
        public List<int> Genres { get; set; }
    }
}
