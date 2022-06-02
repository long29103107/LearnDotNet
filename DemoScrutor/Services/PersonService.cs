using DemoScrutor.Repositories;
using System.Collections.Generic;

namespace DemoScrutor.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public List<string> GetAll()
        {
            return _personRepository.GetAll();
        }
    }
}
