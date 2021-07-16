using FilmesAPIAlura.Data;
using FilmesAPIAlura.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPIAlura.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private readonly FilmeContext context;

        public FilmeController(FilmeContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public IActionResult AdicionarFilme([FromBody] Filme filme)
        {
            context.Filmes.Add(filme);
            context.SaveChanges();

            return CreatedAtAction(nameof(BuscarFilmePorId), new { filme.Id }, filme);
        }

        [HttpGet]
        public IActionResult BuscarFilmes()
        {
            return Ok(context.Filmes);
        }

        [HttpGet("{id}")]
        public IActionResult BuscarFilmePorId(int id)
        {
            var filme = context.Filmes.FirstOrDefault(filme => filme.Id == id);

            if (filme != null)
                return Ok(filme);

            return NotFound();
        }
    }
}
