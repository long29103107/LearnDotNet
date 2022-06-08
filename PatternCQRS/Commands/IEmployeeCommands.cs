using PatternCQRS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternCQRS.Commands
{
    public interface IEmployeeCommands
    {
        void SaveEmployeeData(Employee employee);
    }
}
