using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemaExpress.Web.Data
{
    public interface IRepository
    {
        void AddMovie(Movie movie);
        Movie GetMovie(int id);
        IEnumerable<Movie> GetMovies();
        bool MovieExists(int id);
        void RemoveMovie(Movie movie);
        Task<bool> SaveAllAsync();
        void UpdateMovie(Movie movie);
    }
}