using System.Collections.Generic;

namespace DemoAutoFac.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        public List<string> GetAll()
        {
            var results = new List<string>();
            results.Add("Long nè");
            results.Add("Tú nè");
            return results;
        }
    }
}
