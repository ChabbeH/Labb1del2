using LabbAPI.Entities;
using System.Collections.Generic;
using System.Linq;

namespace LabbAPI.Repositories
{
    public class DogRepositories : IDogRepositories
    {
        
        private readonly List<Dog> _dogTest = new()
        {
            new Dog() { Id = 1, Name ="dog1"},
            new Dog() { Id = 2, Name ="dog2"},
            new Dog() { Id = 3, Name ="dog3"},
        };

     
        public IEnumerable<Dog> GetDog()
        {
            return _dogTest;
        }

        public Dog GetDog(int id)
        {
            var dogs = _dogTest.Where(dogs => dogs.Id == id);
            return dogs.SingleOrDefault();
        }

        public void UpdateDog(Dog dog)
        {
            var index = _dogTest.FindIndex(exDog => exDog.Id == dog.Id);
            _dogTest[index] = dog;
        }

        public void AddDog(Dog dog)
        {
            _dogTest.Add(dog);
        }

        public void DeleteDog(int id)
        {
            var index = _dogTest.FindIndex(exDog => exDog.Id == id);
            _dogTest.RemoveAt(index);
        }



    }
}
