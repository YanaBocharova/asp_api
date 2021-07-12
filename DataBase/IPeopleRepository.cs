using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data
{
    public interface IPeopleRepository
    {
        bool SaveChanges();
        IEnumerable<Person> GetAll();
        Person GetById(int id);
        void Create(Person person);
        void Update(Person person);
        void Delete(Person person);
    }
}