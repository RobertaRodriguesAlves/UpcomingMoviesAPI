using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UpcomingMovies.Domain.Interfaces
{
    public interface IGenreService
    {
        Task<List<MovieEntity>> GetGenreName(List<MovieEntity> movieEntityList);
    }
}
