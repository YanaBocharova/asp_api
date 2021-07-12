using System.Collections.Generic;
using AutoMapper;
using Commander.Data;
using Commander.Models;
using Commander.ModelsDTO;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;


namespace Commander.Controllers
{
    [Route("api/people")]
    [ApiController]
    public class PersonControllers : ControllerBase
    {
        private readonly IPeopleRepository _repository;
        private readonly IMapper _mapper;

        public PersonControllers(IPeopleRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        //GET api/people
        [HttpGet]
        public ActionResult <IEnumerable<PersonDTO>> GetAllCommmands()
        {
            var commandItems = _repository.GetAll();

            return Ok(_mapper.Map<IEnumerable<PersonDTO>>(commandItems));
        }

        //GET api/people/name{id}
        [HttpGet("{id}", Name="GetCommandById")]
        public ActionResult <PersonDTO> GetCommandById(int id)
        {
            var commandItem = _repository.GetById(id);
            if(commandItem != null)
            {
                return Ok(_mapper.Map<PersonDTO>(commandItem));
            }
            return NotFound();
        }

        //POST api/
        [HttpPost]
        public ActionResult <PersonDTO> CreateCommand(PersonDTO item)
        {
            var personModel = _mapper.Map<Person>(item);
            _repository.Create(personModel);
            _repository.SaveChanges();

            var commandReadDto = _mapper.Map<PersonDTO>(personModel);

            return CreatedAtRoute(nameof(GetCommandById), new {Id = commandReadDto.Id}, commandReadDto);      
              
        }

        //PUT api/people/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, PersonDTO updateDto)
        {
            var modelFromRepo = _repository.GetById(id);
            if(modelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(updateDto, modelFromRepo);

            _repository.Update(modelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            var modelFromRepo = _repository.GetById(id);
            if(modelFromRepo == null)
            {
                return NotFound();
            }
            _repository.Delete(modelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }   
}