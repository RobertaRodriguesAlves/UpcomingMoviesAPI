using Domain.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using UpcomingMovies.Domain.Dtos;
using UpcomingMovies.Domain.Interfaces;

namespace UpcomingMovies.Service
{
    public class GenreService : IGenreService
    {
        public async Task<List<MovieEntity>> GetGenreName(List<MovieEntity> movieEntityList)
        {
            GenreDto result = await RequestGenre();

            foreach (var (genre, genreItem) in from movie in movieEntityList
                                               from genre in movie.Genres
                                               let list = result.Genres.Where(a => a.Id == genre.Id)
                                               from genreItem in list
                                               select (genre, genreItem))
            {
                genre.Name = genreItem.Name;
            }

            return movieEntityList;
        }

        private static async Task<GenreDto> RequestGenre()
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync("https://api.themoviedb.org/3/genre/movie/list?api_key=0e7e7615ecb37f603d07cddaa0369f59");
            string json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<GenreDto>(json);
            return result;
        }
    }
}
