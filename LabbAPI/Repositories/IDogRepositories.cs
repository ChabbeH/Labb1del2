using LabbAPI.Entities;
using System.Collections.Generic;

namespace LabbAPI.Repositories
{
    public interface IDogRepositories
    {
        IEnumerable<Dog> GetDog();
        Dog GetDog(int id);
        void UpdateDog(Dog dog);

        void AddDog(Dog dog);

        void DeleteDog(int id);
    }
}

