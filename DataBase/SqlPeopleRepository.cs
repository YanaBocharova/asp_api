using System;
using System.Collections.Generic;
using System.Linq;
using Commander.Models;

namespace Commander.Data
{
    public class SqlPeopleRepository : IPeopleRepository
    {
        private readonly PeopleContext _context;
        public SqlPeopleRepository(PeopleContext context)
        {
            _context = context;
        }
        public void Create(Person person)
        {
            if(person == null)
            {
                throw new ArgumentNullException(nameof(person));
            }
            _context.People.Add(person);
        }
        public void Delete(Person person)
        {
            if(person == null)
            {
                throw new ArgumentNullException(nameof(person));
            }
            _context.People.Remove(person);
        }
        public IEnumerable<Person> GetAll()
        {
            return _context.People.ToList();
        }
        public Person GetById(int id)
        {
            return _context.People.FirstOrDefault(p => p.Id == id);
        }
        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
        public void Update(Person person)
        {
            var search = _context.People.FirstOrDefault(per=>per.Id==person.Id);
            
            if (search != null){
                 
                 search.Copy(person);
            }

            _context.SaveChanges();
        }
    }
}