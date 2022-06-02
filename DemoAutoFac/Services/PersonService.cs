using DemoAutoFac.Repositories;
using System.Collections.Generic;

namespace DemoAutoFac.Services
{
    public class PersonService : IPersonService
    {
        private IPersonRepository _personRepository;
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
