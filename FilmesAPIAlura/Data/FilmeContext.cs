using FilmesAPIAlura.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPIAlura.Data
{
    public class FilmeContext : DbContext
    {
        public FilmeContext()
        {

        }

        public FilmeContext(DbContextOptions<FilmeContext> options)
            : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public DbSet<Filme> Filmes { get; set; }
    }
}
