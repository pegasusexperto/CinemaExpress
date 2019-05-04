using CinemaExpress.Web.Data;
using CinemaExpress.Web.Data.Entities;

public class CountryRepository : GenericRepository<Country>, ICountryRepository
{
    public CountryRepository(DataContext context) : base(context)
    {
    }
}
