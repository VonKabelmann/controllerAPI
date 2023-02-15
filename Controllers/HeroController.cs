using API_Demo_RobinKamo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Demo_RobinKamo.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class HeroController : ControllerBase
	{
		private static List<Hero> _heroes = new List<Hero>()
		{
			new Hero(){Id = 1, Name = "Tony Stark", SuperHeroName = "Iron Man", Team = "Avengers"},
			new Hero(){Id = 2, Name = "Bruce Wayne", SuperHeroName = "Batman", Team = "Justice League"}
		};

		[HttpGet]
		public IActionResult Get()
		{
			return Ok(_heroes);
		}

		[HttpGet("{id}")]
		public IActionResult Get(int id)
		{
			return Ok(_heroes.FirstOrDefault(h => h.Id == id));
		}

		[HttpPost]
		public IActionResult Post(Hero hero)
		{
			_heroes.Add(hero);
			return Ok();
		}

		[HttpPut("{id}")]
		public IActionResult Put(Hero hero)
		{
			var heroToUpdate = _heroes.FirstOrDefault(h => h.Id == hero.Id);
			if (heroToUpdate is null)
			{
				return NotFound();
			}

			heroToUpdate.Name = hero.Name;
			heroToUpdate.SuperHeroName = hero.SuperHeroName;
			heroToUpdate.Team = hero.Team;
			return Ok();
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			var heroToDelete = _heroes.FirstOrDefault(h => h.Id == id);
			if (heroToDelete is null)
			{
				return NotFound();
			}

			_heroes.Remove(heroToDelete);
			return Ok();
		}
	}
}
