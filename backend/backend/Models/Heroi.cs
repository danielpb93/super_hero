using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class Heroi
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string NomeHeroi { get; set; }
        [Required]
        public DateTime DataNascimento { get; set; }
        [Required]
        public double Altura { get; set; }
        [Required]
        public double Peso { get; set; }
        public List<Superpoder> Superpoderes { get; set; }
    }
}
