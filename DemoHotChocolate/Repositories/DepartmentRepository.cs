using DemoHotChocolate.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoHotChocolate.Repositories
{
    public class DepartmentRepository
    {
        private readonly SampleAppDbContext _sampleAppDbContext;

        public DepartmentRepository(SampleAppDbContext sampleAppDbContext)
        {
            _sampleAppDbContext = sampleAppDbContext;
        }

        public List<Department> GetAllDepartmentOnly()
        {
            return _sampleAppDbContext.Department.ToList();
        }

        public List<Department> GetAllDepartmentsWithEmployee()
        {
            return _sampleAppDbContext.Department
                .Include(d => d.Employees)
                .ToList();
        }

        public async Task<Department> GetDepartmentById(int id)
        {
            return await _sampleAppDbContext.Department.Where(d => d.DepartmentId == id).FirstOrDefaultAsync();
        }

        public async Task<Department> CreateDepartment(Department department)
        {
            await _sampleAppDbContext.Department.AddAsync(department);
            await _sampleAppDbContext.SaveChangesAsync();
            return department;
        }

        public async Task<Department> UpdateDepartment(int id,Department department)
        {
            var departmentNeedUpdate = await this.GetDepartmentById(id);

            departmentNeedUpdate.Name = department.Name;
            await _sampleAppDbContext.SaveChangesAsync();
            return department;
        }

        public async Task<bool> DeleteDepartment(int id)
        {
            var departmentNeedDelete = await this.GetDepartmentById(id);
            _sampleAppDbContext.Department.Remove(departmentNeedDelete);
            await _sampleAppDbContext.SaveChangesAsync();
            return true;
        }
    }
}
