using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IMovieService
    {
        Task<List<MovieEntity>> GetUpcomingMovies();
    }
}
