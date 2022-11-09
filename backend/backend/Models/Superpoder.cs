using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class Superpoder
    {
        public int Id { get; set; }
        [Column("Superpoder")]
        [Required]
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public List<Heroi> Herois { get; set; }
    }
}
