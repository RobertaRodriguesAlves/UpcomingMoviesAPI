using Newtonsoft.Json;
using System.Collections.Generic;

namespace UpcomingMovies.Domain.Entities
{
    public class ResultEntity<T>
    {
        [JsonProperty("results")]
        public List<T> Results { get; private set; }

        [JsonProperty("total_pages")]
        public int TotalPages { get; private set; }
    }
}
