using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class MovieEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public List<GenreEntity> Genres { get; set; } = new List<GenreEntity>();
    }
}
