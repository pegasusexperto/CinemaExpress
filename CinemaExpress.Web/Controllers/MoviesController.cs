using CinemaExpress.Web.Data;
using CinemaExpress.Web.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class MoviesController : Controller
{
    private readonly IMovieRepository movieRepository;

    private readonly IUserHelper userHelper;

    public MoviesController(IMovieRepository movieRepository, IUserHelper userHelper)
    {
        this.movieRepository = movieRepository;
        this.userHelper = userHelper;
    }

    // GET: Movies
    public IActionResult Index()
    {
        return View(this.movieRepository.GetAll());
    }

    // GET: Movies/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var movie = await this.movieRepository.GetByIdAsync(id.Value);
        if (movie == null)
        {
            return NotFound();
        }

        return View(movie);
    }

    // GET: Movie/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Products/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Movie movie)
    {
        if (ModelState.IsValid)
        {
            // TODO: Pending to change to: this.User.Identity.Name
            movie.User = await this.userHelper.GetUserByEmailAsync("djkevinruiz@gmail.com");
            await this.movieRepository.CreateAsync(movie);
            return RedirectToAction(nameof(Index));
        }

        return View(movie);
    }

    // GET: Products/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var movie = await this.movieRepository.GetByIdAsync(id.Value);
        if (movie == null)
        {
            return NotFound();
        }

        return View(movie);
    }

    // POST: Movies/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Movie movie)
    {
        if (ModelState.IsValid)
        {
            try
            {
                // TODO: Pending to change to: this.User.Identity.Name
                movie.User = await this.userHelper.GetUserByEmailAsync("djkevinruiz@gmail.com");
                await this.movieRepository.UpdateAsync(movie);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await this.movieRepository.ExistAsync(movie.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }

        return View(movie);
    }

    // GET: Movies/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var movie = await this.movieRepository.GetByIdAsync(id.Value);
        if (movie == null)
        {
            return NotFound();
        }

        return View(movie);
    }

    // POST: Movies/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var movie = await this.movieRepository.GetByIdAsync(id);
        await this.movieRepository.DeleteAsync(movie);
        return RedirectToAction(nameof(Index));
    }
}


