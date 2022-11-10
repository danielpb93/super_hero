using backend.DTOs;
using backend.Models;
using backend.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroiController : ControllerBase
    {
        private readonly IHeroiRepository _heroiRepo;
        public HeroiController(IHeroiRepository heroiRepo)
        {
            _heroiRepo = heroiRepo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Heroi> heroes = _heroiRepo.Get().ToList();
            List<HeroiViewModel> heroView = heroes.Select(heroi => new HeroiViewModel
            {
                Id = heroi.Id,
                Nome = heroi.Nome,
                NomeHeroi = heroi.NomeHeroi,
                DataNascimento = heroi.DataNascimento.Date,
                Altura = heroi.Altura,
                Peso = heroi.Peso,
                Superpoderes = heroi.Superpoderes.Select(x => new SuperpoderViewModel { Id = x.Id, Nome = x.Nome, Descricao = x.Descricao }).ToList()
            }).ToList();
            return Ok(heroView);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Heroi heroi = _heroiRepo.GetById(id);
            if(heroi == null)
            {
                return NotFound("heroi não existe");
            }
            HeroiViewModel heroView = new HeroiViewModel
            {
                Id = heroi.Id,
                Nome = heroi.Nome,
                NomeHeroi = heroi.NomeHeroi,
                DataNascimento = heroi.DataNascimento.Date,
                Altura = heroi.Altura,
                Peso = heroi.Peso,
                Superpoderes = heroi.Superpoderes.Select(x => new SuperpoderViewModel { Id = x.Id, Nome = x.Nome, Descricao = x.Descricao }).ToList()
            };
            return Ok(heroView);
        }

        [HttpPost]
        public IActionResult Post(HeroiCreateModel heroiDto)
        {
            try
            {
                Heroi heroToBeInserted = new Heroi
                {
                    Nome = heroiDto.Nome,
                    NomeHeroi = heroiDto.NomeHeroi,
                    DataNascimento = heroiDto.DataNascimento.Date,
                    Altura = heroiDto.Altura,
                    Peso = heroiDto.Peso,
                    Superpoderes = heroiDto.Superpoderes.Select(x => new Superpoder { Id = x }).ToList()
                };
                Heroi heroInserted = _heroiRepo.Insert(heroToBeInserted);
                HeroiViewModel heroView = new HeroiViewModel
                {
                    Id = heroInserted.Id,
                    Nome = heroInserted.Nome,
                    NomeHeroi = heroInserted.NomeHeroi,
                    DataNascimento = heroInserted.DataNascimento.Date,
                    Altura = heroInserted.Altura,
                    Peso = heroInserted.Peso,
                    Superpoderes = heroInserted.Superpoderes.Select(x => new SuperpoderViewModel { Id = x.Id, Nome = x.Nome, Descricao = x.Descricao }).ToList()
                };
                return CreatedAtAction(nameof(Get), new { id = heroView.Id }, heroView);
            }
            catch(Exception e)
            {
                return StatusCode(500, e.InnerException?.Message ?? e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, HeroiCreateModel heroiDto)
        {
            try
            {
                Heroi heroToBeUpdated = new Heroi
                {
                    Id = id,
                    Nome = heroiDto.Nome,
                    NomeHeroi = heroiDto.NomeHeroi,
                    DataNascimento = heroiDto.DataNascimento.Date,
                    Altura = heroiDto.Altura,
                    Peso = heroiDto.Peso,
                    Superpoderes = heroiDto.Superpoderes.Select(x => new Superpoder { Id = x }).ToList()
                };
                Heroi heroUpdated = _heroiRepo.Update(heroToBeUpdated);
                if (heroUpdated == null)
                {
                    return NotFound("Heroi não existe");
                }
                HeroiViewModel heroView = new HeroiViewModel
                {
                    Id = heroUpdated.Id,
                    Nome = heroUpdated.Nome,
                    NomeHeroi = heroUpdated.NomeHeroi,
                    DataNascimento = heroUpdated.DataNascimento.Date,
                    Altura = heroUpdated.Altura,
                    Peso = heroUpdated.Peso,
                    Superpoderes = heroUpdated.Superpoderes.Select(x => new SuperpoderViewModel { Id = x.Id, Nome = x.Nome, Descricao = x.Descricao }).ToList()
                };
                return Ok(heroView);
            }catch(Exception e)
            {
                return StatusCode(500, e.InnerException?.Message ?? e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Heroi hero = _heroiRepo.Delete(id);
            if(hero == null)
            {
                return NotFound("Heroi não existe");
            }
            return NoContent();
        }
    }
}
