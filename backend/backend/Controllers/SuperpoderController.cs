using backend.DTOs;
using backend.Models;
using backend.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperpoderController : ControllerBase
    {
        private readonly ISuperpoderRepository _superpoderRepo;

        public SuperpoderController(ISuperpoderRepository superpoderRepo)
        {
            _superpoderRepo = superpoderRepo;
        }

        /// <summary>   
        /// Listar todos os super poderes disponiveis
        /// </summary>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<SuperpoderViewModel> superpoderes = _superpoderRepo.Get().Select(sp => new SuperpoderViewModel
                {
                    Id = sp.Id,
                    Nome = sp.Nome,
                    Descricao = sp.Descricao
                }).ToList();
                return Ok(superpoderes);
            }
            catch(Exception e)
            {
                return StatusCode(500, e.InnerException?.Message ?? e.Message);
            }
        }
    }
}
