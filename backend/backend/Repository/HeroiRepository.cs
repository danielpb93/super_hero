using backend.DatabaseContext;
using backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Repository
{
    public interface IHeroiRepository
    {
        IQueryable<Heroi> Get();
        Heroi GetById(int id);
        Heroi Insert(Heroi heroi);
        Heroi Update(Heroi heroi);
        Heroi Delete(int id);
    }

    public class HeroiRepository : IHeroiRepository
    {
        private readonly ApplicationDbContext _context;
        public HeroiRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<Heroi> Get() => _context.Herois.Include(h => h.Superpoderes).AsNoTracking();

        public Heroi Insert(Heroi heroi)
        {
            InsertHeroiSuperpoderes(heroi);
            _context.Add(heroi);
            _context.SaveChanges();
            return heroi;
        }

        public Heroi GetById(int id) => _context.Herois.Include(h => h.Superpoderes).AsNoTracking().SingleOrDefault(h => h.Id == id);

        public void InsertHeroiSuperpoderes(Heroi heroi)
        {
            List<Superpoder> heroiSuperpoderes = new List<Superpoder>();
            foreach (Superpoder superpoder in heroi.Superpoderes)
            {
                Superpoder superpoderFromDb = _context.Superpoderes.Find(superpoder.Id);
                if (superpoderFromDb == null) throw new ArgumentException("Superpoder não registrado no banco!");                
                heroiSuperpoderes.Add(superpoderFromDb);
            }

            heroi.Superpoderes = heroiSuperpoderes;
        }

        public Heroi Update(Heroi heroi)
        {
            Heroi heroiFromDb = _context.Herois.Include(h => h.Superpoderes).SingleOrDefault(h => h.Id == heroi.Id);
            if(heroiFromDb == null)
            {
                return null;
            }
            _context.Entry(heroiFromDb).CurrentValues.SetValues(heroi);
            UpdateHeroiSuperpoderes(heroi, heroiFromDb);
            _context.SaveChanges();
            return heroiFromDb;
        }

        public void UpdateHeroiSuperpoderes(Heroi novoHeroi, Heroi antigoHeroi)
        {
            antigoHeroi.Superpoderes.Clear();
            foreach (Superpoder superpoder in novoHeroi.Superpoderes)
            {
                Superpoder superpoderFromDb = _context.Superpoderes.Find(superpoder.Id);
                if (superpoderFromDb == null) throw new ArgumentException("Superpoder não registrado no banco!");
                antigoHeroi.Superpoderes.Add(superpoderFromDb);
            }
        }

        public Heroi Delete(int id)
        {
            Heroi heroiFromDb = _context.Herois.Find(id);
            if (heroiFromDb == null)
            {
                return null;
            }
            var heroiRemovido = _context.Herois.Remove(heroiFromDb);
            _context.SaveChanges();
            return heroiRemovido.Entity;
        }
    }
}
