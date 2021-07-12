using Commander.Models;
using Microsoft.EntityFrameworkCore;

namespace Commander.Data
{
    public class PeopleContext : DbContext
    {
        public PeopleContext(DbContextOptions<PeopleContext> opt) : base(opt){}
        public DbSet<Person> People { get; set; }
    }
}