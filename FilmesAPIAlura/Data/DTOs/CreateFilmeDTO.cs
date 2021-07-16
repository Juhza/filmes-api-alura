using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPIAlura.Data.DTOs
{
    public class CreateFilmeDTO
    {
        [Required(ErrorMessage = "O campo Título é obrigatório.")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O campo Diretor é obrigatório.")]
        public string Diretor { get; set; }

        [Required(ErrorMessage = "O campo Gênero é obrigatório.")]
        [StringLength(30, ErrorMessage = "O gênero deve ter no máximo 30 caracteres.")]
        public string Genero { get; set; }

        [Required(ErrorMessage = "O campo Duração é obrigatório.")]
        [Range(1, 300, ErrorMessage = "A duração deve ter no mínimo 1 e no máximo 300 minutos.")]
        public int Duracao { get; set; }
    }
}
