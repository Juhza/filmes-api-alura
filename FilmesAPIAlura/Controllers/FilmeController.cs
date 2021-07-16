using AutoMapper;
using FilmesAPIAlura.Data;
using FilmesAPIAlura.Data.DTOs;
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
        private readonly IMapper mapper;

        public FilmeController(FilmeContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionarFilme([FromBody] CreateFilmeDTO filmeDTO)
        {
            var filme = mapper.Map<Filme>(filmeDTO);

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

            if (filme == null)
                return NotFound();

            var filmeDTO = mapper.Map<ReadFilmeDTO>(filme);

            return Ok(filmeDTO);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarFilme(int id, [FromBody] UpdateFilmeDTO filmeDTO)
        {
            var filme = context.Filmes.FirstOrDefault(filme => filme.Id == id);

            if (filme == null)
                return NotFound();

            mapper.Map(filmeDTO, filme);
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
