using TemplateLiquid.Models;

namespace TemplateLiquid.Repositories
{
    public class EmployeeRepository
    {
        private static Dictionary<int, Employee> employees = new Dictionary<int, Employee>();
        public List<Employee> GetAll()
        {
            return employees.Values.ToList();
        }
        public void Add(Employee employee)
        {
            employee.Id = employees.Count + 1;
            employees.Add(employee.Id, employee);
        }
    }
}
