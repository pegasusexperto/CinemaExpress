using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaExpress.Web.Data.Entities
{
    public class User : IdentityUser
    {
        public string Nombre { get; set; }

        public string Apellidos { get; set; }

    }
}
