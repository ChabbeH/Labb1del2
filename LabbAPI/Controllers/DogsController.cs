using LabbAPI.Entities;
using LabbAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LabbAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DogsController : ControllerBase
    {
        private readonly DogRepositories _repository;

        public DogsController(DogRepositories repositories)
        {
            _repository = repositories;
        }

        [HttpGet]

        public IEnumerable<Dog> GetDog()
        {
            return _repository.GetDog();
        }

        [HttpGet("{id}")]


        public ActionResult<Dog> GetDog(int id)
        {
            var dog = _repository.GetDog(id);

            if (dog == null)
            {
                return NotFound();
            }

            return Ok(dog);
        }


        [HttpPut("{id}")]

        public ActionResult UpdateVinyl(Dog v, int id)
        {
            var existingItem = _repository.GetDog(id);
            if (existingItem == null)
            {
                return NotFound();
            }
            existingItem.Name = v.Name;


            _repository.UpdateDog(existingItem);

            return Ok();
        }

        [HttpPost]
        public ActionResult<Dog> AddDog(Dog v)
        {
            Dog dog = new()
            {
                Id = v.Id,
                Name = v.Name,

            };
            _repository.AddDog(dog);
            return CreatedAtAction(nameof(GetDog), new { id = dog.Id }, dog);
        }
        [HttpDelete("{id}")]

        public ActionResult DeleteVinyl(int id)
        {

            _repository.DeleteDog(id);

            return NoContent();
        }
    }
}
