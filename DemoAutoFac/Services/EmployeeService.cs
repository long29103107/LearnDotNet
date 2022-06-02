using System.Collections.Generic;

namespace DemoAutoFac.Services
{
    public class EmployeeService : IEmployeeService
    {
        public List<string> GetEmployeeNames()
        {
            List<string> employeeNames = new List<string>();
            employeeNames.Add("Yohan");
            employeeNames.Add("Martin");
            employeeNames.Add("John");
            return employeeNames;
        }
    }
}
