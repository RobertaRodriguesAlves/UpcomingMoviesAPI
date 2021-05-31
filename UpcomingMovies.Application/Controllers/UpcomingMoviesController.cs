using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace UpcomingMovies.Application.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UpcomingMoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;
        public UpcomingMoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var result = await _movieService.GetUpcomingMovies();
                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
