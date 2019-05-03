using CinemaExpress.Web.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CinemaExpress.Web.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IRepository repository;

        public MoviesController(IRepository repository)
        {
            this.repository = repository;
        }

        // GET: Movies
        public IActionResult Index()
        {
            return View(this.repository.GetMovies());
        }

        // GET: Movies/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = this.repository.GetMovie(id.Value);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                this.repository.AddMovie(movie);
                await this.repository.SaveAllAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = this.repository.GetMovie(id.Value);
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
                    this.repository.UpdateMovie(movie);
                    await this.repository.SaveAllAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.repository.MovieExists(movie.Id))
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
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = this.repository.GetMovie(id.Value);                
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
            var movie = this.repository.GetMovie(id);
            this.repository.RemoveMovie(movie);
            await this.repository.SaveAllAsync();
            return RedirectToAction(nameof(Index));
        }
               
    }
}
