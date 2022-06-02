using System.Collections.Generic;

namespace DemoScrutor.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        public List<string> GetAll()
        {
            var persons = new List<string>();
            persons.Add("Long");
            persons.Add("Long");
            persons.Add("Long");
            persons.Add("Long");
            persons.Add("Long");
            return persons;
        }
    }
}
