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
        public IEnumerable<Filme> BuscarFilmes()
        {
            return context.Filmes;
        }

        [HttpGet("{id}")]
        public IActionResult BuscarFilmePorId(int id)
        {
            var filme = context.Filmes.FirstOrDefault(filme => filme.Id == id);

            if (filme != null)
                return Ok(filme);

            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarFilme(int id, [FromBody] Filme filmeAtualizado)
        {
            var filme = context.Filmes.FirstOrDefault(filme => filme.Id == id);

            if (filme == null)
                return NotFound();

            filme.Titulo = filmeAtualizado.Titulo;
            filme.Diretor = filmeAtualizado.Diretor;
            filme.Genero = filmeAtualizado.Genero;
            filme.Duracao = filmeAtualizado.Duracao;

            context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult RemoverFilme(int id)
        {
            var filme = context.Filmes.FirstOrDefault(filme => filme.Id == id);

            if (filme == null)
                return NotFound();

            context.Remove(filme);
            context.SaveChanges();

            return NoContent();
        }
    }
}
