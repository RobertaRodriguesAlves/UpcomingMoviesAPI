using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UpcomingMovies.Application.Controllers;
using Xunit;

namespace UpcomingMovies.Service.Test
{
    public class UpcomingMoviesControllerTest
    {
        private readonly UpcomingMoviesController _controller;
        private readonly Mock<IMovieService> _serviceMock;

        public UpcomingMoviesControllerTest()
        {
            _serviceMock = new Mock<IMovieService>();
            _controller = new UpcomingMoviesController(_serviceMock.Object);
        }

        [Fact]
        public async Task WhenGetAllGetsCallGivenItReturnsAListOfMovies_ItShouldReturnOk()
        {
            List<MovieEntity> upcomingMoviesList = MakesAListOfUpcomingMovies();
            _serviceMock.Setup(service => service.GetUpcomingMovies()).ReturnsAsync(upcomingMoviesList);

            var result = await _controller.GetAll();
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult)result).Value as IEnumerable<MovieEntity>;
            Assert.True(resultValue.Count() == 2);
        }

        [Fact]
        public async Task WhenGetAllGetsCallGivenItReturnsANullObject_ItShouldReturnNotFound()
        {
            _serviceMock.Setup(service => service.GetUpcomingMovies()).ReturnsAsync((List<MovieEntity>)null);

            var result = await _controller.GetAll();
            Assert.True(result is NotFoundResult);
        }

        private static List<MovieEntity> MakesAListOfUpcomingMovies()
        {
            List<GenreEntity> genresList = new List<GenreEntity>
            {
                new GenreEntity{ Id = 35, Name = "Comedy" },
                new GenreEntity{ Id = 80, Name = "Crime" },
                new GenreEntity{ Id = 28, Name = "Action" },
                new GenreEntity{ Id = 53, Name = "Thriller" },
                new GenreEntity{ Id = 18, Name = "Drama" }
            };

            List<MovieEntity> upcomingMoviesList = new List<MovieEntity>
            {
                new MovieEntity{ Id = 337404, Title = "Cruella", ReleaseDate = new DateTime(2021, 05, 26), Genres = genresList },
                new MovieEntity{ Id = 399566, Title = "Godzilla vs. Kong", ReleaseDate = new DateTime(2021, 03, 24), Genres = genresList }
            };

            return upcomingMoviesList;
        }
    }
}
