using PatternCQRS.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternCQRS.Queries
{
    public interface IEmployeeQueries
    {
        EmployeeDTO FindByID(int employeeID);
    }
}
