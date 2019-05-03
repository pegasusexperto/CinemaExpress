using CinemaExpress.Web.Data;
using CinemaExpress.Web.Data.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;

public class SeedDb
{
    private readonly DataContext context;
    private readonly UserManager<User> userManager;
    private Random random;

    public SeedDb(DataContext context, UserManager<User> userManager)
    {
        this.context = context;
        this.userManager = userManager;
        this.random = new Random();
    }

    public async Task SeedAsync()
    {
        await this.context.Database.EnsureCreatedAsync();

        var user = await this.userManager.FindByEmailAsync("djkevinruiz@gmail.com");
        if (user == null)
        {
            user = new User
            {
                Nombre = "Kevin",
                Apellidos = "Ruiz",
                Email = "djkevinruiz@gmail.com",
                UserName = "kruizf201",
                PhoneNumber = "8550-4584"
            };

            var result = await this.userManager.CreateAsync(user, "IT.entrycontrol.456");
            if (result != IdentityResult.Success)
            {
                throw new InvalidOperationException("Could not create the user in seeder");
            }
        }

        if (!this.context.Movies.Any())
        {
            this.AddMovie("Avengers Endgame", user);
            this.AddMovie("La Llorona", user);
            this.AddMovie("Dumbo", user);
            await this.context.SaveChangesAsync();
        }
    }

    private void AddMovie(string name, User user)
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
            User = user,
        });
    }
}
