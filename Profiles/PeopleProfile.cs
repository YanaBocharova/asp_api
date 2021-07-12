using AutoMapper;
using Commander.ModelsDTO;
using Commander.Models;

namespace Commander.Profiles
{
    public class PeopleProfile : Profile
    {
        public PeopleProfile()
        {
            CreateMap<Person, PersonDTO>();
            CreateMap<PersonDTO, Person>();
        }
    }
}