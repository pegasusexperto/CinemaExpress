using CinemaExpress.Web.Data;

public class MovieRepository : GenericRepository<Movie>, IMovieRepository
{
    public MovieRepository(DataContext context) : base(context)
    {
    }
}

