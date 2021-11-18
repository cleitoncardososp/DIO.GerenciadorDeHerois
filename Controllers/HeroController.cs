using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DIO.Marvel.Database;
using DIO.Marvel.Dto;
using DIO.Marvel.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DIO.Marvel.Controllers
{
    [ApiController]
    [Route("api/v1/heroes")]
    public class HeroController : ControllerBase 
    {
        private DataContext _context;

        public HeroController(DataContext context)
        {
            _context = context;
        }

        //GET ALL
        [HttpGet]
        public List<Hero> List()
        {
            var heroes = _context.heroes.ToList();
            return heroes;
        }

        //GET BY ID
        [HttpGet("{id}")]
        public Hero GetById(int id)
        {
            var result = _context.heroes.FirstOrDefault(h => h.Id == id);

            return result;
        }

        //CREATE
        [HttpPost]
        public Hero Create(CreateHero hero)
        {
            var newHero = new Hero(hero);

            _context.heroes.Add(newHero);
            _context.SaveChanges();

            return newHero;
        }

        //DELETE
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            var heroToRemove = _context.heroes.FirstOrDefault(h => h.Id == id);

            if(heroToRemove != null)
            {
                _context.Remove(heroToRemove);
                _context.SaveChanges();

                return true;
            }else
                {
                    return false;
                }
        }

        //UPDATE
        [HttpPut("{id}")]
        public Hero Update([FromRoute] int id, [FromBody] Hero newHero)
        {
            var heroToUpdate = _context.heroes.FirstOrDefault(h => h.Id == id);

            if(heroToUpdate == null)
            {
                return null;
            }

            heroToUpdate.Name = newHero.Name;
            heroToUpdate.RealName = newHero.RealName;
            heroToUpdate.GroupId = newHero.GroupId;

            _context.Update(heroToUpdate);
            _context.SaveChanges();

            return heroToUpdate;
        }
    }
}