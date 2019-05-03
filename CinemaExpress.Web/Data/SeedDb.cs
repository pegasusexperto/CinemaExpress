using CinemaExpress.Web.Data;
using System;
using System.Linq;
using System.Threading.Tasks;

public class SeedDb
{
    private readonly DataContext context;
    private Random random;

    public SeedDb(DataContext context)
    {
        this.context = context;
        this.random = new Random();
    }

    public async Task SeedAsync()
    {
        await this.context.Database.EnsureCreatedAsync();

        if (!this.context.Movies.Any())
        {
            this.AddMovie("Avengers Endgame");
            this.AddMovie("La Llorona");
            this.AddMovie("Dumbo");
            await this.context.SaveChangesAsync();
        }
    }

    private void AddMovie(string name)
    {
        this.context.Movies.Add(new Movie
        {
            ImageUrl = "Null",
            Título = name,
            TítuloOriginal = name,
            VideoUrl = "Null",
            TrailerUrl = "Null",
            Precio = this.random.Next(100),
            Año = "2019",
            Calidad = "Baja",
            Géneros = "Initial",
            Idioma = "Latino",
            Sinópsis = "Dolor sit attem",
            Reparto = "Null",
            IsAvailabe = true,            
        });
    }
}
