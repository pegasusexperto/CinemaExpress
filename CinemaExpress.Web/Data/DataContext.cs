namespace CinemaExpress.Web.Data
{
    using Microsoft.EntityFrameworkCore;

    public class DataContext : DbContext
    {

        public DbSet<Movie> Movies { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

    }
}
