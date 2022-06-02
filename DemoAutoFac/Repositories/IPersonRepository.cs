using System.Collections.Generic;

namespace DemoAutoFac.Repositories
{
    public interface IPersonRepository
    {
        List<string> GetAll();
    }
}
