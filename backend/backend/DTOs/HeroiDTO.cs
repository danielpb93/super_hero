using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DTOs
{
    public class HeroiCreateModel
    {
        public string Nome { get; set; }
        public string NomeHeroi { get; set; }
        public DateTime DataNascimento { get; set; }
        public double Altura { get; set; }
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
