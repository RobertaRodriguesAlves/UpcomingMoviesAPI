using Domain.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace UpcomingMovies.Domain.Dtos
{
    public class GenreDto
    {
        [JsonProperty("genres")]
        public List<GenreEntity> Genres { get; private set; }
    }
}
