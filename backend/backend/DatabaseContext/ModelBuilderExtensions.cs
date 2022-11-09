using backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DatabaseContext
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Superpoder>().HasData(
                    new Superpoder { Id = 1, Nome = "Voar", Descricao = "Voa Alto" },
                    new Superpoder { Id = 2, Nome = "Super Força", Descricao = "Muito Forte" },
                    new Superpoder { Id = 3, Nome = "Super Velocidade", Descricao = "Muito Veloz" },
                    new Superpoder { Id = 4, Nome = "Super Inteligencia", Descricao = "Muita Inteligencia" },
                    new Superpoder { Id = 5, Nome = "Super Resistencia", Descricao = "Muito Resistente" },
                    new Superpoder { Id = 6, Nome = "Conversar com Peixes", Descricao = "XD" },
                    new Superpoder { Id = 7, Nome = "Soltar Laser dos Olhos", Descricao = "" },
                    new Superpoder { Id = 8, Nome = "Controlar Metal", Descricao = "Consegue controlar metal da forma que quiser" },
                    new Superpoder { Id = 9, Nome = "Telepatia", Descricao = "Telepatia" });
        }

    }
}
