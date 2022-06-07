using DemoHotChocolate.Entities;
using DemoHotChocolate.Repositories;
using HotChocolate;
using HotChocolate.Subscriptions;
using System.Threading.Tasks;

namespace DemoHotChocolate.DataAccess
{
    public class Mutation
    {
        public async Task<Department> CreateDepartment([Service] Repositories.DepartmentRepository departmentRepository,
            [Service] ITopicEventSender eventSender, string departmentName)
        {
            var newDepartment = new Department
            {
                Name = departmentName
            };
            var createdDepartment = await departmentRepository.CreateDepartment(newDepartment);

            await eventSender.SendAsync("DepartmentCreated", createdDepartment);

            return createdDepartment;
        }

        public async Task<Department> UpdateDepartment([Service] Repositories.DepartmentRepository departmentRepository,
          [Service] ITopicEventSender eventSender, string departmentName, int id)
        {
            var updateDepartment = new Department
            {
                Name = departmentName
            };
            var updatedDepartment = await departmentRepository.UpdateDepartment(id, updateDepartment);

            await eventSender.SendAsync("DepartmentUpdated", updatedDepartment);

            return updatedDepartment;
        }

        public async Task<bool> DeleteDepartment([Service] Repositories.DepartmentRepository departmentRepository,
        [Service] ITopicEventSender eventSender, int id)
        {
            var deletedDepartment = await departmentRepository.DeleteDepartment(id);

            await eventSender.SendAsync("DepartmentDeleted", deletedDepartment);

            return deletedDepartment;
        }


        public async Task<Employee> CreateEmployeeWithDepartmentId([Service] EmployeeRepository employeeRepository,
            string name, int age, string email, int departmentId)
        {
            Employee newEmployee = new Employee
            {
                Name = name,
                Age = age,
                Email = email,
                DepartmentId = departmentId
            };

            var createdEmployee = await employeeRepository.CreateEmployee(newEmployee);
            return createdEmployee;
        }

        public async Task<Employee> CreateEmployeeWithDepartment([Service] EmployeeRepository employeeRepository,
            string name, int age, string email, string departmentName)
        {
            Employee newEmployee = new Employee
            {
                Name = name,
                Age = age,
                Email = email,
                Department = new Department { Name = departmentName }
            };

            var createdEmployee = await employeeRepository.CreateEmployee(newEmployee);
            return createdEmployee;
        }
    }
}
