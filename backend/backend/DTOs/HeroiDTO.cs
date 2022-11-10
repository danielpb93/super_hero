using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DTOs
{
    public class HeroiCreateModel
    {
        [Required(ErrorMessage ="Nome é obrigatorio!")]
        [MinLength(1,ErrorMessage ="Nome está vazio!")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Nome de heroi é obrigatorio!")]
        [MinLength(1, ErrorMessage = "Nome de heroi está vazio!")]
        public string NomeHeroi { get; set; }
        [Required(ErrorMessage = "Data de nascimento é obrigatoria!")]
        public DateTime DataNascimento { get; set; }
        [Range(0.1, 100, ErrorMessage ="{0} deve ser entre {1} e {2}")]
        public double Altura { get; set; }
        [Range(1, 1000, ErrorMessage ="{0} deve ser entre {1} e {2}")]
        public double Peso { get; set; }
        public List<int> Superpoderes { get; set; }
    }

    public class HeroiViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string NomeHeroi { get; set; }
        public DateTime DataNascimento { get; set; }
        public double Altura { get; set; }
        public double Peso { get; set; }
        public List<SuperpoderViewModel> Superpoderes { get; set; }
    }
}
