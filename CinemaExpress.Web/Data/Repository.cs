using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaExpress.Web.Data
{
    public class Repository : IRepository
    {
        private readonly DataContext context;

        public Repository(DataContext context)
        {
            this.context = context;
        }

        public IEnumerable<Movie> GetMovies()
        {
            return this.context.Movies.OrderBy(m => m.Título);
        }

        public Movie GetMovie(int id)
        {
            return this.context.Movies.Find(id);
        }

        public void AddMovie(Movie movie)
        {
            this.context.Movies.Add(movie);
        }

        public void UpdateMovie(Movie movie)
        {
            this.context.Movies.Update(movie);
        }

        public void RemoveMovie(Movie movie)
        {
            this.context.Movies.Remove(movie);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await this.context.SaveChangesAsync() > 0;
        }

        public bool MovieExists(int id)
        {
            return this.context.Movies.Any(p => p.Id == id);
        }

    }
}
