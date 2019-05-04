using CinemaExpress.Web.Data;
using Microsoft.AspNetCore.Mvc;

namespace CinemaExpress.Web.Controllers.API
{
    [Route("api/[Controller]")]
    public class MoviesController : Controller
    {
        private readonly IMovieRepository movieRepository;

        public MoviesController(IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
        }

        [HttpGet]
        public IActionResult GetMovies()
        {
            return Ok(this.movieRepository.GetAll());

        }

    }
}

