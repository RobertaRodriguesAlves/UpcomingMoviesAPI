using Domain.Entities;
using Domain.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using UpcomingMovies.Domain.Dtos;
using UpcomingMovies.Domain.Entities;
using System.Linq;

namespace UpcomingMovies.Service
{
    public class MovieService : IMovieService
    {
        public async Task<List<MovieEntity>> GetUpcomingMovies()
        {
            int count = 1;
            int totalPages = 0;
            List<MovieEntity> movieEntityList = new List<MovieEntity>();
            do
            {
                GenreService genreService = new GenreService();
                ResultEntity<MovieDto> upcomingMovies = await RequestUpcomingMovie(count);

                totalPages = upcomingMovies.TotalPages;
                await PopulateMovieEntity(movieEntityList, genreService, upcomingMovies);
                count++;

            } while (count <= totalPages);

            return movieEntityList;
        }

        private static async Task PopulateMovieEntity(List<MovieEntity> movieEntityList, GenreService genreService, ResultEntity<MovieDto> upcomingMovies)
        {
            foreach (var movie in upcomingMovies.Results)
            {
                var movieEntity = new MovieEntity
                {
                    Id = movie.Id,
                    ReleaseDate = movie.ReleaseDate,
                    Title = movie.Title
                };
                movieEntity.Genres.AddRange(movie.Genres.Select(genre => new GenreEntity() { Id = genre, Name = string.Empty }));
                movieEntityList.Add(movieEntity);
            }
            await genreService.GetGenreName(movieEntityList);
        }

        private static async Task<ResultEntity<MovieDto>> RequestUpcomingMovie(int count)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync($"https://api.themoviedb.org/3/movie/upcoming?api_key=0e7e7615ecb37f603d07cddaa0369f59&page={count}");
            string json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ResultEntity<MovieDto>>(json);
            return result;
        }
    }
}
