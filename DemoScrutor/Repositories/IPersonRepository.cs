using System.Collections.Generic;

namespace DemoScrutor.Repositories
{
    public interface IPersonRepository
    {
        List<string> GetAll();
    }
}
